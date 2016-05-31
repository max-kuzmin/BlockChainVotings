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
            this.columnHeaderHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialContextMenuStripUser = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSearchUser = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxSearchUser = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonBan = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelCause = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxCause = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialContextMenuStripUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSearchUsers
            // 
            this.listViewSearchUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSearchUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHash,
            this.columnHeaderName,
            this.columnHeaderId});
            this.listViewSearchUsers.ContextMenuStrip = this.materialContextMenuStripUser;
            this.listViewSearchUsers.Depth = 0;
            this.listViewSearchUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.listViewSearchUsers.FullRowSelect = true;
            this.listViewSearchUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSearchUsers.LabelWrap = false;
            this.listViewSearchUsers.Location = new System.Drawing.Point(76, 180);
            this.listViewSearchUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewSearchUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewSearchUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewSearchUsers.MultiSelect = false;
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.OwnerDraw = true;
            this.listViewSearchUsers.Size = new System.Drawing.Size(559, 190);
            this.listViewSearchUsers.TabIndex = 1;
            this.listViewSearchUsers.UseCompatibleStateImageBehavior = false;
            this.listViewSearchUsers.View = System.Windows.Forms.View.Details;
            this.listViewSearchUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewSearchUsers_ItemSelectionChanged);
            // 
            // columnHeaderHash
            // 
            this.columnHeaderHash.Text = "Hash";
            this.columnHeaderHash.Width = 100;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 215;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 100;
            // 
            // materialContextMenuStripUser
            // 
            this.materialContextMenuStripUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStripUser.Depth = 0;
            this.materialContextMenuStripUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStripUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.materialContextMenuStripUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStripUser.Name = "materialContextMenuStripUser";
            this.materialContextMenuStripUser.Size = new System.Drawing.Size(113, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 24);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // labelSearchUser
            // 
            this.labelSearchUser.AutoSize = true;
            this.labelSearchUser.Depth = 0;
            this.labelSearchUser.Font = new System.Drawing.Font("Arial", 10F);
            this.labelSearchUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSearchUser.Location = new System.Drawing.Point(72, 108);
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
            this.textBoxSearchUser.Location = new System.Drawing.Point(76, 139);
            this.textBoxSearchUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearchUser.MaxLength = 32767;
            this.textBoxSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.PasswordChar = '\0';
            this.textBoxSearchUser.SelectedText = "";
            this.textBoxSearchUser.SelectionLength = 0;
            this.textBoxSearchUser.SelectionStart = 0;
            this.textBoxSearchUser.Size = new System.Drawing.Size(560, 25);
            this.textBoxSearchUser.TabIndex = 11;
            this.textBoxSearchUser.TabStop = false;
            this.textBoxSearchUser.UseSystemPasswordChar = false;
            this.textBoxSearchUser.TextChanged += new System.EventHandler(this.textBoxSearchUser_TextChanged);
            // 
            // buttonBan
            // 
            this.buttonBan.Depth = 0;
            this.buttonBan.Location = new System.Drawing.Point(255, 512);
            this.buttonBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBan.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(184, 34);
            this.buttonBan.TabIndex = 3;
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
            this.labelCause.Location = new System.Drawing.Point(73, 418);
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
            this.textBoxCause.Location = new System.Drawing.Point(76, 449);
            this.textBoxCause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCause.MaxLength = 32767;
            this.textBoxCause.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxCause.Name = "textBoxCause";
            this.textBoxCause.PasswordChar = '\0';
            this.textBoxCause.SelectedText = "";
            this.textBoxCause.SelectionLength = 0;
            this.textBoxCause.SelectionStart = 0;
            this.textBoxCause.Size = new System.Drawing.Size(560, 25);
            this.textBoxCause.TabIndex = 2;
            this.textBoxCause.TabStop = false;
            this.textBoxCause.UseSystemPasswordChar = false;
            this.textBoxCause.TextChanged += new System.EventHandler(this.textBoxCause_TextChanged);
            // 
            // BanUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 578);
            this.Controls.Add(this.labelCause);
            this.Controls.Add(this.textBoxCause);
            this.Controls.Add(this.buttonBan);
            this.Controls.Add(this.listViewSearchUsers);
            this.Controls.Add(this.labelSearchUser);
            this.Controls.Add(this.textBoxSearchUser);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "BanUserForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BanUserForm";
            this.materialContextMenuStripUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeaderHash;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private MaterialSkin.Controls.MaterialLabel labelSearchUser;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxSearchUser;
        private MaterialSkin.Controls.MaterialLabel labelCause;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxCause;
        private MaterialSkin.Controls.MaterialRaisedButton buttonBan;
        private MaterialSkin.Controls.MaterialListView listViewSearchUsers;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStripUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}