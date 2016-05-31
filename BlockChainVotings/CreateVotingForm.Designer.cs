namespace BlockChainVotings
{
    partial class CreateVotingForm
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
            this.buttonCreateVoting = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelVotingName = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxVotingName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxSearchUser = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelSearchUser = new MaterialSkin.Controls.MaterialLabel();
            this.buttonAddUser = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonRemoveUser = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelCandidates = new MaterialSkin.Controls.MaterialLabel();
            this.listViewSearchUsers = new MaterialSkin.Controls.MaterialListView();
            this.columnHeaderUserHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialContextMenuStripUser = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewCandidates = new MaterialSkin.Controls.MaterialListView();
            this.columnHeaderCandidateHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCandidateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCandidateID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialContextMenuStripCandidate = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.materialContextMenuStripUser.SuspendLayout();
            this.materialContextMenuStripCandidate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateVoting
            // 
            this.buttonCreateVoting.Depth = 0;
            this.buttonCreateVoting.Location = new System.Drawing.Point(239, 674);
            this.buttonCreateVoting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCreateVoting.Name = "buttonCreateVoting";
            this.buttonCreateVoting.Size = new System.Drawing.Size(225, 34);
            this.buttonCreateVoting.TabIndex = 6;
            this.buttonCreateVoting.Text = "Create voting";
            this.buttonCreateVoting.UseVisualStyleBackColor = true;
            this.buttonCreateVoting.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelVotingName
            // 
            this.labelVotingName.AutoSize = true;
            this.labelVotingName.Depth = 0;
            this.labelVotingName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingName.Location = new System.Drawing.Point(79, 114);
            this.labelVotingName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingName.Name = "labelVotingName";
            this.labelVotingName.Size = new System.Drawing.Size(96, 19);
            this.labelVotingName.TabIndex = 1;
            this.labelVotingName.Text = "VotingName";
            // 
            // textBoxVotingName
            // 
            this.textBoxVotingName.Depth = 0;
            this.textBoxVotingName.Hint = "";
            this.textBoxVotingName.Location = new System.Drawing.Point(83, 146);
            this.textBoxVotingName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxVotingName.MaxLength = 32767;
            this.textBoxVotingName.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxVotingName.Name = "textBoxVotingName";
            this.textBoxVotingName.PasswordChar = '\0';
            this.textBoxVotingName.SelectedText = "";
            this.textBoxVotingName.SelectionLength = 0;
            this.textBoxVotingName.SelectionStart = 0;
            this.textBoxVotingName.Size = new System.Drawing.Size(560, 25);
            this.textBoxVotingName.TabIndex = 0;
            this.textBoxVotingName.TabStop = false;
            this.textBoxVotingName.UseSystemPasswordChar = false;
            this.textBoxVotingName.TextChanged += new System.EventHandler(this.textBoxVotingName_TextChanged);
            // 
            // textBoxSearchUser
            // 
            this.textBoxSearchUser.Depth = 0;
            this.textBoxSearchUser.Hint = "";
            this.textBoxSearchUser.Location = new System.Drawing.Point(83, 225);
            this.textBoxSearchUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearchUser.MaxLength = 32767;
            this.textBoxSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.PasswordChar = '\0';
            this.textBoxSearchUser.SelectedText = "";
            this.textBoxSearchUser.SelectionLength = 0;
            this.textBoxSearchUser.SelectionStart = 0;
            this.textBoxSearchUser.Size = new System.Drawing.Size(560, 25);
            this.textBoxSearchUser.TabIndex = 1;
            this.textBoxSearchUser.TabStop = false;
            this.textBoxSearchUser.UseSystemPasswordChar = false;
            this.textBoxSearchUser.TextChanged += new System.EventHandler(this.textBoxSearchUser_TextChanged);
            // 
            // labelSearchUser
            // 
            this.labelSearchUser.AutoSize = true;
            this.labelSearchUser.Depth = 0;
            this.labelSearchUser.Font = new System.Drawing.Font("Arial", 10F);
            this.labelSearchUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSearchUser.Location = new System.Drawing.Point(79, 193);
            this.labelSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSearchUser.Name = "labelSearchUser";
            this.labelSearchUser.Size = new System.Drawing.Size(96, 19);
            this.labelSearchUser.TabIndex = 5;
            this.labelSearchUser.Text = "SearchUser";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Depth = 0;
            this.buttonAddUser.Location = new System.Drawing.Point(295, 436);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(40, 30);
            this.buttonAddUser.TabIndex = 3;
            this.buttonAddUser.Text = "=>";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Depth = 0;
            this.buttonRemoveUser.Location = new System.Drawing.Point(375, 436);
            this.buttonRemoveUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRemoveUser.Name = "buttonRemoveUser";
            this.buttonRemoveUser.Size = new System.Drawing.Size(40, 30);
            this.buttonRemoveUser.TabIndex = 4;
            this.buttonRemoveUser.Text = "<=";
            this.buttonRemoveUser.UseVisualStyleBackColor = true;
            this.buttonRemoveUser.Click += new System.EventHandler(this.buttonRemoveUser_Click);
            // 
            // labelCandidates
            // 
            this.labelCandidates.AutoSize = true;
            this.labelCandidates.Depth = 0;
            this.labelCandidates.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidates.Location = new System.Drawing.Point(79, 455);
            this.labelCandidates.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidates.Name = "labelCandidates";
            this.labelCandidates.Size = new System.Drawing.Size(91, 19);
            this.labelCandidates.TabIndex = 9;
            this.labelCandidates.Text = "Candidates";
            // 
            // listViewSearchUsers
            // 
            this.listViewSearchUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSearchUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUserHash,
            this.columnHeaderUserName,
            this.columnHeaderUserID});
            this.listViewSearchUsers.ContextMenuStrip = this.materialContextMenuStripUser;
            this.listViewSearchUsers.Depth = 0;
            this.listViewSearchUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.listViewSearchUsers.FullRowSelect = true;
            this.listViewSearchUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSearchUsers.Location = new System.Drawing.Point(83, 268);
            this.listViewSearchUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewSearchUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewSearchUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.OwnerDraw = true;
            this.listViewSearchUsers.Size = new System.Drawing.Size(559, 150);
            this.listViewSearchUsers.TabIndex = 2;
            this.listViewSearchUsers.UseCompatibleStateImageBehavior = false;
            this.listViewSearchUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderUserHash
            // 
            this.columnHeaderUserHash.Text = "Hash";
            this.columnHeaderUserHash.Width = 100;
            // 
            // columnHeaderUserName
            // 
            this.columnHeaderUserName.Text = "Name";
            this.columnHeaderUserName.Width = 215;
            // 
            // columnHeaderUserID
            // 
            this.columnHeaderUserID.Text = "ID";
            this.columnHeaderUserID.Width = 100;
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
            this.materialContextMenuStripUser.Size = new System.Drawing.Size(119, 30);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 26);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // listViewCandidates
            // 
            this.listViewCandidates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCandidateHash,
            this.columnHeaderCandidateName,
            this.columnHeaderCandidateID});
            this.listViewCandidates.ContextMenuStrip = this.materialContextMenuStripCandidate;
            this.listViewCandidates.Depth = 0;
            this.listViewCandidates.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.listViewCandidates.FullRowSelect = true;
            this.listViewCandidates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCandidates.Location = new System.Drawing.Point(83, 485);
            this.listViewCandidates.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewCandidates.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewCandidates.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.OwnerDraw = true;
            this.listViewCandidates.Size = new System.Drawing.Size(559, 150);
            this.listViewCandidates.TabIndex = 5;
            this.listViewCandidates.UseCompatibleStateImageBehavior = false;
            this.listViewCandidates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCandidateHash
            // 
            this.columnHeaderCandidateHash.Text = "Hash";
            this.columnHeaderCandidateHash.Width = 100;
            // 
            // columnHeaderCandidateName
            // 
            this.columnHeaderCandidateName.Text = "Name";
            this.columnHeaderCandidateName.Width = 215;
            // 
            // columnHeaderCandidateID
            // 
            this.columnHeaderCandidateID.Text = "ID";
            this.columnHeaderCandidateID.Width = 100;
            // 
            // materialContextMenuStripCandidate
            // 
            this.materialContextMenuStripCandidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStripCandidate.Depth = 0;
            this.materialContextMenuStripCandidate.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStripCandidate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.materialContextMenuStripCandidate.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStripCandidate.Name = "materialContextMenuStripUser";
            this.materialContextMenuStripCandidate.Size = new System.Drawing.Size(119, 30);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 26);
            this.toolStripMenuItem2.Text = "Copy";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // CreateVotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 753);
            this.Controls.Add(this.listViewCandidates);
            this.Controls.Add(this.listViewSearchUsers);
            this.Controls.Add(this.labelCandidates);
            this.Controls.Add(this.buttonRemoveUser);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.labelSearchUser);
            this.Controls.Add(this.textBoxSearchUser);
            this.Controls.Add(this.textBoxVotingName);
            this.Controls.Add(this.labelVotingName);
            this.Controls.Add(this.buttonCreateVoting);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CreateVotingForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateVoting";
            this.materialContextMenuStripUser.ResumeLayout(false);
            this.materialContextMenuStripCandidate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton buttonCreateVoting;
        private MaterialSkin.Controls.MaterialLabel labelVotingName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxVotingName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxSearchUser;
        private MaterialSkin.Controls.MaterialLabel labelSearchUser;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddUser;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRemoveUser;
        private MaterialSkin.Controls.MaterialLabel labelCandidates;
        private MaterialSkin.Controls.MaterialListView listViewSearchUsers;
        private MaterialSkin.Controls.MaterialListView listViewCandidates;
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateHash;
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateName;
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateID;
        private System.Windows.Forms.ColumnHeader columnHeaderUserHash;
        private System.Windows.Forms.ColumnHeader columnHeaderUserName;
        private System.Windows.Forms.ColumnHeader columnHeaderUserID;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStripUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStripCandidate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}