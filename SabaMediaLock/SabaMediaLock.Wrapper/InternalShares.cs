using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SabaMediaLock.Utilities;

namespace SabaMediaLock.Wrapper
{
    internal static class InternalShares
    {
        private static string _serverPass = string.Empty;

        public static string ServerPassword
        {
            get
            {
                if (string.IsNullOrEmpty(_serverPass))
                {
                    _serverPass = Others.RandomString(50);
                }
                return _serverPass;
            }
        }
    }
}
