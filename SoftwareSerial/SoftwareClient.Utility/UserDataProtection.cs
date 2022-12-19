using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AssemblyLicense.License;

namespace SoftwareClient.Utility
{
    public static class UserDataProtection
    {
        static UserDataProtection()
        {
            //LicManager.Validate(() => typeof (StringUtils).Assembly.FullName);
        }

        public static string Protect(string data, string password)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException("data");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            var retBytes = ProtectedData.Protect(Helpers.ConvertToByte(data, true), Helpers.GetOptinalInteropy(password),
                                                 DataProtectionScope.LocalMachine);

            return Helpers.ConvertToString(retBytes);
        }

        public static string Unprotect(string encryptedData, string password)
        {
            if (string.IsNullOrEmpty(encryptedData))
                throw new ArgumentNullException("encryptedData");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
   
            var retBytes = ProtectedData.Unprotect(Helpers.ConvertToByte(encryptedData, false),
                                                   Helpers.GetOptinalInteropy(password),
                                                   DataProtectionScope.LocalMachine);

            return Helpers.ConvertToString(retBytes, true);
        }
    }
}
