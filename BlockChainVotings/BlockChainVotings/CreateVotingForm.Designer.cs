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
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCandidates = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonCreateVoting
            // 
            this.buttonCreateVoting.Depth = 0;
            this.buttonCreateVoting.Location = new System.Drawing.Point(180, 363);
            this.buttonCreateVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCreateVoting.Name = "buttonCreateVoting";
            this.buttonCreateVoting.Size = new System.Drawing.Size(225, 31);
            this.buttonCreateVoting.TabIndex = 0;
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
            this.labelVotingName.Location = new System.Drawing.Point(41, 102);
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
            this.textBoxVotingName.Location = new System.Drawing.Point(132, 99);
            this.textBoxVotingName.MaxLength = 32767;
            this.textBoxVotingName.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxVotingName.Name = "textBoxVotingName";
            this.textBoxVotingName.PasswordChar = '\0';
            this.textBoxVotingName.SelectedText = "";
            this.textBoxVotingName.SelectionLength = 0;
            this.textBoxVotingName.SelectionStart = 0;
            this.textBoxVotingName.Size = new System.Drawing.Size(413, 25);
            this.textBoxVotingName.TabIndex = 2;
            this.textBoxVotingName.TabStop = false;
            this.textBoxVotingName.UseSystemPasswordChar = false;
            this.textBoxVotingName.TextChanged += new System.EventHandler(this.textBoxVotingName_TextChanged);
            // 
            // textBoxSearchUser
            // 
            this.textBoxSearchUser.Depth = 0;
            this.textBoxSearchUser.Hint = "";
            this.textBoxSearchUser.Location = new System.Drawing.Point(44, 168);
            this.textBoxSearchUser.MaxLength = 32767;
            this.textBoxSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.PasswordChar = '\0';
            this.textBoxSearchUser.SelectedText = "";
            this.textBoxSearchUser.SelectionLength = 0;
            this.textBoxSearchUser.SelectionStart = 0;
            this.textBoxSearchUser.Size = new System.Drawing.Size(218, 25);
            this.textBoxSearchUser.TabIndex = 4;
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
            this.labelSearchUser.Location = new System.Drawing.Point(41, 148);
            this.labelSearchUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSearchUser.Name = "labelSearchUser";
            this.labelSearchUser.Size = new System.Drawing.Size(96, 19);
            this.labelSearchUser.TabIndex = 5;
            this.labelSearchUser.Text = "SearchUser";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Depth = 0;
            this.buttonAddUser.Location = new System.Drawing.Point(274, 239);
            this.buttonAddUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(34, 23);
            this.buttonAddUser.TabIndex = 7;
            this.buttonAddUser.Text = "=>";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Depth = 0;
            this.buttonRemoveUser.Location = new System.Drawing.Point(274, 268);
            this.buttonRemoveUser.MouseState = MaterialSkin.MouseState.HOVER;
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
            this.labelCandidates.Depth = 0;
            this.labelCandidates.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidates.Location = new System.Drawing.Point(324, 197);
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
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewSearchUsers.Depth = 0;
            this.listViewSearchUsers.FullRowSelect = true;
            this.listViewSearchUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSearchUsers.Location = new System.Drawing.Point(44, 220);
            this.listViewSearchUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewSearchUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.OwnerDraw = true;
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
            this.listViewCandidates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewCandidates.Depth = 0;
            this.listViewCandidates.FullRowSelect = true;
            this.listViewCandidates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCandidates.Location = new System.Drawing.Point(327, 220);
            this.listViewCandidates.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewCandidates.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.OwnerDraw = true;
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
            this.ClientSize = new System.Drawing.Size(591, 446);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}