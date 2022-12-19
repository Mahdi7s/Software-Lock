using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AssemblyLicense.License;

namespace LicensedAssembly
{
    [LicenseProvider(typeof(AssemblyFileLicenseProvider))]
    public class AnotherClassOfALicensedAsm
    {
        public AnotherClassOfALicensedAsm()
        {
            LicenseManager.Validate(typeof (AClassOfALicensedAsm));
        }
    }
}
