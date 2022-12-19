namespace SabaMediaLock.Wrapper.Forms
{
    partial class InternetActivation
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackageSerial = new System.Windows.Forms.TextBox();
            this.btnActivate = new Telerik.WinControls.UI.RadButton();
            this.pnlConnectingAndActivating = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnActivate)).BeginInit();
            this.pnlConnectingAndActivating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPackageSerial, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnActivate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlConnectingAndActivating, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 498);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "سریال روی بسته : ";
            // 
            // txtPackageSerial
            // 
            this.txtPackageSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackageSerial.Location = new System.Drawing.Point(103, 7);
            this.txtPackageSerial.Name = "txtPackageSerial";
            this.txtPackageSerial.Size = new System.Drawing.Size(312, 20);
            this.txtPackageSerial.TabIndex = 1;
            this.txtPackageSerial.TextChanged += new System.EventHandler(this.txtPackageSerial_TextChanged);
            // 
            // btnActivate
            // 
            this.btnActivate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActivate.Enabled = false;
            this.btnActivate.Image = global::SabaMediaLock.Wrapper.Properties.Resources.button_ok;
            this.btnActivate.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnActivate.Location = new System.Drawing.Point(421, 3);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(312, 24);
            this.btnActivate.TabIndex = 2;
            this.btnActivate.Text = "فعال کردن";
            this.btnActivate.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // pnlConnectingAndActivating
            // 
            this.pnlConnectingAndActivating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConnectingAndActivating.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlConnectingAndActivating, 2);
            this.pnlConnectingAndActivating.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlConnectingAndActivating.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlConnectingAndActivating.Controls.Add(this.pictureBox1, 1, 0);
            this.pnlConnectingAndActivating.Controls.Add(this.label2, 0, 0);
            this.pnlConnectingAndActivating.Location = new System.Drawing.Point(103, 40);
            this.pnlConnectingAndActivating.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlConnectingAndActivating.Name = "pnlConnectingAndActivating";
            this.pnlConnectingAndActivating.RowCount = 1;
            this.pnlConnectingAndActivating.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlConnectingAndActivating.Size = new System.Drawing.Size(630, 23);
            this.pnlConnectingAndActivating.TabIndex = 3;
            this.pnlConnectingAndActivating.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SabaMediaLock.Wrapper.Properties.Resources.ajax_loader__1_;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(602, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "در حال برقراری ارتباط با سرور فعال سازی قفل";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InternetActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::SabaMediaLock.Wrapper.Properties.Resources.internet_explorer_orange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InternetActivation";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(736, 498);
            this.Load += new System.EventHandler(this.InternetActivation_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnActivate)).EndInit();
            this.pnlConnectingAndActivating.ResumeLayout(false);
            this.pnlConnectingAndActivating.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackageSerial;
        private Telerik.WinControls.UI.RadButton btnActivate;
        private System.Windows.Forms.TableLayoutPanel pnlConnectingAndActivating;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}
