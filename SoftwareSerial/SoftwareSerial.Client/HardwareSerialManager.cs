using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using AssemblyLicense.License;
using SoftwareClient.Utility;

namespace SoftwareSerial.Client
{
    public static class Hardware
    {
        public static readonly string CPU = "Win32_processor|ProcessorID";
        public static readonly string Motherboard = "Win32_BaseBoard|SerialNumber";
        public static readonly string RAM = "Win32_PhysicalMemory|SerialNumber";
        public static readonly string HardDisk = "Win32_LogicalDisk|VolumeSerialNumber";

        internal static void GetObjectAndSerialKey(string hardware,out string objectKey, out string serialKey)
        {
            if (string.IsNullOrEmpty(hardware))
                throw new InvalidOperationException("hardware parameter is null.");

            var retVal = hardware.Split(new[] {'|'});

            if(retVal.Length != 2)
                throw new InvalidOperationException("hardware name is not in correct format.");

            objectKey = retVal[0];
            serialKey = retVal[1];
        }
    }

    public static class HardwareSerialManager
    {
        static HardwareSerialManager()
        {
            LicManager.Validate(() => typeof (AutoEnablingSerialValidtor).Assembly.FullName);
        }
        public static string GetHardwareSerial(string hardware)
        {
            string retVal = null, objectKey, serialKey;
            Hardware.GetObjectAndSerialKey(hardware, out objectKey, out serialKey);

            var searcher = new ManagementObjectSearcher(string.Format("Select * From {0}", objectKey));
            var managementObj =
                searcher.Get().Cast<ManagementObject>().FirstOrDefault(
                    x => !string.IsNullOrEmpty(x[serialKey].ToString()));

            if (managementObj == null || managementObj[serialKey] == null)
                throw new ArgumentNullException("managementObj");

            retVal = managementObj[serialKey].ToString();
            retVal = StringUtils.GetDigitAndLetters(retVal).ToUpper();
            return retVal;
        }

        public static bool IsCurrentSystemSerial(string hardware, string serial)
        {
            return GetHardwareSerial(hardware).Equals(serial);
        }
    }
}
