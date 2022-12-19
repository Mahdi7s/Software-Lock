using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyLicense.License;
using SoftwareSerial.Contracts;

namespace SoftwareSerial.Server
{
    public class PackageAndHardwareOrginalCatcher
    {
        private readonly OrginalCatcher _orginalCatcher;

        public PackageAndHardwareOrginalCatcher()
        {
            //LicManager.Validate(() => typeof (SoftwareSerialServer).Assembly.FullName);

            _orginalCatcher = new OrginalCatcher();
        }

        public IAlgorithm Algorithm
        {
            get { return _orginalCatcher.Algorithm; }
            set { _orginalCatcher.Algorithm = value; }
        }

        public void CatchPackageAndHardwareSerials(string randomsAndOrginal, out string packageSerial, out string hardwareSerial)
        {
            var orginal = _orginalCatcher.CatchOrginal(randomsAndOrginal);
            var spliteds = orginal.Split(new[] {'-'});
            string hdd = spliteds[0], package = spliteds[1];//, cpu = spliteds[2];

            packageSerial = package;
            hardwareSerial = hdd;
        }
    }
}
