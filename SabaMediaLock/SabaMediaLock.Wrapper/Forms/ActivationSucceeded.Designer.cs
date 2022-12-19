namespace SabaMediaLock.Wrapper.Forms
{
    partial class ActivationSucceeded
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
            this.lblText = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.AutoSize = false;
            this.lblText.BackColor = System.Drawing.Color.Transparent;
            this.lblText.Location = new System.Drawing.Point(0, 301);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(470, 18);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "فعال سازی با موفقیت انجام شد";
            this.lblText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActivationSucceeded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::SabaMediaLock.Wrapper.Properties.Resources._1343538164_green_30;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.lblText);
            this.DoubleBuffered = true;
            this.Name = "ActivationSucceeded";
            this.Size = new System.Drawing.Size(470, 319);
            this.Load += new System.EventHandler(this.ActivationSucceeded_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblText;
    }
}
