using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AssemblyLicense.Model;

namespace AssemblyLicense.ExeInfoCatcher
{
    public static class Catcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlFileDes">path of xml file that you send for us.(by default this is side by side of your exe)</param>
        public static void Catch(string xmlFileDes = null)
        {
            var exeAsm = Assembly.GetEntryAssembly();
            xmlFileDes = xmlFileDes ?? Path.GetDirectoryName(exeAsm.Location) + "\\"+ exeAsm.GetName().Name +".xml";

            var xmlSerializer = new XmlSerializer(typeof (SignedExeInfo));
            using (var fStrm = new FileStream(xmlFileDes, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fStrm, new SignedExeInfo(exeAsm));
            }
        }

        public static SignedExeInfo GetSignedExeInfo(string xmlFilePath)
        {
            if(string.IsNullOrEmpty(xmlFilePath))
                throw new ArgumentNullException("xmlFilePath");

            var xmlSerializer = new XmlSerializer(typeof (SignedExeInfo));

            using (var strm = File.OpenRead(xmlFilePath))
            {
                return xmlSerializer.Deserialize(strm) as SignedExeInfo;
            }
        }
    }
}
