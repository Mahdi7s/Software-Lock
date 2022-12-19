using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Locker.Models;
using SabaMediaLock.Contracts;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using SabaMediaLock.Utilities;
using TS7S.Base;
using TS7S.Base.Threading;
using TS7S.Base.Encryption;
using TS7S.Base.IO;

namespace SabaMediaLock.Locker.Controllers
{
    public partial class ProcessingForm : UserControl
    {
        private RadWizard _wizard = null;
        public ProcessingForm()
        {
            InitializeComponent();
        }

        public string MediaFilePath { get; set; }
        public bool UseDefaultTheme { get { return DShare.GeneralSettings.cbUseDefaultEnablingForm.Checked; } }

        public List<GridRowData> GridDatas { get; set; }
        public string SelectedTheme { get { return DShare.Theme; } }
        public Form1 Form1 { get; set; }

        private void ProcessingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ExportSettings()
        {
            pictureBox1.Visible = true;
            ThreadHelper.RunAsync(() =>
            {
                Func<string, FormType> toFormType = (x) => (FormType)Enum.Parse(typeof(FormType), x);
                Func<SkinKind> getSkinKind = () => UseDefaultTheme ? SkinKind.Default : SkinKind.Flash;
                Func<string, ItemType> toItemType = (x) => (ItemType)Enum.Parse(typeof(ItemType), x);
                Func<IEnumerable<GridRowData>, List<FormItem>> toItems = (x) => x.Select(gi => new FormItem { ItemName = gi.Item, ItemType = toItemType(gi.ItemType), PropertyName = gi.Property, PropertyValue = gi.Value }).ToList();
                Func<List<DefaultFormSetting>> getDefaultFormsSettings = () => GridDatas.GroupBy(x => x.FormKey).Select(x => new DefaultFormSetting { FormType = toFormType(x.Key), Items = toItems(x) }).ToList();

                var data = new SettingsModel
                {
                    UseDefaultWizard =DShare.GeneralSettings.cbUseDefaultEnablingForm.Checked,
                    Password = "password",
                    UseDefaultWindowButtons = DShare.GeneralSettings.cbUseDefaultWindowButtons.Checked,
                    WindowWidth = int.Parse(DShare.GeneralSettings.txtWindowWidth.Text),
                    WindowHeight = int.Parse(DShare.GeneralSettings.txtWindowHeight.Text),
                    Theme = SelectedTheme,
                    MediaFilePath = Form1.txtFilePath.Text,
                    SerialLen = Form1.rb13Len.IsChecked ? 13 : 26,
                    ServiceAddress = "http://www.pcfarda.com/lockservice.svc",
                    SoftwareName = Form1.txtSoftName.Text,
                    SoftwareUniqueName = Form1.txtSoftwareUniqueName.Text,
                    SkinKind = getSkinKind(),
                    DefaultFormsSettings = getDefaultFormsSettings(),
                    FlashFormsSettings = null,
                    Encrypted = DShare.GeneralSettings.cbEncryptFlash.Checked,
                    EncryptedResource = DShare.GeneralSettings.cbEncryptResources.Checked
                };

                // Saving & encrypting settings
                // Copy wrapper to desktop

                var desFolder = Path.Combine(Pathes.LockDeployDirectory, Path.GetFileNameWithoutExtension(MediaFilePath));
                if (Directory.Exists(desFolder))
                {
                    (new DirectoryInfo(desFolder)).Delete(true);                    
                }
                Directory.CreateDirectory(desFolder);

                PathHelper.CopyDirectory(Pathes.WrapperAppDirectory, desFolder);
                var dataFolder = Path.Combine(desFolder, "Data");
                Directory.CreateDirectory(dataFolder);

                var wizardFolder = Path.Combine(desFolder, "Wizard");
                Directory.CreateDirectory(wizardFolder);

                var desMediaPath = Path.Combine(dataFolder, Path.GetFileName(data.MediaFilePath));              

                if (data.EncryptedResource)
                {
                    var resourcesPath = DShare.GeneralSettings.txtResourcesPath.Text;
                    var rel = PathHelper.MakeRelativePath(Path.GetDirectoryName(data.MediaFilePath), resourcesPath);
                    var resourcesDes = Path.Combine(dataFolder, rel.Replace(".."+Path.DirectorySeparatorChar.ToString(),""));
                    EncryptDirectory(resourcesPath, resourcesDes, data);
                }
                if (data.Encrypted)
                {
                    var fEncryptor = new FileEncryptor(data.Password);
                    fEncryptor.AesEncrypt(data.MediaFilePath, desMediaPath);
                }

                var path = Path.Combine(desFolder, "LockSettings.dat");
                var fEn = new FileEncryptor("肵噄ꔪᅍ欞믎볝尩Ⓢ㜍嵏鸡끟瓽ᘟ࠴쉿光鋯〨㘱Ṟ");
                var rand = new Random();
                data.AAA = Enumerable.Range(0, 5).Select(x => (byte)rand.Next(0, 255)).ToArray();

                if (!data.DefaultFormsSettings.IsNullOrEmpty())
                {
                    Directory.CreateDirectory(wizardFolder);

                    data.DefaultFormsSettings.SelectMany(x => x.Items).Where(x => x.PropertyName == "عکس" || x.PropertyName == "پس زمینه").Apply(x =>
                    {
                        if (!string.IsNullOrWhiteSpace(x.PropertyValue) && File.Exists(x.PropertyValue))
                        {
                            var fName =Path.GetFileName(x.PropertyValue);
                            File.Copy(x.PropertyValue, Path.Combine(wizardFolder, fName));
                            x.PropertyValue = fName;
                        }
                    });
                }

                using (var memStrm = new MemoryStream())
                {
                    ObjectSerializer<SettingsModel>.SerializeBinary(memStrm, data);
                    using (var desStrm = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        memStrm.Seek(0, SeekOrigin.Begin);
                        fEn.EncryptOrDecryptFile(fEn.GetCryptoTransform(CryptoAlgorithm.RijndaelManaged), memStrm, desStrm);
                    }
                }
                if (!string.IsNullOrEmpty(DShare.AppIconPath))
                {
                    var icoDesPath = Path.Combine(desFolder, "AppIcon.ico");
                    if (File.Exists(icoDesPath))
                        File.Delete(icoDesPath);
                    File.Copy(DShare.AppIconPath, icoDesPath);
                }
            }, () =>
            {
                pictureBox1.Visible = false;
                _wizard.NextButton.Enabled = true;
                _wizard.CancelButton.Enabled = true;
                _wizard.SelectNextPage();
            });
        }

        private void EncryptDirectory(string srcDir, string desDir, SettingsModel model)
        {
            if (!Directory.Exists(desDir))
            {
                Directory.CreateDirectory(desDir);
            }

            var files = Directory.GetFiles(srcDir, "*.*", SearchOption.AllDirectories);
            var encryptor = new FileEncryptor(model.Password);
            files.Apply(x =>
            {
                if (!model.MediaFilePath.EqualsWithPath(x))
                {
                    encryptor.AesEncrypt(x, Path.Combine(desDir, Path.GetFileName(x)));
                }
            });
        }

        public void OnSelectedPageChanging(object sender, SelectedPageChangingEventArgs e)
        {
            _wizard = ((RadWizard)sender);
            if (e.NextPage == _wizard.Pages[2])
            {
                ExportSettings();
            }
        }

        internal void OnSelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
        }
    }
}
