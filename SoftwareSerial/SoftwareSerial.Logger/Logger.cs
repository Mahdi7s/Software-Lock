using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Logger
{
    public static class Logger
    {
        public static void WriteLine(string text)
        {
            using (var streamWriter = new StreamWriter(GetLogStream()))
            {
                streamWriter.WriteLine(text);
            }
        }

        private static Stream GetLogStream()
        {
            string path = Path.GetDirectoryName(typeof (Logger).Assembly.Location);
            path = Path.Combine(path, "\\Log.text");
            return new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
    }
}
