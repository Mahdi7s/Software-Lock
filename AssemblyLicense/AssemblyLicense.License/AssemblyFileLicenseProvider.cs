using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using AssemblyLicense.Model;

namespace AssemblyLicense.License
{
    public class AssemblyFileLicenseProvider : LicFileLicenseProvider
    {
        private static SignedExeInfo _signedExeInfo;
        private static string[] _licensedAssemblies;

        public override System.ComponentModel.License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
        {
            try
            {
                Helpers.CheckLicense(ref _signedExeInfo, type.Assembly.FullName, ref _licensedAssemblies);
                context.SetSavedLicenseKey(type, type.Assembly.FullName);
            }
            catch (Exception)
            {
                return null;
            }
            return new CLicense(type.Assembly.FullName);
        }
    }

    public class CLicense : System.ComponentModel.License
    {
        private readonly string _licenseKey;

        public CLicense(string licenseKey)
        {
            _licenseKey = licenseKey;
        }

        #region Overrides of License

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override string LicenseKey { get { return _licenseKey; } }

        #endregion
    }
}
