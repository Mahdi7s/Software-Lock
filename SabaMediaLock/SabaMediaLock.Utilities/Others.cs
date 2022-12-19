using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TS7S.Base;

namespace SabaMediaLock.Utilities
{
    public static class Others
    {
        public static string RandomString(int length)
        {
            var rand = new Random();
            return new string(Enumerable.Range(0, length).Select(x => (char)rand.Next(0, 255)).ToArray());
        }

        public static Icon GetAppIcon(string icoName = "AppIcon.ico")
        {
            var icoPath = Path.Combine(Application.StartupPath, icoName);
            if (File.Exists(icoPath))
            {
                return new Icon(icoPath);
            }
            return null;
        }
    }
}
