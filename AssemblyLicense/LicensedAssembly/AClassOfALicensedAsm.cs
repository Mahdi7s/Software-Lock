using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AssemblyLicense.License;

namespace LicensedAssembly
{
    [LicenseProvider(typeof(AssemblyFileLicenseProvider))]
    public class AClassOfALicensedAsm
    {
        public AClassOfALicensedAsm()
        {
            LicenseManager.Validate(typeof(AClassOfALicensedAsm), this);
        }

        public bool CanYouUseThisMethod() //?!
        {
            return true;
        }
    }
}
