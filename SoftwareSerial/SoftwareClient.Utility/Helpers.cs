using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SoftwareClient.Utility
{
    internal static class Helpers
    {
        internal static byte[] ConvertToByte(string str, bool isEncrypting=true)
        {
            return isEncrypting ? Encoding.UTF8.GetBytes(str) : Convert.FromBase64String(str);
        }

        internal static string ConvertToString(byte[] byteArr, bool isDecoded=false)
        {
            return isDecoded ? Encoding.UTF8.GetString(byteArr) : Convert.ToBase64String(byteArr);
        }

        internal static byte[] GetOptinalInteropy(string enteropy)
        {
            return StringUtils.HashWithMD5(enteropy).Take(8).ToArray();
        }
    }
}
