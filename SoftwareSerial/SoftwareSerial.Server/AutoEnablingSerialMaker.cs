using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyLicense.License;
using SoftwareClient.Utility;

namespace SoftwareSerial.Server
{
    public class AutoEnablingSerialMaker
    {
        private readonly string _password;
        public AutoEnablingSerialMaker(string password)
        {
            //LicManager.Validate(() => typeof (SoftwareSerialServer).Assembly.FullName);

            _password = password;
        }

        public string Generate(string softwareName, string automatedSerial)
        {
            if(string.IsNullOrEmpty(softwareName))
                throw new ArgumentNullException("softwareName");
            if(string.IsNullOrEmpty(automatedSerial))
                throw new ArgumentNullException("automatedSerial");

            var isAesEnc = automatedSerial.Length == 26;
            var encryptedbytes = StringUtils.FromBase32String(automatedSerial);
            var randAndBytes = isAesEnc
                                   ? AESEncryption.Decrypt(encryptedbytes, _password)
                                   : DESEncryption.Decrypt(encryptedbytes, _password);
            var randByte = randAndBytes.First();
            var bytes = randAndBytes.Skip(1).ToArray();

            bytes = StringUtils.AddByte(bytes, randByte);
            var encreybtedBytes = isAesEnc
                                      ? AESEncryption.Encrypt(bytes, _password)
                                      : DESEncryption.Encrypt(bytes, _password);

            var softwareNameBytes = Encoding.UTF8.GetBytes(softwareName);
            var addVal = (byte) (randByte*2);
            softwareNameBytes = StringUtils.AddByte(softwareNameBytes, addVal);

            return StringUtils.ToBase32String(encreybtedBytes) + StringUtils.ToBase32String(softwareNameBytes);
        }
    }
}
