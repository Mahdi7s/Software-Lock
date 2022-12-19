using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AssemblyLicense.Model;
using AssemblyLicense.LicenseProvider;
using AssemblyLicense.Utils;

namespace AssemblyLicense.License
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public sealed class LicensedAssemblyAttribute : Attribute
    {
        private static SignedExeInfo _signedExeInfo;
        private static string[] _licensedAssemblies;

        public LicensedAssemblyAttribute(Type aTypeOfAssembly)
        {
            Helpers.CheckLicense(ref _signedExeInfo, aTypeOfAssembly.Assembly.FullName, ref _licensedAssemblies);
        }
    }
}
