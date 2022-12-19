namespace SoftwareSerialClientApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtWcfAddress = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPackageSerial = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblSerialValidationState = new System.Windows.Forms.Label();
            this.lblHardwareSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txtGenerateEnablingSerial = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.lblSmsValidation = new System.Windows.Forms.Label();
            this.cmbSerialLen = new System.Windows.Forms.ComboBox();
            this.txtSoftName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate Hardware Serial";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtWcfAddress
            // 
            this.txtWcfAddress.Location = new System.Drawing.Point(12, 12);
            this.txtWcfAddress.Name = "txtWcfAddress";
            this.txtWcfAddress.Size = new System.Drawing.Size(487, 22);
            this.txtWcfAddress.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(760, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Initialize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPackageSerial
            // 
            this.txtPackageSerial.Location = new System.Drawing.Point(12, 111);
            this.txtPackageSerial.Name = "txtPackageSerial";
            this.txtPackageSerial.Size = new System.Drawing.Size(132, 22);
            this.txtPackageSerial.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Validate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblSerialValidationState
            // 
            this.lblSerialValidationState.AutoSize = true;
            this.lblSerialValidationState.Location = new System.Drawing.Point(255, 114);
            this.lblSerialValidationState.Name = "lblSerialValidationState";
            this.lblSerialValidationState.Size = new System.Drawing.Size(0, 17);
            this.lblSerialValidationState.TabIndex = 6;
            // 
            // lblHardwareSerial
            // 
            this.lblHardwareSerial.Location = new System.Drawing.Point(274, 63);
            this.lblHardwareSerial.Name = "lblHardwareSerial";
            this.lblHardwareSerial.Size = new System.Drawing.Size(283, 22);
            this.lblHardwareSerial.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "SMS";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 191);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Generate Enabling Serial";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtGenerateEnablingSerial
            // 
            this.txtGenerateEnablingSerial.Location = new System.Drawing.Point(184, 194);
            this.txtGenerateEnablingSerial.Name = "txtGenerateEnablingSerial";
            this.txtGenerateEnablingSerial.Size = new System.Drawing.Size(303, 22);
            this.txtGenerateEnablingSerial.TabIndex = 11;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(493, 193);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Validate";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblSmsValidation
            // 
            this.lblSmsValidation.AutoSize = true;
            this.lblSmsValidation.Location = new System.Drawing.Point(577, 197);
            this.lblSmsValidation.Name = "lblSmsValidation";
            this.lblSmsValidation.Size = new System.Drawing.Size(46, 17);
            this.lblSmsValidation.TabIndex = 13;
            this.lblSmsValidation.Text = "label2";
            // 
            // cmbSerialLen
            // 
            this.cmbSerialLen.FormattingEnabled = true;
            this.cmbSerialLen.Items.AddRange(new object[] {
            "26",
            "13"});
            this.cmbSerialLen.Location = new System.Drawing.Point(505, 12);
            this.cmbSerialLen.Name = "cmbSerialLen";
            this.cmbSerialLen.Size = new System.Drawing.Size(52, 24);
            this.cmbSerialLen.TabIndex = 14;
            // 
            // txtSoftName
            // 
            this.txtSoftName.Location = new System.Drawing.Point(580, 12);
            this.txtSoftName.Name = "txtSoftName";
            this.txtSoftName.Size = new System.Drawing.Size(161, 22);
            this.txtSoftName.TabIndex = 15;
            this.txtSoftName.Text = "Soft Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 622);
            this.Controls.Add(this.txtSoftName);
            this.Controls.Add(this.cmbSerialLen);
            this.Controls.Add(this.lblSmsValidation);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtGenerateEnablingSerial);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHardwareSerial);
            this.Controls.Add(this.lblSerialValidationState);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtPackageSerial);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtWcfAddress);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtWcfAddress;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPackageSerial;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblSerialValidationState;
        private System.Windows.Forms.TextBox lblHardwareSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtGenerateEnablingSerial;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblSmsValidation;
        private System.Windows.Forms.ComboBox cmbSerialLen;
        private System.Windows.Forms.TextBox txtSoftName;
    }
}

