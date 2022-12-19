using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AssemblyLicense.Model;

namespace AssemblyLicense.License
{
    public static class LicManager
    {
        private static SignedExeInfo _signedExeInfo;
        private static string[] _licensedAssemblies;
        private static string _assemblyFullName;

        public static void Validate(Func<string> getAssemblyFullName)
        {
            if(string.IsNullOrEmpty(_assemblyFullName))
                _assemblyFullName = getAssemblyFullName();

            Helpers.CheckLicense(ref _signedExeInfo, _assemblyFullName, ref _licensedAssemblies);
        }
    }
}
