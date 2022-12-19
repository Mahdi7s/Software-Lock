namespace SabaMediaLock.Wrapper
{
    partial class EnablingWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnablingWizard));
            this.radWizard1 = new Telerik.WinControls.UI.RadWizard();
            this.wizardCompletionPage1 = new Telerik.WinControls.UI.WizardCompletionPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlFailOrSuccess = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.activationType1 = new SabaMediaLock.Wrapper.Forms.ActivationType();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlActivating = new System.Windows.Forms.Panel();
            this.wizardWelcomePage1 = new Telerik.WinControls.UI.WizardWelcomePage();
            this.wizardPage1 = new Telerik.WinControls.UI.WizardPage();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.desertTheme1 = new Telerik.WinControls.Themes.DesertTheme();
            this.highContrastBlackTheme1 = new Telerik.WinControls.Themes.HighContrastBlackTheme();
            this.office2007BlackTheme1 = new Telerik.WinControls.Themes.Office2007BlackTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            ((System.ComponentModel.ISupportInitialize)(this.radWizard1)).BeginInit();
            this.radWizard1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radWizard1
            // 
            this.radWizard1.CompletionPage = this.wizardCompletionPage1;
            this.radWizard1.Controls.Add(this.panel1);
            this.radWizard1.Controls.Add(this.panel2);
            this.radWizard1.Controls.Add(this.panel3);
            this.radWizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radWizard1.Location = new System.Drawing.Point(0, 0);
            this.radWizard1.Mode = Telerik.WinControls.UI.WizardMode.Wizard97;
            this.radWizard1.Name = "radWizard1";
            this.radWizard1.PageHeaderIcon = ((System.Drawing.Image)(resources.GetObject("radWizard1.PageHeaderIcon")));
            this.radWizard1.Pages.Add(this.wizardWelcomePage1);
            this.radWizard1.Pages.Add(this.wizardPage1);
            this.radWizard1.Pages.Add(this.wizardCompletionPage1);
            this.radWizard1.Size = new System.Drawing.Size(800, 400);
            this.radWizard1.TabIndex = 0;
            this.radWizard1.WelcomePage = this.wizardWelcomePage1;
            this.radWizard1.Next += new Telerik.WinControls.UI.WizardCancelEventHandler(this.radWizard1_Next);
            this.radWizard1.Previous += new Telerik.WinControls.UI.WizardCancelEventHandler(this.radWizard1_Previous);
            this.radWizard1.Finish += new System.EventHandler(this.radWizard1_Finish);
            this.radWizard1.Cancel += new System.EventHandler(this.radWizard1_Cancel);
            this.radWizard1.SelectedPageChanging += new Telerik.WinControls.UI.SelectedPageChangingEventHandler(this.radWizard1_SelectedPageChanging);
            this.radWizard1.SelectedPageChanged += new Telerik.WinControls.UI.SelectedPageChangedEventHandler(this.radWizard1_SelectedPageChanged);
            this.radWizard1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radWizard1_MouseDown);
            ((Telerik.WinControls.UI.WizardPageHeaderElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            ((Telerik.WinControls.UI.Wizard97CommandArea)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3))).IsWelcomePage = true;
            ((Telerik.WinControls.UI.Wizard97CommandArea)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3))).IsCompletionPage = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(0))).Text = "لغو";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(1))).Text = "پایان";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).IsFocusedWizardButton = true;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(2))).Text = "بعدی >";
            ((Telerik.WinControls.UI.BaseWizardElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(3))).Text = "<html><u></u></html>";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).IsFocusedWizardButton = false;
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Text = "< قبلی";
            ((Telerik.WinControls.UI.WizardCommandAreaButtonElement)(this.radWizard1.GetChildAt(0).GetChildAt(0).GetChildAt(3).GetChildAt(4))).Enabled = false;
            // 
            // wizardCompletionPage1
            // 
            this.wizardCompletionPage1.ContentArea = this.panel3;
            this.wizardCompletionPage1.Name = "wizardCompletionPage1";
            this.wizardCompletionPage1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pnlFailOrSuccess);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 431);
            this.panel3.TabIndex = 2;
            // 
            // pnlFailOrSuccess
            // 
            this.pnlFailOrSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFailOrSuccess.Location = new System.Drawing.Point(0, 0);
            this.pnlFailOrSuccess.Name = "pnlFailOrSuccess";
            this.pnlFailOrSuccess.Size = new System.Drawing.Size(780, 431);
            this.pnlFailOrSuccess.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.activationType1);
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 296);
            this.panel1.TabIndex = 0;
            // 
            // activationType1
            // 
            this.activationType1.AutoSize = true;
            this.activationType1.BackColor = System.Drawing.Color.Transparent;
            this.activationType1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("activationType1.BackgroundImage")));
            this.activationType1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.activationType1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activationType1.Location = new System.Drawing.Point(0, 0);
            this.activationType1.Name = "activationType1";
            this.activationType1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.activationType1.Size = new System.Drawing.Size(650, 296);
            this.activationType1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pnlActivating);
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 271);
            this.panel2.TabIndex = 1;
            // 
            // pnlActivating
            // 
            this.pnlActivating.BackColor = System.Drawing.Color.Transparent;
            this.pnlActivating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActivating.Location = new System.Drawing.Point(0, 0);
            this.pnlActivating.Name = "pnlActivating";
            this.pnlActivating.Size = new System.Drawing.Size(800, 271);
            this.pnlActivating.TabIndex = 0;
            // 
            // wizardWelcomePage1
            // 
            this.wizardWelcomePage1.ContentArea = this.panel1;
            this.wizardWelcomePage1.Name = "wizardWelcomePage1";
            this.wizardWelcomePage1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // wizardPage1
            // 
            this.wizardPage1.ContentArea = this.panel2;
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // EnablingWizard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.radWizard1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnablingWizard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnablingWizard";
            this.Load += new System.EventHandler(this.EnablingWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radWizard1)).EndInit();
            this.radWizard1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadWizard radWizard1;
        private Telerik.WinControls.UI.WizardCompletionPage wizardCompletionPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.WizardWelcomePage wizardWelcomePage1;
        private Telerik.WinControls.UI.WizardPage wizardPage1;
        private Forms.ActivationType activationType1;
        private System.Windows.Forms.Panel pnlFailOrSuccess;
        private System.Windows.Forms.Panel pnlActivating;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.DesertTheme desertTheme1;
        private Telerik.WinControls.Themes.HighContrastBlackTheme highContrastBlackTheme1;
        private Telerik.WinControls.Themes.Office2007BlackTheme office2007BlackTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
    }
}