using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TS7S.Base;

namespace SabaMediaLock.Utilities
{
    public static class PathHelper
    {
        public static string MakeRelativePath(string fromPath, string toPath)
        {
            if (string.IsNullOrEmpty(fromPath))
                throw new ArgumentNullException("fromPath");
            if (string.IsNullOrEmpty(toPath))
                throw new ArgumentNullException("toPath");

            var relativeUri = (new Uri(fromPath)).MakeRelativeUri(new Uri(toPath));
            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            return relativePath.Replace('/', Path.DirectorySeparatorChar);
        }

        public static void CopyDirectory(string srcDir, string desDir)
        {
            Directory.GetDirectories(srcDir, "*", SearchOption.AllDirectories).Apply(x => 
            {
                Directory.CreateDirectory(Path.Combine(desDir, Path.GetFileName(x)));
            });

            Directory.GetFiles(srcDir, "*.*", SearchOption.AllDirectories).Apply(x =>
            {
                File.Copy(x, Path.Combine(desDir, Path.GetFileName(x)));
            });
        }

        public static string CombineRelative(string basePath, string relativePath)
        {
            return new Uri(new Uri(Path.GetDirectoryName(basePath)), relativePath).AbsolutePath;
        }
    }
}
