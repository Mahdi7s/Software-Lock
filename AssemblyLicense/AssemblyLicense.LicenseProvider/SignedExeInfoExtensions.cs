using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using AssemblyLicense.Model;

namespace AssemblyLicense.LicenseProvider
{
    /*internal*/
    public static class SignedExeInfoExtensions
    {
        public static string GetEncryptionKey(SignedExeInfo signedExeInfo)
        {
            string retval = string.Empty;
            try
            {
                if (signedExeInfo != null)
                {
                    var version = string.Format("{0}.{1}", signedExeInfo.VersionMajor, signedExeInfo.VersionMinor);
                    retval = signedExeInfo.Name + version +
                                 signedExeInfo.PublicKeyToken.Aggregate(string.Empty,
                                                                        (current, keyByte) =>
                                                                        current +
                                                                        keyByte.ToString(CultureInfo.InvariantCulture));
                }
                else //so this can be a website !
                {                    
                    var url = HttpContext.Current.Request.Url;
                    retval = string.Format("{0}:{1}{2}", url.Port, url.Host, url.Scheme);
                }
            }
            catch
            {
                retval = string.Empty;
            }
            return retval;
        }
    }
}
