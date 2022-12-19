using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyLicense.License;
using SoftwareClient.Utility;
using SoftwareSerial.Contracts;

namespace SoftwareSerial.Client
{
    public sealed class AutoHardwareSerialMaker
    {
        private readonly string[] _hardwares;
        private readonly string _password;
        private readonly SerialLengthEnum _serialLengthEnum;

        public AutoHardwareSerialMaker(string password, SerialLengthEnum serialLengthEnum = SerialLengthEnum.Len26, params string[] hardwares)
        {
            LicManager.Validate(() => typeof (AutoEnablingSerialValidtor).Assembly.FullName);

            _hardwares = hardwares;
            _password = password;
            _serialLengthEnum = serialLengthEnum;
        }

        public string Generate(string softwareName)
        {
            return GetHardwareSerial(softwareName, _hardwares);
        }

        private string GetHardwareSerial(string softwareName, params string[] hardwares)
        {
            if(string.IsNullOrEmpty(softwareName))
                throw new ArgumentNullException("softwareName");
            if(hardwares==null || !hardwares.Any())
                throw new ArgumentNullException("hardwares");

            var hardwaresSerial = String.Empty;
            var takenLen = (int)_serialLengthEnum;
            foreach (var hardware in hardwares)
            {
                if(!string.IsNullOrEmpty(hardware))
                {
                    hardwaresSerial += HardwareSerialManager.GetHardwareSerial(hardware);
                }
            }            

            var hashedBytes = StringUtils.HashWithMD5(hardwaresSerial);
            hashedBytes = hashedBytes.Take(takenLen).ToArray();
            var rand = (byte)(new Random()).Next(2, Byte.MaxValue);
            hashedBytes = new byte[] {rand}.Concat(hashedBytes).ToArray();
            hashedBytes = (_serialLengthEnum == SerialLengthEnum.Len26)
                              ? AESEncryption.Encrypt(hashedBytes, _password)
                              : DESEncryption.Encrypt(hashedBytes, _password);

            return StringUtils.ToBase32String(hashedBytes);
        }
    }
}
