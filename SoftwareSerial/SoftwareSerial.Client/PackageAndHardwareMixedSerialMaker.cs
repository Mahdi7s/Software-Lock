using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyLicense.License;
using SoftwareSerial.Contracts;

namespace SoftwareSerial.Client
{
    public class PackageAndHardwareMixedSerialMaker
    {
        private readonly SerialMaker _serialMaker;

        public PackageAndHardwareMixedSerialMaker()
        {
            LicManager.Validate(() => typeof (AutoEnablingSerialValidtor).Assembly.FullName);

            _serialMaker = new SerialMaker();
        }

        public IAlgorithm Algorithm
        {
            get { return _serialMaker.Algorithm; }
            set { _serialMaker.Algorithm = value; }
        }

        public string GenerateNewSerial(string packageSerial)
        {
            var HDDSerial = HardwareSerialManager.GetHardwareSerial(Hardware.HardDisk);
            //var CPUSerial = HardwareSerialManager.GetHardwareSerial(Hardware.CPU);

            return _serialMaker.GenerateSerial(string.Format("{0}-{1}", HDDSerial, packageSerial));
        }
    }
}
