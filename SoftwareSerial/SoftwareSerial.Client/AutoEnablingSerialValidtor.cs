using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AssemblyLicense.License;
using SoftwareClient.Utility;

namespace SoftwareSerial.Client
{
    public class AutoEnablingSerialValidtor
    {
        private readonly string _password;
        public AutoEnablingSerialValidtor(string password)
        {
            LicManager.Validate(() => typeof (AutoEnablingSerialValidtor).Assembly.FullName);

            _password = password;
        }

        public bool Validate(string softwareName, string automatedSerial, string enablingSerial)
        {
            try
            {
                byte randByte;
                var generatedSoftwareName = enablingSerial.Substring(automatedSerial.Length);
                enablingSerial = enablingSerial.Substring(0, automatedSerial.Length);

                var automatedBytes = GetHardwareSerial(automatedSerial, out randByte);

                var enablingSerialBytes = StringUtils.FromBase32String(enablingSerial);
                enablingSerialBytes = automatedSerial.Length == 26
                                          ? AESEncryption.Decrypt(enablingSerialBytes, _password)
                                          : DESEncryption.Decrypt(enablingSerialBytes, _password);

                enablingSerialBytes = StringUtils.SubByte(enablingSerialBytes, randByte);

                var automatedEnablingSerial = StringUtils.ToBase32String(automatedBytes);
                enablingSerial = StringUtils.ToBase32String(enablingSerialBytes);

                return (ValidateSoftwareName(softwareName, generatedSoftwareName, randByte) &&
                        enablingSerial.Equals(automatedEnablingSerial, StringComparison.OrdinalIgnoreCase));
            }
            catch(CryptographicException)
            {
                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        private bool ValidateSoftwareName(string softwareName, string generatedSoftwareName, byte randByte)
        {
            var softwareNameBytes = Encoding.UTF8.GetBytes(softwareName);
            var addVal = (byte) (randByte*2);
            softwareNameBytes = StringUtils.AddByte(softwareNameBytes, addVal);
            return StringUtils.ToBase32String(softwareNameBytes).Equals(generatedSoftwareName, StringComparison.OrdinalIgnoreCase);
        }

        //public string Generate(string automatedSerial)
        //{
        //    var encryptedbytes = StringUtils.FromBase32String(automatedSerial);
        //    var randAndBytes = AESEncryption.Decrypt(encryptedbytes, _password);
        //    var randByte = randAndBytes.First();
        //    var bytes = randAndBytes.Skip(1).ToArray();

        //    AddByte(bytes, randByte);
        //    var encreybtedBytes = AESEncryption.Encrypt(bytes, _password);

        //    return StringUtils.ToBase32String(encreybtedBytes);
        //}

        private byte[] GetHardwareSerial(string automatedSerial, out byte randByte)
        {
            var encryptedbytes = StringUtils.FromBase32String(automatedSerial);
            var randAndBytes = automatedSerial.Length == 26
                                   ? AESEncryption.Decrypt(encryptedbytes, _password)
                                   : DESEncryption.Decrypt(encryptedbytes, _password);
            randByte = randAndBytes.First();

            return randAndBytes.Skip(1).ToArray();
        }
    }
}
