namespace BlockChainVotings
{
    partial class CreateUserForm
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
            this.textBoxPublicKey = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxPrivateKey = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelPublicKey = new MaterialSkin.Controls.MaterialLabel();
            this.labelPrivateKey = new MaterialSkin.Controls.MaterialLabel();
            this.buttonGenerate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonCreateUser = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textBoxName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelName = new MaterialSkin.Controls.MaterialLabel();
            this.labelID = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // textBoxPublicKey
            // 
            this.textBoxPublicKey.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPublicKey.Depth = 0;
            this.textBoxPublicKey.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPublicKey.Hint = "";
            this.textBoxPublicKey.Location = new System.Drawing.Point(85, 138);
            this.textBoxPublicKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPublicKey.MaxLength = 32767;
            this.textBoxPublicKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPublicKey.Name = "textBoxPublicKey";
            this.textBoxPublicKey.PasswordChar = '\0';
            this.textBoxPublicKey.SelectedText = "";
            this.textBoxPublicKey.SelectionLength = 0;
            this.textBoxPublicKey.SelectionStart = 0;
            this.textBoxPublicKey.Size = new System.Drawing.Size(371, 25);
            this.textBoxPublicKey.TabIndex = 0;
            this.textBoxPublicKey.TabStop = false;
            this.textBoxPublicKey.UseSystemPasswordChar = false;
            this.textBoxPublicKey.TextChanged += new System.EventHandler(this.textBoxPublicKey_TextChanged);
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Depth = 0;
            this.textBoxPrivateKey.Hint = "";
            this.textBoxPrivateKey.Location = new System.Drawing.Point(85, 213);
            this.textBoxPrivateKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPrivateKey.MaxLength = 32767;
            this.textBoxPrivateKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.PasswordChar = '\0';
            this.textBoxPrivateKey.SelectedText = "";
            this.textBoxPrivateKey.SelectionLength = 0;
            this.textBoxPrivateKey.SelectionStart = 0;
            this.textBoxPrivateKey.Size = new System.Drawing.Size(371, 25);
            this.textBoxPrivateKey.TabIndex = 1;
            this.textBoxPrivateKey.TabStop = false;
            this.textBoxPrivateKey.UseSystemPasswordChar = false;
            this.textBoxPrivateKey.TextChanged += new System.EventHandler(this.textBoxPublicKey_TextChanged);
            // 
            // labelPublicKey
            // 
            this.labelPublicKey.AutoSize = true;
            this.labelPublicKey.Depth = 0;
            this.labelPublicKey.Font = new System.Drawing.Font("Arial", 10F);
            this.labelPublicKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPublicKey.Location = new System.Drawing.Point(81, 102);
            this.labelPublicKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPublicKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPublicKey.Name = "labelPublicKey";
            this.labelPublicKey.Size = new System.Drawing.Size(83, 19);
            this.labelPublicKey.TabIndex = 2;
            this.labelPublicKey.Text = "PublicKey";
            // 
            // labelPrivateKey
            // 
            this.labelPrivateKey.AutoSize = true;
            this.labelPrivateKey.Depth = 0;
            this.labelPrivateKey.Font = new System.Drawing.Font("Arial", 10F);
            this.labelPrivateKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPrivateKey.Location = new System.Drawing.Point(81, 180);
            this.labelPrivateKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrivateKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPrivateKey.Name = "labelPrivateKey";
            this.labelPrivateKey.Size = new System.Drawing.Size(88, 19);
            this.labelPrivateKey.TabIndex = 3;
            this.labelPrivateKey.Text = "PrivateKey";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Depth = 0;
            this.buttonGenerate.Location = new System.Drawing.Point(305, 426);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGenerate.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(151, 50);
            this.buttonGenerate.TabIndex = 5;
            this.buttonGenerate.Text = "Generate KeyPair";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Depth = 0;
            this.buttonCreateUser.Location = new System.Drawing.Point(85, 426);
            this.buttonCreateUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCreateUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(151, 50);
            this.buttonCreateUser.TabIndex = 4;
            this.buttonCreateUser.Text = "Create User";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.buttonCreateUser_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Depth = 0;
            this.textBoxName.Hint = "";
            this.textBoxName.Location = new System.Drawing.Point(85, 286);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxName.MaxLength = 32767;
            this.textBoxName.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PasswordChar = '\0';
            this.textBoxName.SelectedText = "";
            this.textBoxName.SelectionLength = 0;
            this.textBoxName.SelectionStart = 0;
            this.textBoxName.Size = new System.Drawing.Size(371, 25);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TabStop = false;
            this.textBoxName.UseSystemPasswordChar = false;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxID
            // 
            this.textBoxID.Depth = 0;
            this.textBoxID.Hint = "";
            this.textBoxID.Location = new System.Drawing.Point(85, 358);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxID.MaxLength = 32767;
            this.textBoxID.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.PasswordChar = '\0';
            this.textBoxID.SelectedText = "";
            this.textBoxID.SelectionLength = 0;
            this.textBoxID.SelectionStart = 0;
            this.textBoxID.Size = new System.Drawing.Size(371, 25);
            this.textBoxID.TabIndex = 3;
            this.textBoxID.TabStop = false;
            this.textBoxID.UseSystemPasswordChar = false;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Depth = 0;
            this.labelName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelName.Location = new System.Drawing.Point(81, 254);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 19);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Depth = 0;
            this.labelID.Font = new System.Drawing.Font("Arial", 10F);
            this.labelID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelID.Location = new System.Drawing.Point(81, 325);
            this.labelID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelID.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(26, 19);
            this.labelID.TabIndex = 9;
            this.labelID.Text = "ID";
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 512);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCreateUser);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.labelPrivateKey);
            this.Controls.Add(this.labelPublicKey);
            this.Controls.Add(this.textBoxPrivateKey);
            this.Controls.Add(this.textBoxPublicKey);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "CreateUserForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPublicKey;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPrivateKey;
        private MaterialSkin.Controls.MaterialLabel labelPublicKey;
        private MaterialSkin.Controls.MaterialLabel labelPrivateKey;
        private MaterialSkin.Controls.MaterialRaisedButton buttonGenerate;
        private MaterialSkin.Controls.MaterialRaisedButton buttonCreateUser;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxID;
        private MaterialSkin.Controls.MaterialLabel labelName;
        private MaterialSkin.Controls.MaterialLabel labelID;
    }
}