namespace BlockChainVotings
{
    partial class RegisterLoginForm
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
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPrivateKey = new System.Windows.Forms.Label();
            this.labelPublicKey = new System.Windows.Forms.Label();
            this.textBoxPrivateKey = new System.Windows.Forms.TextBox();
            this.textBoxPublicKey = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRegister = new System.Windows.Forms.TabPage();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(186, 120);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(75, 23);
            this.buttonRegister.TabIndex = 0;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(133, 84);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(213, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // labelPrivateKey
            // 
            this.labelPrivateKey.AutoSize = true;
            this.labelPrivateKey.Location = new System.Drawing.Point(56, 58);
            this.labelPrivateKey.Name = "labelPrivateKey";
            this.labelPrivateKey.Size = new System.Drawing.Size(58, 13);
            this.labelPrivateKey.TabIndex = 7;
            this.labelPrivateKey.Text = "PrivateKey";
            // 
            // labelPublicKey
            // 
            this.labelPublicKey.AutoSize = true;
            this.labelPublicKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPublicKey.Location = new System.Drawing.Point(56, 32);
            this.labelPublicKey.Name = "labelPublicKey";
            this.labelPublicKey.Size = new System.Drawing.Size(54, 13);
            this.labelPublicKey.TabIndex = 6;
            this.labelPublicKey.Text = "PublicKey";
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Location = new System.Drawing.Point(133, 55);
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.Size = new System.Drawing.Size(213, 20);
            this.textBoxPrivateKey.TabIndex = 5;
            // 
            // textBoxPublicKey
            // 
            this.textBoxPublicKey.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPublicKey.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPublicKey.Location = new System.Drawing.Point(133, 29);
            this.textBoxPublicKey.Name = "textBoxPublicKey";
            this.textBoxPublicKey.Size = new System.Drawing.Size(213, 20);
            this.textBoxPublicKey.TabIndex = 4;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(57, 87);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRegister);
            this.tabControl1.Controls.Add(this.tabPageLogin);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(502, 283);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageRegister
            // 
            this.tabPageRegister.Controls.Add(this.textBoxPublicKey);
            this.tabPageRegister.Controls.Add(this.labelPassword);
            this.tabPageRegister.Controls.Add(this.buttonRegister);
            this.tabPageRegister.Controls.Add(this.labelPrivateKey);
            this.tabPageRegister.Controls.Add(this.textBoxPassword);
            this.tabPageRegister.Controls.Add(this.labelPublicKey);
            this.tabPageRegister.Controls.Add(this.textBoxPrivateKey);
            this.tabPageRegister.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegister.Name = "tabPageRegister";
            this.tabPageRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegister.Size = new System.Drawing.Size(494, 257);
            this.tabPageRegister.TabIndex = 0;
            this.tabPageRegister.Text = "Register";
            this.tabPageRegister.UseVisualStyleBackColor = true;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(494, 257);
            this.tabPageLogin.TabIndex = 1;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // RegisterLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 307);
            this.Controls.Add(this.tabControl1);
            this.Name = "RegisterLoginForm";
            this.Text = "RegisterLoginForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPageRegister.ResumeLayout(false);
            this.tabPageRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPrivateKey;
        private System.Windows.Forms.Label labelPublicKey;
        private System.Windows.Forms.TextBox textBoxPrivateKey;
        private System.Windows.Forms.TextBox textBoxPublicKey;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRegister;
        private System.Windows.Forms.TabPage tabPageLogin;
    }
}