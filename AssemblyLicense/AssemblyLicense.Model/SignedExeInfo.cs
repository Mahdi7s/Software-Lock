using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace AssemblyLicense.Model
{
    [Serializable]
    public sealed class SignedExeInfo
    {
        public SignedExeInfo(Assembly exeAsm)
        {
            if (exeAsm == null)
                throw new ArgumentNullException("exeAsm");

            ExeAssembly = exeAsm;
            var asmName = exeAsm.GetName();

            Version = asmName.Version;
            VersionBuild = Version.Build;
            VersionMajor = Version.Major;
            VersionMinor = Version.Minor;
            VersionRevision = Version.Revision;

            PublicKeyToken = asmName.GetPublicKeyToken();
            Name = asmName.Name;
            LicenseName = Name + ".lix";
            

            if (PublicKeyToken == null || PublicKeyToken.Length != 8)
            {
                throw new Exception("Please sign your executable assembly!");                
            }
        }

        public SignedExeInfo(){}
        
        [XmlIgnore]
        public Assembly ExeAssembly { get; set; }
        [XmlIgnore]        
        public Version Version { get; set; }

        public int VersionMinor { get; set; }
        public int VersionMajor { get; set; }
        public int VersionBuild { get; set; }
        public int VersionRevision { get; set; }

        public byte[] PublicKeyToken { get; set; }
        public string Name { get; set; }
        public string LicenseName { get; set; }
    }
}
