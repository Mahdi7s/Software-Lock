namespace SabaMediaLock.Wrapper.Forms
{
    partial class SmsActivation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPackageSerial = new Telerik.WinControls.UI.RadTextBox();
            this.txtEnablingSerial = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.txtTempSerial = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblToSendMsg = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackageSerial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnablingSerial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempSerial)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtPackageSerial, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEnablingSerial, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.radButton1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTempSerial, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblToSendMsg, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 400);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtPackageSerial
            // 
            this.txtPackageSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackageSerial.Location = new System.Drawing.Point(3, 3);
            this.txtPackageSerial.Name = "txtPackageSerial";
            this.txtPackageSerial.Size = new System.Drawing.Size(183, 20);
            this.txtPackageSerial.TabIndex = 6;
            this.txtPackageSerial.TabStop = false;
            this.txtPackageSerial.TextChanged += new System.EventHandler(this.txtPackageSerial_TextChanged);
            // 
            // txtEnablingSerial
            // 
            this.txtEnablingSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnablingSerial.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.txtEnablingSerial, 3);
            this.txtEnablingSerial.Location = new System.Drawing.Point(3, 29);
            this.txtEnablingSerial.Name = "txtEnablingSerial";
            this.txtEnablingSerial.Size = new System.Drawing.Size(472, 20);
            this.txtEnablingSerial.TabIndex = 4;
            this.txtEnablingSerial.TabStop = false;
            this.txtEnablingSerial.TextChanged += new System.EventHandler(this.txtEnablingSerial_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 6);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "سریال موقت : ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 32);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "سریال فعال سازی : ";
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.radButton1, 4);
            this.radButton1.Enabled = false;
            this.radButton1.Image = global::SabaMediaLock.Wrapper.Properties.Resources.button_ok;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(3, 55);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(580, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "فعال کردن برنامه";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // txtTempSerial
            // 
            this.txtTempSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTempSerial.Location = new System.Drawing.Point(292, 3);
            this.txtTempSerial.Name = "txtTempSerial";
            this.txtTempSerial.ReadOnly = true;
            this.txtTempSerial.Size = new System.Drawing.Size(183, 20);
            this.txtTempSerial.TabIndex = 3;
            this.txtTempSerial.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 6);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "سریال روی بسته : ";
            // 
            // lblToSendMsg
            // 
            this.lblToSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToSendMsg.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblToSendMsg, 4);
            this.lblToSendMsg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToSendMsg.Location = new System.Drawing.Point(3, 372);
            this.lblToSendMsg.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblToSendMsg.Name = "lblToSendMsg";
            this.lblToSendMsg.Size = new System.Drawing.Size(580, 18);
            this.lblToSendMsg.TabIndex = 7;
            this.lblToSendMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SmsActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SabaMediaLock.Wrapper.Properties.Resources.sms_icon1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SmsActivation";
            this.Size = new System.Drawing.Size(586, 400);
            this.Load += new System.EventHandler(this.SmsActivation_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackageSerial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnablingSerial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempSerial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadTextBox txtPackageSerial;
        private Telerik.WinControls.UI.RadTextBox txtEnablingSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadTextBox txtTempSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblToSendMsg;

    }
}
