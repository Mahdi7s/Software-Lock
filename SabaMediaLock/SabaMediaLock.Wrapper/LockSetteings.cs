using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using SabaMediaLock.Contracts;
using SabaMediaLock.Utilities;
using SoftwareSerial.Client;
using SoftwareSerial.Contracts;
using Telerik.WinControls;
using TS7S.Base.Encryption;
using TS7S.Base.IO;

namespace SabaMediaLock.Wrapper
{
   public static class LockSetteings
    {
       public static SettingsModel Settings { get; set; }

       public static void LoadSettings()
       {           
           var path = Path.Combine(Application.StartupPath, "LockSettings.dat");
           if (!File.Exists(path)) throw new Exception("Application can not load the LockSettings.dat file.");

           var fEn = new FileEncryptor("肵噄ꔪᅍ欞믎볝尩Ⓢ㜍嵏鸡끟瓽ᘟ࠴쉿光鋯〨㘱Ṟ");
           var bytes = fEn.EncryptOrDecryptFile(fEn.GetCryptoTransform(CryptoAlgorithm.RijndaelManaged, false), path);
           Settings = ObjectSerializer<SettingsModel>.DeserializeBinary(new MemoryStream(bytes));

           if (!string.IsNullOrWhiteSpace(Settings.Theme))
           {
               ThemeResolutionService.GetTheme(Settings.Theme);
               ThemeResolutionService.ApplicationThemeName = Settings.Theme;
           }
           // ------------------------------------------------------------------------------------------------------------------------------------
           SoftwareSerialClient.Initialize(LockSetteings.Settings.ServiceAddress, LockSetteings.Settings.SoftwareUniqueName, LockSetteings.Settings.SerialLen == 13 ? SerialLengthEnum.Len13 : SerialLengthEnum.Len26, LockSetteings.Settings.Password, Hardware.CPU, Hardware.HardDisk);
       }

       public static bool IsSoftwareValid()
       {
           return SoftwareSerialClient.Shared.RegistryManager.Validate("1", Hardware.CPU, LockSetteings.Settings.Password);
       }
    }
}
