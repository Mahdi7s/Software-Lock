using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using AssemblyLicense.LicenseProvider;
using AssemblyLicense.Model;
using AssemblyLicense.Utils;

namespace AssemblyLicense.License
{
    internal static class Helpers
    {
        public static void CheckLicense(ref SignedExeInfo signedExeInfo, string assemblyFullName, ref string[] licensedAssemblies)
        {
            if(string.IsNullOrEmpty(assemblyFullName))
                throw new ArgumentNullException("assemblyFullName");

            if (signedExeInfo == null)
            {
                TryGetSignedExeInfo(out signedExeInfo);
            }
            if (licensedAssemblies.IsNullOrEmpty())
            {
                licensedAssemblies = GetLicensedAssemblies(signedExeInfo);

                if (licensedAssemblies.IsNullOrEmpty())
                    throw new Exception("Please Get a License Key.");
            }

            if (!licensedAssemblies.Any(x => x.Equals(assemblyFullName)))
            {
                throw new Exception(string.Format("assembly {0} is not licensed.", signedExeInfo.ExeAssembly.FullName));
            }
        }

        private static bool TryGetSignedExeInfo(out SignedExeInfo signedExeInfo)
        {
            try
            {
                signedExeInfo = new SignedExeInfo(Assembly.GetEntryAssembly());
                return true;
            }
            catch (Exception)
            {
                signedExeInfo = null;
                return false;
            }
        }

        public static string[] GetLicensedAssemblies(SignedExeInfo signedExeInfo)
        {
            var encKey = SignedExeInfoExtensions.GetEncryptionKey(signedExeInfo);
            var licContent = string.Empty;
            using (var reader = new StreamReader(GetLicneseFileStream(signedExeInfo)))
            {
                licContent = reader.ReadToEnd();
            }
            try
            {
                licContent = AESEncryption.Decrypt(licContent, encKey);
            }
            catch (CryptographicException)
            {
                throw new Exception("The license file is not for your application.");
            }
            if (string.IsNullOrEmpty(licContent))
                throw new Exception("Your licnense file content is not in a correct format.");

            return licContent.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static Stream GetLicneseFileStream(SignedExeInfo signedExeInfo)
        {
            string licensePath = string.Empty;
            if(signedExeInfo != null)
            {
                licensePath =
                    signedExeInfo.ExeAssembly.GetManifestResourceNames().FirstOrDefault(
                        x => x.EndsWith(signedExeInfo.LicenseName));

                if (!string.IsNullOrEmpty(licensePath))
                    return signedExeInfo.ExeAssembly.GetManifestResourceStream(licensePath);

                licensePath = GetLixPath(signedExeInfo);
                if (!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
                    return File.OpenRead(licensePath);
            }
            //so this can be a website
            licensePath = GetLixPathForWebsite();
            if(!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
                return File.OpenRead(licensePath);

            //i think this can be anythings ! but it is not a software!
            throw new Exception("there is not any license file that match your program.");
        }

       private static string GetLixPath(SignedExeInfo signedExeInfo)
       {
           try
           {
               var exeDir = Path.GetDirectoryName(signedExeInfo.ExeAssembly.Location);
               return Path.Combine(exeDir, "\\" + signedExeInfo.LicenseName);
           }
           catch
           {
               return null;
           }
       }

        private static string GetLixPathForWebsite()
        {
            try
            {
                var dir = Path.GetDirectoryName(typeof (LicManager).Assembly.Location);
                var hostName = HttpContext.Current.Request.Url.Host;
                return Path.Combine(dir, "\\" + hostName + ".lix");
            }
            catch
            {
                return null;
            }
        }
    }
}
