using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AssemblyLicense.License;
using Microsoft.Win32;
using SoftwareClient.Utility;

namespace SoftwareSerial.Client
{
    public sealed class SerialRegistryManager
    {
        public SerialRegistryManager(string softwareName, string regValueName = "Default")
        {
            LicManager.Validate(() => typeof (AutoEnablingSerialValidtor).Assembly.FullName);

            if (string.IsNullOrEmpty(softwareName))
                throw new ArgumentNullException("softwareName");

            SoftwareName = softwareName;
            RegValueName = regValueName;
            RegKeyName = string.Format("{0}\\Software\\{1}", Registry.CurrentUser, softwareName);
        }

        public string SoftwareName { get; private set; }
        public string RegValueName { get; private set; }
        public string RegKeyName { get; private set; }

        /// <summary>
        /// pak1-pack2-pack3|hardwareserial
        /// </summary>
        /// <param name="packageName"></param>
        /// <param name="hardwareName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Validate(string packageName, string hardwareName, string password)
        {
            if (string.IsNullOrEmpty(packageName))
                throw new ArgumentNullException("packageName");
            if(string.IsNullOrEmpty(hardwareName))
                throw new ArgumentNullException("hardwareName");
            if(string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            var regVal = GetRegValue(password);
            if (regVal == null) return false;

            var packagesAndHardware = Convert.ToString(regVal).Split(new[] {'|'});
            string packages = packagesAndHardware[0], hardwareSerial = packagesAndHardware[1];

            if(string.IsNullOrEmpty(packages) || string.IsNullOrEmpty(hardwareSerial))
                throw new InvalidOperationException("regVal is not in correct format.");

            if(HardwareSerialManager.IsCurrentSystemSerial(hardwareName,hardwareSerial))
            {
                return packages.ToLower().Contains(packageName.ToLower());
            }
            return false;
        }

        public void InitializeRegValue(string hardwareName, string password, params string[] packagesName)
        {
            if(string.IsNullOrEmpty(hardwareName))
                throw new ArgumentNullException("hardwareName");
            if(string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
            if(packagesName==null || packagesName.Length<=0)
                throw new ArgumentNullException("packagesName");

            var regVal = string.Empty;
            for (int i = 0; i < packagesName.Length; i++)
            {
                regVal += (i == 0) ? packagesName[i] : "-" + packagesName[i];
            }
            var hardwareSerial = HardwareSerialManager.GetHardwareSerial(hardwareName);
            regVal += "|" + hardwareSerial;

            SetRegValue(regVal,password);
        }

        public void AddPackages(string hardwareName, string password, params string[] packagesName)
        {
            var currentPackages = GetNamesOfPackages(hardwareName, password);
            currentPackages = currentPackages ?? new string[] {};

            if(packagesName==null ||packagesName.Length<=0)
                throw new ArgumentNullException("packagesName");
            if(packagesName.Any(x=> currentPackages.Any(cp=>cp.Equals(x,StringComparison.OrdinalIgnoreCase))))
                throw new Exception("One or more of package names are also available.");

            InitializeRegValue(hardwareName, password, currentPackages.Concat(packagesName).ToArray());
        }

        public void RemovePackages(string hardwareName, string password, params string[] packagesName)
        {
            var currentPackages = GetNamesOfPackages(hardwareName, password);
            if(packagesName==null||packagesName.Length<=0)
                throw new ArgumentNullException("packagesName");
            if (packagesName.Any(x => !currentPackages.Any(cp => x.Equals(x, StringComparison.OrdinalIgnoreCase))))
                throw new Exception("One or more the package names are not available.");

            InitializeRegValue(hardwareName, password,
                               currentPackages.Where(
                                   x => packagesName.All(cp => !cp.Equals(x, StringComparison.OrdinalIgnoreCase))).
                                   ToArray());
        }

        public string[] GetNamesOfPackages(string hardwareName,string password)
        {
            if (string.IsNullOrEmpty(hardwareName))
                throw new ArgumentNullException("hardwareName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            var regVal = GetRegValue(password);
            if (regVal == null) return null;

            var packagesAndHardware = Convert.ToString(regVal).Split(new[] { '|' });
            string packages = packagesAndHardware[0], hardwareSerial = packagesAndHardware[1];

            if (string.IsNullOrEmpty(packages) || string.IsNullOrEmpty(hardwareSerial))
                throw new InvalidOperationException("regVal is not in correct format.");

            if (packages.Contains("-"))
                return packages.Split(new[] { '-' });
            return new[] {packages};
        }

        private object GetRegValue(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            var retVal = Registry.GetValue(RegKeyName, RegValueName, null);
            if (retVal == null) return null;

            return UserDataProtection.Unprotect(Convert.ToString(retVal), password);
        }

        private void SetRegValue(object value, string password)
        {
            if(value == null)
                throw new ArgumentNullException("value");
            if(string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            var strValue = Convert.ToString(value);
            Registry.SetValue(RegKeyName, RegValueName, UserDataProtection.Protect(strValue, password));
        }
    }
}
