using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SabaMediaLock.Utilities
{
    public static class FileUtils
    {
        public static Image LoadWizImg(string imgName, string WizFolderName = "Wizard")
        {
            if (string.IsNullOrWhiteSpace(imgName)) return null;

            var path = Path.Combine(Application.StartupPath, string.Format("{0}{1}{2}", WizFolderName, Path.DirectorySeparatorChar, imgName));
            if (!File.Exists(path)) return null;

            return Image.FromFile(path);
        }

        public static Image LoadImage(string filename, bool isRelative = true)
        {
            var path = isRelative ? Path.Combine(Application.StartupPath, filename) : filename;
            return Image.FromFile(path);
        }

        public static void SaveToFile<T>(T toSave, string path)
        {
            var bf = new BinaryFormatter();
            using (var strm = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                bf.Serialize(strm, toSave);
            }
        }

        public static T ReadFile<T>(string path)
        {
            var bf = new BinaryFormatter();
            using (var strm = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return (T)bf.Deserialize(strm);
            }
        }

        public static void SaveToXml<T>(T toSave, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var strm = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                serializer.Serialize(strm, toSave);
            }
        }

        public static T ReadXml<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var strm = File.OpenRead(path))
            {
                return (T)serializer.Deserialize(strm);
            }
        }
    }
}
