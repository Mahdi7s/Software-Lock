using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using SabaMediaLock.Utilities;
using SoftwareSerial.Client;
using SoftwareSerial.Contracts;
using SoftwareSerial.Model;
using TS7S.Base;
using TS7S.Base.Threading;

namespace SabaMediaLock.Wrapper
{
    public partial class MainForm : Form
    {
        private readonly EnablingWizard _enablingWizard = new EnablingWizard();
        private bool _isFullscreen = false;
        private Rectangle _defaultBounds;
        private FormWindowState _defaultWindowState;
        private FormBorderStyle _defaultBorderStyle;

        private string _lastTempSerial = string.Empty;
        
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            SoftwareSerial.Client.SoftwareSerialClient.Initialize(LockSetteings.Settings.ServiceAddress, LockSetteings.Settings.SoftwareUniqueName, LockSetteings.Settings.SerialLen == 26 ? SerialLengthEnum.Len26 : SerialLengthEnum.Len13, LockSetteings.Settings.Password, Hardware.CPU, Hardware.HardDisk);
            //---------------------------------------------------------------------

            Icon = Others.GetAppIcon();
            Text = LockSetteings.Settings.SoftwareName;

            if (LockSetteings.Settings.WindowWidth > 0)
            {
                this.Width = LockSetteings.Settings.WindowWidth;
            }
            if (LockSetteings.Settings.WindowHeight >0)
            {
                this.Height = LockSetteings.Settings.WindowHeight;
            }
            if (!LockSetteings.Settings.UseDefaultWindowButtons)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }

            _defaultBounds = Bounds;
            _defaultWindowState = WindowState;
           _defaultBorderStyle = FormBorderStyle;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var server = new WebServer();
            var url = "http://localhost:8080/ourlockserver/";
            server.BeginListening(url, GetMediaDirectory());

            var path = GetMediaPath(url);

            if (!LockSetteings.Settings.UseDefaultWizard || LockSetteings.IsSoftwareValid())
            {
                axShockwaveFlash1.LoadMovie(0, path);
                axShockwaveFlash1.Play();
                
            }
            else
            {
                if (LockSetteings.Settings.SkinKind == Contracts.SkinKind.Default)
                {
                    _enablingWizard.ShowDialog();

                    if (LockSetteings.IsSoftwareValid())
                    {
                        axShockwaveFlash1.LoadMovie(0, path);
                        axShockwaveFlash1.Play();
                    }
                    else
                    {
                        ExitApp();
                    }
                }
                else
                {
                    //CallFlashFunction(/*"ShowActivation"*/ "SetState", "hello");
                }
            }
        }

        private void ExitApp()
        {
            axShockwaveFlash1.Dispose();
            Environment.Exit(Environment.ExitCode);
        }

        private string GetMediaDirectory()
        {
            //Path.GetDirectoryName(LockSetteings.Settings.MediaFilePath);
            return Path.Combine(Application.StartupPath, "Data");
        }

        private string GetMediaPath(string url)
        {
            var encodedPass = InternalShares.ServerPassword.ToBase32();
            //encodedPass = HttpUtility.UrlEncode(encodedPass);

            return Path.Combine(url, string.Format("ps={0}/datasofme/{1}", encodedPass, Path.GetFileName(LockSetteings.Settings.MediaFilePath)));
        }

        private void axShockwaveFlash1_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e)
        {
            var document = new XmlDocument();
            document.LoadXml(e.request);

            var attributes = document.FirstChild.Attributes;
            var command = attributes.Item(0).InnerText;
            var arguments = document.GetElementsByTagName("arguments");

            switch (command.ToLower())
            {
                case "activate":
                    ThreadHelper.RunAsync(() =>
                    {
                        var packSerial = arguments[0].InnerText;                       
                        var tempSerial = SoftwareSerial.Client.SoftwareSerialClient.Shared.AutoHardwareSerialMaker.Generate(LockSetteings.Settings.SoftwareUniqueName);

                        var res = SoftwareSerial.Client.SoftwareSerialClient.Shared.ValidateSerial(LockSetteings.Settings.SoftwareUniqueName, packSerial, tempSerial);
                        if (res.Validation == UserSerialValidationResult.IsValid)
                        {
                            if (SoftwareSerialClient.Shared.AutoEnablingSerialValidtor.Validate(LockSetteings.Settings.SoftwareUniqueName, tempSerial, res.EnablingSerial))
                            {
                                SoftwareSerial.Client.SoftwareSerialClient.Shared.RegistryManager.InitializeRegValue(Hardware.CPU, LockSetteings.Settings.Password, "1");
                                return (res.Validation.ToString());
                            }
                            else
                            {
                                return (UserSerialValidationResult.HardwareSerialNotMatches.ToString());
                            }
                        }
                        else
                        {
                            return (res.Validation.ToString());
                        }
                    }, (x) =>
                    {
                        if (x.Error != null)
                        {
                            OnActivationComplete(x.Error.Message);
                        }
                        else
                        {
                            OnActivationComplete(x.Result);
                        }
                    });
                   break;
                case "activatebyactivationnumber":
                   ThreadHelper.RunAsync(() =>
                   {
                       var enablingSerial = arguments[0].InnerText;                
                                                     
                           if (SoftwareSerialClient.Shared.AutoEnablingSerialValidtor.Validate(LockSetteings.Settings.SoftwareUniqueName, _lastTempSerial, enablingSerial))
                           {
                               SoftwareSerial.Client.SoftwareSerialClient.Shared.RegistryManager.InitializeRegValue(Hardware.CPU, LockSetteings.Settings.Password, "1");
                               return (UserSerialValidationResult.IsValid.ToString());
                           }
                           else
                           {
                               return (UserSerialValidationResult.HardwareSerialNotMatches.ToString());
                           }
                   }, (x) =>
                   {
                       if (x.Error != null)
                       {
                           OnActivationComplete(x.Error.Message);
                       }
                       else
                       {
                           OnActivationComplete(x.Result);
                       }
                   });
                   break;
                case "getsmsactivationnumber":
                   ThreadHelper.RunAsync(() =>
                   {
                       var packSerial = arguments[0].InnerText;
                       _lastTempSerial = SoftwareSerialClient.Shared.AutoHardwareSerialMaker.Generate(LockSetteings.Settings.SoftwareUniqueName);

                       OnGetSMSActivationNumberComplete(string.Format("{0}#{1}#{2}", packSerial, _lastTempSerial, LockSetteings.Settings.SoftwareUniqueName));
                   });
                   break;
                case "checkactivity":
                   ThreadHelper.RunAsync(() =>
                   {
                       OnCheckActivityComplete(LockSetteings.IsSoftwareValid());
                   });
                   break;
                case "togglefullscreen":
                   ToggleFullscreen();
                   break;
                case "minimize":
                   this.WindowState = FormWindowState.Minimized;
                   break;
                case "maximize":
                   this.WindowState = FormWindowState.Maximized;
                   break;
                case "close":
                   this.Close();
                   break;
            }
        }

        private void ToggleFullscreen()
        {
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            if (!_isFullscreen)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Bounds = Screen.PrimaryScreen.Bounds;
                Activate();

                _isFullscreen = true;
            }
            else
            {
                WindowState = _defaultWindowState;
                FormBorderStyle = _defaultBorderStyle;
                Bounds = _defaultBounds;
                Activate();

                _isFullscreen = false;
            }
        }

        private string OnGetSMSActivationNumberComplete(string smsText)
        {
            return CallFlashFunction("OnGetSMSActivationNumberComplete", smsText);
        }

        private string OnCheckActivityComplete(bool activationState)
        {
            return CallFlashFunction("OnCheckActivityComplete", activationState);
        }

        private string OnActivationComplete(string activationState)
        {
            return CallFlashFunction("OnActivationComplete", activationState);
        }

        private string CallFlashFunction(string functionName, params object[] arguments)
        {            
            var argsStr = string.Empty;
            foreach(var arg in arguments)
            {
                argsStr += string.Format("<{1}>{0}</{1}>", arg, GetFlashType(arg.GetType()));
            }
            string xml = string.Format("<invoke name=\"{0}\" returntype=\"xml\"><arguments>{1}</arguments></invoke>", functionName, argsStr);

            return axShockwaveFlash1.CallFunction(xml);
        }

        private string GetFlashType(Type type)
        {
                //if(type == typeof(string)) return "string";
                //if(type == typeof(bool)) return "boolean";
            
                return "string";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            ExitApp();
        }
    }
}
