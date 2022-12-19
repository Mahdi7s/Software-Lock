namespace LicenseMakerApp
{
    partial class Form1
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
            this.btnSelectAssemblies = new System.Windows.Forms.Button();
            this.btnSelectExe = new System.Windows.Forms.Button();
            this.btnMakeLix = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectAssemblies
            // 
            this.btnSelectAssemblies.Location = new System.Drawing.Point(12, 12);
            this.btnSelectAssemblies.Name = "btnSelectAssemblies";
            this.btnSelectAssemblies.Size = new System.Drawing.Size(308, 30);
            this.btnSelectAssemblies.TabIndex = 0;
            this.btnSelectAssemblies.Text = "Select Licensed Assemblies";
            this.btnSelectAssemblies.UseVisualStyleBackColor = true;
            this.btnSelectAssemblies.Click += new System.EventHandler(this.btnSelectAssemblies_Click);
            // 
            // btnSelectExe
            // 
            this.btnSelectExe.Location = new System.Drawing.Point(12, 48);
            this.btnSelectExe.Name = "btnSelectExe";
            this.btnSelectExe.Size = new System.Drawing.Size(308, 27);
            this.btnSelectExe.TabIndex = 1;
            this.btnSelectExe.Text = "Select Exe";
            this.btnSelectExe.UseVisualStyleBackColor = true;
            this.btnSelectExe.Click += new System.EventHandler(this.btnSelectExe_Click);
            // 
            // btnMakeLix
            // 
            this.btnMakeLix.Location = new System.Drawing.Point(125, 206);
            this.btnMakeLix.Name = "btnMakeLix";
            this.btnMakeLix.Size = new System.Drawing.Size(75, 23);
            this.btnMakeLix.TabIndex = 2;
            this.btnMakeLix.Text = "Make Lix";
            this.btnMakeLix.UseVisualStyleBackColor = true;
            this.btnMakeLix.Click += new System.EventHandler(this.btnMakeLix_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "select exe info(xml)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 269);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMakeLix);
            this.Controls.Add(this.btnSelectExe);
            this.Controls.Add(this.btnSelectAssemblies);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectAssemblies;
        private System.Windows.Forms.Button btnSelectExe;
        private System.Windows.Forms.Button btnMakeLix;
        private System.Windows.Forms.Button button1;
    }
}

