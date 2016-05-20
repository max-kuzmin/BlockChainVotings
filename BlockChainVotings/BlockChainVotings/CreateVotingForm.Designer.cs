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
            this.buttonCreateVoting = new System.Windows.Forms.Button();
            this.labelVotingName = new System.Windows.Forms.Label();
            this.textBoxVotingName = new System.Windows.Forms.TextBox();
            this.textBoxSearchUser = new System.Windows.Forms.TextBox();
            this.labelSearchUser = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonRemoveUser = new System.Windows.Forms.Button();
            this.labelCandidates = new System.Windows.Forms.Label();
            this.listViewSearchUsers = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCandidates = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonCreateVoting
            // 
            this.buttonCreateVoting.Location = new System.Drawing.Point(228, 302);
            this.buttonCreateVoting.Name = "buttonCreateVoting";
            this.buttonCreateVoting.Size = new System.Drawing.Size(138, 31);
            this.buttonCreateVoting.TabIndex = 0;
            this.buttonCreateVoting.Text = "Create voting";
            this.buttonCreateVoting.UseVisualStyleBackColor = true;
            this.buttonCreateVoting.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelVotingName
            // 
            this.labelVotingName.AutoSize = true;
            this.labelVotingName.Location = new System.Drawing.Point(45, 39);
            this.labelVotingName.Name = "labelVotingName";
            this.labelVotingName.Size = new System.Drawing.Size(85, 17);
            this.labelVotingName.TabIndex = 1;
            this.labelVotingName.Text = "VotingName";
            // 
            // textBoxVotingName
            // 
            this.textBoxVotingName.Location = new System.Drawing.Point(136, 36);
            this.textBoxVotingName.Name = "textBoxVotingName";
            this.textBoxVotingName.Size = new System.Drawing.Size(413, 22);
            this.textBoxVotingName.TabIndex = 2;
            this.textBoxVotingName.TextChanged += new System.EventHandler(this.textBoxVotingName_TextChanged);
            // 
            // textBoxSearchUser
            // 
            this.textBoxSearchUser.Location = new System.Drawing.Point(48, 105);
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.Size = new System.Drawing.Size(218, 22);
            this.textBoxSearchUser.TabIndex = 4;
            this.textBoxSearchUser.TextChanged += new System.EventHandler(this.textBoxSearchUser_TextChanged);
            // 
            // labelSearchUser
            // 
            this.labelSearchUser.AutoSize = true;
            this.labelSearchUser.Location = new System.Drawing.Point(45, 85);
            this.labelSearchUser.Name = "labelSearchUser";
            this.labelSearchUser.Size = new System.Drawing.Size(83, 17);
            this.labelSearchUser.TabIndex = 5;
            this.labelSearchUser.Text = "SearchUser";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(278, 176);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(34, 23);
            this.buttonAddUser.TabIndex = 7;
            this.buttonAddUser.Text = "=>";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Location = new System.Drawing.Point(278, 205);
            this.buttonRemoveUser.Name = "buttonRemoveUser";
            this.buttonRemoveUser.Size = new System.Drawing.Size(34, 23);
            this.buttonRemoveUser.TabIndex = 8;
            this.buttonRemoveUser.Text = "<=";
            this.buttonRemoveUser.UseVisualStyleBackColor = true;
            this.buttonRemoveUser.Click += new System.EventHandler(this.buttonRemoveUser_Click);
            // 
            // labelCandidates
            // 
            this.labelCandidates.AutoSize = true;
            this.labelCandidates.Location = new System.Drawing.Point(328, 134);
            this.labelCandidates.Name = "labelCandidates";
            this.labelCandidates.Size = new System.Drawing.Size(79, 17);
            this.labelCandidates.TabIndex = 9;
            this.labelCandidates.Text = "Candidates";
            // 
            // listViewSearchUsers
            // 
            this.listViewSearchUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewSearchUsers.Location = new System.Drawing.Point(48, 157);
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.Size = new System.Drawing.Size(218, 97);
            this.listViewSearchUsers.TabIndex = 10;
            this.listViewSearchUsers.UseCompatibleStateImageBehavior = false;
            this.listViewSearchUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hash";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            // 
            // listViewCandidates
            // 
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewCandidates.Location = new System.Drawing.Point(331, 157);
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.Size = new System.Drawing.Size(218, 97);
            this.listViewCandidates.TabIndex = 11;
            this.listViewCandidates.UseCompatibleStateImageBehavior = false;
            this.listViewCandidates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Hash";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            // 
            // CreateVotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 359);
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
            this.Name = "CreateVotingForm";
            this.Text = "CreateVoting";
            this.Load += new System.EventHandler(this.CreateVotingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateVoting;
        private System.Windows.Forms.Label labelVotingName;
        private System.Windows.Forms.TextBox textBoxVotingName;
        private System.Windows.Forms.TextBox textBoxSearchUser;
        private System.Windows.Forms.Label labelSearchUser;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonRemoveUser;
        private System.Windows.Forms.Label labelCandidates;
        private System.Windows.Forms.ListView listViewSearchUsers;
        private System.Windows.Forms.ListView listViewCandidates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}