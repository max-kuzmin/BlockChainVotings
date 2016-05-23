namespace BlockChainVotings
{
    partial class BanUserForm
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
            this.listViewSearchUsers = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSearchUser = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxSearchUser = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonBan = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelCause = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxCause = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // listViewSearchUsers
            // 
            this.listViewSearchUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSearchUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewSearchUsers.Depth = 0;
            this.listViewSearchUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.listViewSearchUsers.FullRowSelect = true;
            this.listViewSearchUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSearchUsers.Location = new System.Drawing.Point(80, 248);
            this.listViewSearchUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewSearchUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewSearchUsers.MultiSelect = false;
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.OwnerDraw = true;
            this.listViewSearchUsers.Size = new System.Drawing.Size(417, 190);
            this.listViewSearchUsers.TabIndex = 13;
            this.listViewSearchUsers.UseCompatibleStateImageBehavior = false;
            this.listViewSearchUsers.View = System.Windows.Forms.View.Details;
            this.listViewSearchUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewSearchUsers_ItemSelectionChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hash";
            this.columnHeader4.Width = 115;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 147;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 131;
            // 
            // labelSearchUser
            // 
            this.labelSearchUser.AutoSize = true;
            this.labelSearchUser.Depth = 0;
            this.labelSearchUser.Font = new System.Drawing.Font("Arial", 10F);
            this.labelSearchUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSearchUser.Location = new System.Drawing.Point(76, 154);
            this.labelSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSearchUser.Name = "labelSearchUser";
            this.labelSearchUser.Size = new System.Drawing.Size(96, 19);
            this.labelSearchUser.TabIndex = 12;
            this.labelSearchUser.Text = "SearchUser";
            // 
            // textBoxSearchUser
            // 
            this.textBoxSearchUser.Depth = 0;
            this.textBoxSearchUser.Hint = "";
            this.textBoxSearchUser.Location = new System.Drawing.Point(79, 190);
            this.textBoxSearchUser.MaxLength = 32767;
            this.textBoxSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.PasswordChar = '\0';
            this.textBoxSearchUser.SelectedText = "";
            this.textBoxSearchUser.SelectionLength = 0;
            this.textBoxSearchUser.SelectionStart = 0;
            this.textBoxSearchUser.Size = new System.Drawing.Size(418, 25);
            this.textBoxSearchUser.TabIndex = 11;
            this.textBoxSearchUser.TabStop = false;
            this.textBoxSearchUser.UseSystemPasswordChar = false;
            this.textBoxSearchUser.TextChanged += new System.EventHandler(this.textBoxSearchUser_TextChanged);
            // 
            // buttonBan
            // 
            this.buttonBan.Depth = 0;
            this.buttonBan.Location = new System.Drawing.Point(79, 466);
            this.buttonBan.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(138, 31);
            this.buttonBan.TabIndex = 14;
            this.buttonBan.Text = "Ban";
            this.buttonBan.UseVisualStyleBackColor = true;
            this.buttonBan.Click += new System.EventHandler(this.buttonBan_Click);
            // 
            // labelCause
            // 
            this.labelCause.AutoSize = true;
            this.labelCause.Depth = 0;
            this.labelCause.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCause.Location = new System.Drawing.Point(76, 84);
            this.labelCause.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCause.Name = "labelCause";
            this.labelCause.Size = new System.Drawing.Size(56, 19);
            this.labelCause.TabIndex = 16;
            this.labelCause.Text = "Cause";
            // 
            // textBoxCause
            // 
            this.textBoxCause.Depth = 0;
            this.textBoxCause.Hint = "";
            this.textBoxCause.Location = new System.Drawing.Point(79, 116);
            this.textBoxCause.MaxLength = 32767;
            this.textBoxCause.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxCause.Name = "textBoxCause";
            this.textBoxCause.PasswordChar = '\0';
            this.textBoxCause.SelectedText = "";
            this.textBoxCause.SelectionLength = 0;
            this.textBoxCause.SelectionStart = 0;
            this.textBoxCause.Size = new System.Drawing.Size(418, 25);
            this.textBoxCause.TabIndex = 15;
            this.textBoxCause.TabStop = false;
            this.textBoxCause.UseSystemPasswordChar = false;
            this.textBoxCause.TextChanged += new System.EventHandler(this.textBoxCause_TextChanged);
            // 
            // BanUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 541);
            this.Controls.Add(this.labelCause);
            this.Controls.Add(this.textBoxCause);
            this.Controls.Add(this.buttonBan);
            this.Controls.Add(this.listViewSearchUsers);
            this.Controls.Add(this.labelSearchUser);
            this.Controls.Add(this.textBoxSearchUser);
            this.Name = "BanUserForm";
            this.Text = "BanUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private MaterialSkin.Controls.MaterialLabel labelSearchUser;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxSearchUser;
        private MaterialSkin.Controls.MaterialLabel labelCause;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxCause;
        private MaterialSkin.Controls.MaterialRaisedButton buttonBan;
        private MaterialSkin.Controls.MaterialListView listViewSearchUsers;
    }
}