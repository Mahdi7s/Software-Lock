using System;
using System.Linq;
using System.IO;
using AssemblyLicense.LicenseProvider;
using AssemblyLicense.Model;
using AssemblyLicense.Utils;

namespace AssemblyLicense.Provider
{
    public static class LicenseFileMaker
    {
        public static void CreateLicenseFile(SignedExeInfo signedExeInfo, string destinationPath, params string[] assemblies)
        {
            if (signedExeInfo == null)
                throw new ArgumentNullException("signedExeInfo");
            if (string.IsNullOrEmpty(destinationPath))
                throw new ArgumentNullException("destinationPath");

            using (
                var fStrm = new FileStream(Path.Combine(destinationPath, signedExeInfo.LicenseName),
                                           FileMode.Create, FileAccess.Write))
            {
                using (var wstrm = new StreamWriter(fStrm))
                {
                    wstrm.Write(GetLicenseFileContent(signedExeInfo,assemblies));
                }
            }
        }

        public static string GetLicenseFileContent(SignedExeInfo signedExeInfo, string[] assemblies)
        {
            var key = SignedExeInfoExtensions.GetEncryptionKey(signedExeInfo);
            return AESEncryption.Encrypt(assemblies.Aggregate(string.Empty, (current, x) => current + x + "\r\n"), key);
        }
    }
}
