using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SabaMediaLock.Locker
{
    public static class Pathes
    {
        private static string _wrapperAppDirectory = null;

        public static readonly string LockDeployDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string WrapperAppDirectory
        {
            get { return (_wrapperAppDirectory = _wrapperAppDirectory ?? Path.Combine(Application.StartupPath, "Wrapper")); }
        }
    }
}
