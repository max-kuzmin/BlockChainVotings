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
            this.buttonRegister = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textBoxPasswordRegister = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelPrivateKeyRegister = new MaterialSkin.Controls.MaterialLabel();
            this.labelPublicKeyRegister = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxPrivateKeyRegister = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxPublicKeyRegister = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelPasswordRegister = new MaterialSkin.Controls.MaterialLabel();
            this.tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageRegister = new System.Windows.Forms.TabPage();
            this.labelPasswordRegister2 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxPasswordRegister2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.textBoxPublicKeyLogin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelPassLogin = new MaterialSkin.Controls.MaterialLabel();
            this.buttonLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textBoxPassLogin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelPublicKeyLogin = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabControl1.SuspendLayout();
            this.tabPageRegister.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.Depth = 0;
            this.buttonRegister.Location = new System.Drawing.Point(253, 196);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(100, 28);
            this.buttonRegister.TabIndex = 0;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxPasswordRegister
            // 
            this.textBoxPasswordRegister.Depth = 0;
            this.textBoxPasswordRegister.Hint = "";
            this.textBoxPasswordRegister.Location = new System.Drawing.Point(177, 103);
            this.textBoxPasswordRegister.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordRegister.MaxLength = 32767;
            this.textBoxPasswordRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPasswordRegister.Name = "textBoxPasswordRegister";
            this.textBoxPasswordRegister.PasswordChar = '\0';
            this.textBoxPasswordRegister.SelectedText = "";
            this.textBoxPasswordRegister.SelectionLength = 0;
            this.textBoxPasswordRegister.SelectionStart = 0;
            this.textBoxPasswordRegister.Size = new System.Drawing.Size(283, 28);
            this.textBoxPasswordRegister.TabIndex = 3;
            this.textBoxPasswordRegister.TabStop = false;
            this.textBoxPasswordRegister.UseSystemPasswordChar = false;
            this.textBoxPasswordRegister.TextChanged += new System.EventHandler(this.textBoxPasswordRegister_TextChanged);
            // 
            // labelPrivateKeyRegister
            // 
            this.labelPrivateKeyRegister.AutoSize = true;
            this.labelPrivateKeyRegister.Location = new System.Drawing.Point(75, 71);
            this.labelPrivateKeyRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrivateKeyRegister.Name = "labelPrivateKeyRegister";
            this.labelPrivateKeyRegister.Size = new System.Drawing.Size(76, 17);
            this.labelPrivateKeyRegister.TabIndex = 7;
            this.labelPrivateKeyRegister.Text = "PrivateKey";
            // 
            // labelPublicKeyRegister
            // 
            this.labelPublicKeyRegister.AutoSize = true;
            this.labelPublicKeyRegister.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPublicKeyRegister.Location = new System.Drawing.Point(75, 39);
            this.labelPublicKeyRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPublicKeyRegister.Name = "labelPublicKeyRegister";
            this.labelPublicKeyRegister.Size = new System.Drawing.Size(70, 17);
            this.labelPublicKeyRegister.TabIndex = 6;
            this.labelPublicKeyRegister.Text = "PublicKey";
            // 
            // textBoxPrivateKeyRegister
            // 
            this.textBoxPrivateKeyRegister.Depth = 0;
            this.textBoxPrivateKeyRegister.Hint = "";
            this.textBoxPrivateKeyRegister.Location = new System.Drawing.Point(177, 68);
            this.textBoxPrivateKeyRegister.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPrivateKeyRegister.MaxLength = 32767;
            this.textBoxPrivateKeyRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPrivateKeyRegister.Name = "textBoxPrivateKeyRegister";
            this.textBoxPrivateKeyRegister.PasswordChar = '\0';
            this.textBoxPrivateKeyRegister.SelectedText = "";
            this.textBoxPrivateKeyRegister.SelectionLength = 0;
            this.textBoxPrivateKeyRegister.SelectionStart = 0;
            this.textBoxPrivateKeyRegister.Size = new System.Drawing.Size(283, 28);
            this.textBoxPrivateKeyRegister.TabIndex = 5;
            this.textBoxPrivateKeyRegister.TabStop = false;
            this.textBoxPrivateKeyRegister.UseSystemPasswordChar = false;
            this.textBoxPrivateKeyRegister.TextChanged += new System.EventHandler(this.textBoxPublicKeyRegister_TextChanged);
            // 
            // textBoxPublicKeyRegister
            // 
            this.textBoxPublicKeyRegister.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPublicKeyRegister.Depth = 0;
            this.textBoxPublicKeyRegister.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPublicKeyRegister.Hint = "";
            this.textBoxPublicKeyRegister.Location = new System.Drawing.Point(177, 36);
            this.textBoxPublicKeyRegister.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPublicKeyRegister.MaxLength = 32767;
            this.textBoxPublicKeyRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPublicKeyRegister.Name = "textBoxPublicKeyRegister";
            this.textBoxPublicKeyRegister.PasswordChar = '\0';
            this.textBoxPublicKeyRegister.SelectedText = "";
            this.textBoxPublicKeyRegister.SelectionLength = 0;
            this.textBoxPublicKeyRegister.SelectionStart = 0;
            this.textBoxPublicKeyRegister.Size = new System.Drawing.Size(283, 28);
            this.textBoxPublicKeyRegister.TabIndex = 4;
            this.textBoxPublicKeyRegister.TabStop = false;
            this.textBoxPublicKeyRegister.UseSystemPasswordChar = false;
            this.textBoxPublicKeyRegister.TextChanged += new System.EventHandler(this.textBoxPublicKeyRegister_TextChanged);
            // 
            // labelPasswordRegister
            // 
            this.labelPasswordRegister.AutoSize = true;
            this.labelPasswordRegister.Location = new System.Drawing.Point(76, 107);
            this.labelPasswordRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPasswordRegister.Name = "labelPasswordRegister";
            this.labelPasswordRegister.Size = new System.Drawing.Size(69, 17);
            this.labelPasswordRegister.TabIndex = 8;
            this.labelPasswordRegister.Text = "Password";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRegister);
            this.tabControl1.Controls.Add(this.tabPageLogin);
            this.tabControl1.Depth = 0;
            this.tabControl1.Location = new System.Drawing.Point(19, 120);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(669, 348);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageRegister
            // 
            this.tabPageRegister.BackColor = System.Drawing.Color.White;
            this.tabPageRegister.Controls.Add(this.labelPasswordRegister2);
            this.tabPageRegister.Controls.Add(this.textBoxPasswordRegister2);
            this.tabPageRegister.Controls.Add(this.textBoxPublicKeyRegister);
            this.tabPageRegister.Controls.Add(this.labelPasswordRegister);
            this.tabPageRegister.Controls.Add(this.buttonRegister);
            this.tabPageRegister.Controls.Add(this.labelPrivateKeyRegister);
            this.tabPageRegister.Controls.Add(this.textBoxPasswordRegister);
            this.tabPageRegister.Controls.Add(this.labelPublicKeyRegister);
            this.tabPageRegister.Controls.Add(this.textBoxPrivateKeyRegister);
            this.tabPageRegister.Location = new System.Drawing.Point(4, 25);
            this.tabPageRegister.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageRegister.Name = "tabPageRegister";
            this.tabPageRegister.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageRegister.Size = new System.Drawing.Size(661, 319);
            this.tabPageRegister.TabIndex = 0;
            this.tabPageRegister.Text = "Register";
            // 
            // labelPasswordRegister2
            // 
            this.labelPasswordRegister2.AutoSize = true;
            this.labelPasswordRegister2.Location = new System.Drawing.Point(76, 149);
            this.labelPasswordRegister2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPasswordRegister2.Name = "labelPasswordRegister2";
            this.labelPasswordRegister2.Size = new System.Drawing.Size(77, 17);
            this.labelPasswordRegister2.TabIndex = 10;
            this.labelPasswordRegister2.Text = "Password2";
            // 
            // textBoxPasswordRegister2
            // 
            this.textBoxPasswordRegister2.Depth = 0;
            this.textBoxPasswordRegister2.Hint = "";
            this.textBoxPasswordRegister2.Location = new System.Drawing.Point(177, 145);
            this.textBoxPasswordRegister2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordRegister2.MaxLength = 32767;
            this.textBoxPasswordRegister2.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPasswordRegister2.Name = "textBoxPasswordRegister2";
            this.textBoxPasswordRegister2.PasswordChar = '\0';
            this.textBoxPasswordRegister2.SelectedText = "";
            this.textBoxPasswordRegister2.SelectionLength = 0;
            this.textBoxPasswordRegister2.SelectionStart = 0;
            this.textBoxPasswordRegister2.Size = new System.Drawing.Size(283, 28);
            this.textBoxPasswordRegister2.TabIndex = 9;
            this.textBoxPasswordRegister2.TabStop = false;
            this.textBoxPasswordRegister2.UseSystemPasswordChar = false;
            this.textBoxPasswordRegister2.TextChanged += new System.EventHandler(this.textBoxPasswordRegister_TextChanged);
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.Color.White;
            this.tabPageLogin.Controls.Add(this.textBoxPublicKeyLogin);
            this.tabPageLogin.Controls.Add(this.labelPassLogin);
            this.tabPageLogin.Controls.Add(this.buttonLogin);
            this.tabPageLogin.Controls.Add(this.textBoxPassLogin);
            this.tabPageLogin.Controls.Add(this.labelPublicKeyLogin);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 25);
            this.tabPageLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageLogin.Size = new System.Drawing.Size(661, 319);
            this.tabPageLogin.TabIndex = 1;
            this.tabPageLogin.Text = "Login";
            // 
            // textBoxPublicKeyLogin
            // 
            this.textBoxPublicKeyLogin.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPublicKeyLogin.Depth = 0;
            this.textBoxPublicKeyLogin.Enabled = false;
            this.textBoxPublicKeyLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPublicKeyLogin.Hint = "";
            this.textBoxPublicKeyLogin.Location = new System.Drawing.Point(222, 67);
            this.textBoxPublicKeyLogin.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPublicKeyLogin.MaxLength = 32767;
            this.textBoxPublicKeyLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPublicKeyLogin.Name = "textBoxPublicKeyLogin";
            this.textBoxPublicKeyLogin.PasswordChar = '\0';
            this.textBoxPublicKeyLogin.SelectedText = "";
            this.textBoxPublicKeyLogin.SelectionLength = 0;
            this.textBoxPublicKeyLogin.SelectionStart = 0;
            this.textBoxPublicKeyLogin.Size = new System.Drawing.Size(283, 28);
            this.textBoxPublicKeyLogin.TabIndex = 11;
            this.textBoxPublicKeyLogin.TabStop = false;
            this.textBoxPublicKeyLogin.UseSystemPasswordChar = false;
            // 
            // labelPassLogin
            // 
            this.labelPassLogin.AutoSize = true;
            this.labelPassLogin.Location = new System.Drawing.Point(121, 121);
            this.labelPassLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassLogin.Name = "labelPassLogin";
            this.labelPassLogin.Size = new System.Drawing.Size(69, 17);
            this.labelPassLogin.TabIndex = 13;
            this.labelPassLogin.Text = "Password";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Depth = 0;
            this.buttonLogin.Location = new System.Drawing.Point(254, 172);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 28);
            this.buttonLogin.TabIndex = 9;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassLogin
            // 
            this.textBoxPassLogin.Depth = 0;
            this.textBoxPassLogin.Hint = "";
            this.textBoxPassLogin.Location = new System.Drawing.Point(222, 116);
            this.textBoxPassLogin.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassLogin.MaxLength = 32767;
            this.textBoxPassLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPassLogin.Name = "textBoxPassLogin";
            this.textBoxPassLogin.PasswordChar = '\0';
            this.textBoxPassLogin.SelectedText = "";
            this.textBoxPassLogin.SelectionLength = 0;
            this.textBoxPassLogin.SelectionStart = 0;
            this.textBoxPassLogin.Size = new System.Drawing.Size(283, 28);
            this.textBoxPassLogin.TabIndex = 10;
            this.textBoxPassLogin.TabStop = false;
            this.textBoxPassLogin.UseSystemPasswordChar = false;
            this.textBoxPassLogin.TextChanged += new System.EventHandler(this.textBoxPassLogin_TextChanged);
            // 
            // labelPublicKeyLogin
            // 
            this.labelPublicKeyLogin.AutoSize = true;
            this.labelPublicKeyLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPublicKeyLogin.Location = new System.Drawing.Point(120, 70);
            this.labelPublicKeyLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPublicKeyLogin.Name = "labelPublicKeyLogin";
            this.labelPublicKeyLogin.Size = new System.Drawing.Size(70, 17);
            this.labelPublicKeyLogin.TabIndex = 12;
            this.labelPublicKeyLogin.Text = "PublicKey";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.tabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-17, 62);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(727, 35);
            this.materialTabSelector1.TabIndex = 11;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // RegisterLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 506);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterLoginForm";
            this.Text = "RegisterLoginForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPageRegister.ResumeLayout(false);
            this.tabPageRegister.PerformLayout();
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPasswordRegister;
        private MaterialSkin.Controls.MaterialLabel labelPrivateKeyRegister;
        private MaterialSkin.Controls.MaterialLabel labelPublicKeyRegister;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPrivateKeyRegister;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPublicKeyRegister;
        private MaterialSkin.Controls.MaterialLabel labelPasswordRegister;
        private MaterialSkin.Controls.MaterialTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRegister;
        private System.Windows.Forms.TabPage tabPageLogin;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPublicKeyLogin;
        private MaterialSkin.Controls.MaterialLabel labelPassLogin;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPassLogin;
        private MaterialSkin.Controls.MaterialLabel labelPublicKeyLogin;
        private MaterialSkin.Controls.MaterialLabel labelPasswordRegister2;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPasswordRegister2;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRegister;
        private MaterialSkin.Controls.MaterialRaisedButton buttonLogin;
    }
}