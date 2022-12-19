namespace SabaMediaLock.Wrapper.Forms
{
    partial class EnablingSoftware
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
            this.radTextBoxControl1 = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBoxControl1
            // 
            this.radTextBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBoxControl1.Location = new System.Drawing.Point(75, 5);
            this.radTextBoxControl1.Name = "radTextBoxControl1";
            this.radTextBoxControl1.Size = new System.Drawing.Size(428, 20);
            this.radTextBoxControl1.TabIndex = 0;
            this.radTextBoxControl1.Text = "radTextBoxControl1";
            // 
            // EnablingSoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radTextBoxControl1);
            this.Name = "EnablingSoftware";
            this.Size = new System.Drawing.Size(506, 230);
            this.Load += new System.EventHandler(this.EnablingSoftware_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl1;


    }
}
