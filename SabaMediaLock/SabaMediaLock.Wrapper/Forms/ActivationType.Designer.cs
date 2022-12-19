namespace SabaMediaLock.Wrapper.Forms
{
    partial class ActivationType
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbTel = new Telerik.WinControls.UI.RadRadioButton();
            this.rbInternet = new Telerik.WinControls.UI.RadRadioButton();
            this.rbSms = new Telerik.WinControls.UI.RadRadioButton();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbInternet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSms)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.rbTel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbInternet, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbSms, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 202);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(496, 24);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // rbTel
            // 
            this.rbTel.AutoSize = true;
            this.rbTel.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbTel.Location = new System.Drawing.Point(448, 3);
            this.rbTel.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.rbTel.Name = "rbTel";
            this.rbTel.Size = new System.Drawing.Size(38, 18);
            this.rbTel.TabIndex = 2;
            this.rbTel.Text = "تلفنی";
            this.rbTel.Visible = false;
            this.rbTel.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbTel_ToggleStateChanged);
            // 
            // rbInternet
            // 
            this.rbInternet.AutoSize = true;
            this.rbInternet.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbInternet.Location = new System.Drawing.Point(300, 3);
            this.rbInternet.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.rbInternet.Name = "rbInternet";
            this.rbInternet.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            // 
            // 
            // 
            this.rbInternet.RootElement.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.rbInternet.Size = new System.Drawing.Size(64, 18);
            this.rbInternet.TabIndex = 0;
            this.rbInternet.TabStop = true;
            this.rbInternet.Text = "اینترنتی";
            this.rbInternet.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rbSms
            // 
            this.rbSms.AutoSize = true;
            this.rbSms.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbSms.Location = new System.Drawing.Point(384, 3);
            this.rbSms.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.rbSms.Name = "rbSms";
            this.rbSms.Size = new System.Drawing.Size(44, 18);
            this.rbSms.TabIndex = 1;
            this.rbSms.Text = "پیامکی";
            // 
            // ActivationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::SabaMediaLock.Wrapper.Properties.Resources._1343538881_Color_MS_Word;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.tableLayoutPanel2);
            this.DoubleBuffered = true;
            this.Name = "ActivationType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(496, 226);
            this.Load += new System.EventHandler(this.ActivationType_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbInternet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadRadioButton rbTel;
        private Telerik.WinControls.UI.RadRadioButton rbInternet;
        private Telerik.WinControls.UI.RadRadioButton rbSms;

    }
}
