using System.Linq;
using AssemblyLicense.Model;
using AssemblyLicense.Utils;
using AssemblyLicense.LicenseProvider;

internal static class Extensions 
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="signedExeInfo"></param>
    /// <param name="assemblies">full name of assemblies</param>
    /// <returns></returns>
    public static string GetLicenseFileContent(this SignedExeInfo signedExeInfo, string[] assemblies)
    {
        var key = SignedExeInfoExtensions.GetEncryptionKey(signedExeInfo);
        return AESEncryption.Encrypt(assemblies.Aggregate(string.Empty, (current, x) => current + x + "\r\n"), key);
    }
}