using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyLicense.License;
using SoftwareClient.Utility;
using SoftwareSerial.Contracts;

namespace SoftwareSerial.Server
{
    public class AutoHardwareSerialCatcher
    {
        private readonly string _password;
        public AutoHardwareSerialCatcher(string password)
        {
            //LicManager.Validate(() => typeof (SoftwareSerialServer).Assembly.FullName);

            _password = password;
        }

        public string Catch(string automatedSerial)
        {
            var encryptedbytes = StringUtils.FromBase32String(automatedSerial);

            var isAesEnc = automatedSerial.Length == 26;
            var randAndBytes = isAesEnc
                                   ? AESEncryption.Decrypt(encryptedbytes, _password)
                                   : DESEncryption.Decrypt(encryptedbytes, _password);
            var bytes = randAndBytes.Skip(1).ToArray();

            return StringUtils.ToBase32String(bytes);
        }
    }
}
