using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SabaMediaLock.Locker.Controllers;

namespace SabaMediaLock.Locker.Models
{
    public static class DShare
    {
        private static readonly Dictionary<string, dynamic> _source = new Dictionary<string, dynamic>();

        public static FlashThemes GeneralSettings { get; set; }
        public static string AppIconPath { get; set; }
        public static string AppTheme { get; set; }

        public static string Username { get; set; }
        public static string Password { get; set; }

        public static event EventHandler OnThemeChanging = delegate { };

        public static void ThemeChanging(string themeName)
        {
            OnThemeChanging(themeName, EventArgs.Empty);
            Theme = themeName;
        }

        public static string Theme { get; set; }
    }
}
