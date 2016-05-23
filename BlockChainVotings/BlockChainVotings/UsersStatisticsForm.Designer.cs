namespace BlockChainVotings
{
    partial class UsersStatisticsForm
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
            this.labelSearchUsers = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxSearchUsers = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.listViewVotings = new MaterialSkin.Controls.MaterialListView();
            this.columnHeaderVotingName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVotingHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCandidateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCandidateHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelUserVotings = new MaterialSkin.Controls.MaterialLabel();
            this.labelId = new MaterialSkin.Controls.MaterialLabel();
            this.labelIdVal = new MaterialSkin.Controls.MaterialLabel();
            this.labelName = new MaterialSkin.Controls.MaterialLabel();
            this.labelNameVal = new MaterialSkin.Controls.MaterialLabel();
            this.labelDate = new MaterialSkin.Controls.MaterialLabel();
            this.labelDateVal = new MaterialSkin.Controls.MaterialLabel();
            this.labelStatus = new MaterialSkin.Controls.MaterialLabel();
            this.labelStatusVal = new MaterialSkin.Controls.MaterialLabel();
            this.labelActivity = new MaterialSkin.Controls.MaterialLabel();
            this.labelActivityVal = new MaterialSkin.Controls.MaterialLabel();
            this.labelHash = new MaterialSkin.Controls.MaterialLabel();
            this.labelHashVal = new MaterialSkin.Controls.MaterialLabel();
            this.labelNumVotesVal = new MaterialSkin.Controls.MaterialLabel();
            this.labelNumVotes = new MaterialSkin.Controls.MaterialLabel();
            this.labelUserInfo = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // listViewSearchUsers
            // 
            this.listViewSearchUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSearchUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHash,
            this.columnHeaderName,
            this.columnHeaderId});
            this.listViewSearchUsers.Depth = 0;
            this.listViewSearchUsers.FullRowSelect = true;
            this.listViewSearchUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSearchUsers.Location = new System.Drawing.Point(61, 167);
            this.listViewSearchUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewSearchUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.OwnerDraw = true;
            this.listViewSearchUsers.Size = new System.Drawing.Size(398, 97);
            this.listViewSearchUsers.TabIndex = 13;
            this.listViewSearchUsers.UseCompatibleStateImageBehavior = false;
            this.listViewSearchUsers.View = System.Windows.Forms.View.Details;
            this.listViewSearchUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewSearchUsers_ItemSelectionChanged);
            // 
            // columnHeaderHash
            // 
            this.columnHeaderHash.Text = "Hash";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            // 
            // labelSearchUsers
            // 
            this.labelSearchUsers.AutoSize = true;
            this.labelSearchUsers.Depth = 0;
            this.labelSearchUsers.Font = new System.Drawing.Font("Arial", 10F);
            this.labelSearchUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSearchUsers.Location = new System.Drawing.Point(58, 95);
            this.labelSearchUsers.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSearchUsers.Name = "labelSearchUsers";
            this.labelSearchUsers.Size = new System.Drawing.Size(104, 19);
            this.labelSearchUsers.TabIndex = 12;
            this.labelSearchUsers.Text = "SearchUsers";
            // 
            // textBoxSearchUsers
            // 
            this.textBoxSearchUsers.Depth = 0;
            this.textBoxSearchUsers.Hint = "";
            this.textBoxSearchUsers.Location = new System.Drawing.Point(61, 115);
            this.textBoxSearchUsers.MaxLength = 32767;
            this.textBoxSearchUsers.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxSearchUsers.Name = "textBoxSearchUsers";
            this.textBoxSearchUsers.PasswordChar = '\0';
            this.textBoxSearchUsers.SelectedText = "";
            this.textBoxSearchUsers.SelectionLength = 0;
            this.textBoxSearchUsers.SelectionStart = 0;
            this.textBoxSearchUsers.Size = new System.Drawing.Size(398, 25);
            this.textBoxSearchUsers.TabIndex = 11;
            this.textBoxSearchUsers.TabStop = false;
            this.textBoxSearchUsers.UseSystemPasswordChar = false;
            this.textBoxSearchUsers.TextChanged += new System.EventHandler(this.textBoxSearchUser_TextChanged);
            // 
            // listViewVotings
            // 
            this.listViewVotings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewVotings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderVotingName,
            this.columnHeaderVotingHash,
            this.columnHeaderCandidateName,
            this.columnHeaderCandidateHash,
            this.columnHeaderDate});
            this.listViewVotings.Depth = 0;
            this.listViewVotings.FullRowSelect = true;
            this.listViewVotings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewVotings.Location = new System.Drawing.Point(61, 342);
            this.listViewVotings.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewVotings.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewVotings.Name = "listViewVotings";
            this.listViewVotings.OwnerDraw = true;
            this.listViewVotings.Size = new System.Drawing.Size(448, 147);
            this.listViewVotings.TabIndex = 14;
            this.listViewVotings.UseCompatibleStateImageBehavior = false;
            this.listViewVotings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderVotingName
            // 
            this.columnHeaderVotingName.Text = "Voting Name";
            this.columnHeaderVotingName.Width = 100;
            // 
            // columnHeaderVotingHash
            // 
            this.columnHeaderVotingHash.Text = "Voting Hash";
            this.columnHeaderVotingHash.Width = 91;
            // 
            // columnHeaderCandidateName
            // 
            this.columnHeaderCandidateName.Text = "Candidate Name";
            this.columnHeaderCandidateName.Width = 124;
            // 
            // columnHeaderCandidateHash
            // 
            this.columnHeaderCandidateHash.Text = "Candidate Hash";
            this.columnHeaderCandidateHash.Width = 62;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            // 
            // labelUserVotings
            // 
            this.labelUserVotings.AutoSize = true;
            this.labelUserVotings.Depth = 0;
            this.labelUserVotings.Font = new System.Drawing.Font("Arial", 10F);
            this.labelUserVotings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelUserVotings.Location = new System.Drawing.Point(58, 306);
            this.labelUserVotings.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelUserVotings.Name = "labelUserVotings";
            this.labelUserVotings.Size = new System.Drawing.Size(96, 19);
            this.labelUserVotings.TabIndex = 15;
            this.labelUserVotings.Text = "UserVotings";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Depth = 0;
            this.labelId.Font = new System.Drawing.Font("Arial", 10F);
            this.labelId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelId.Location = new System.Drawing.Point(579, 141);
            this.labelId.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(26, 19);
            this.labelId.TabIndex = 16;
            this.labelId.Text = "ID";
            // 
            // labelIdVal
            // 
            this.labelIdVal.AutoSize = true;
            this.labelIdVal.Depth = 0;
            this.labelIdVal.Font = new System.Drawing.Font("Arial", 10F);
            this.labelIdVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelIdVal.Location = new System.Drawing.Point(707, 141);
            this.labelIdVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelIdVal.Name = "labelIdVal";
            this.labelIdVal.Size = new System.Drawing.Size(24, 19);
            this.labelIdVal.TabIndex = 17;
            this.labelIdVal.Text = "...";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Depth = 0;
            this.labelName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelName.Location = new System.Drawing.Point(579, 180);
            this.labelName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 19);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Name";
            // 
            // labelNameVal
            // 
            this.labelNameVal.AutoSize = true;
            this.labelNameVal.Depth = 0;
            this.labelNameVal.Font = new System.Drawing.Font("Arial", 10F);
            this.labelNameVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNameVal.Location = new System.Drawing.Point(707, 180);
            this.labelNameVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelNameVal.Name = "labelNameVal";
            this.labelNameVal.Size = new System.Drawing.Size(24, 19);
            this.labelNameVal.TabIndex = 19;
            this.labelNameVal.Text = "...";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Depth = 0;
            this.labelDate.Font = new System.Drawing.Font("Arial", 10F);
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDate.Location = new System.Drawing.Point(579, 261);
            this.labelDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(131, 19);
            this.labelDate.TabIndex = 20;
            this.labelDate.Text = "Registration date";
            // 
            // labelDateVal
            // 
            this.labelDateVal.AutoSize = true;
            this.labelDateVal.Depth = 0;
            this.labelDateVal.Font = new System.Drawing.Font("Arial", 10F);
            this.labelDateVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDateVal.Location = new System.Drawing.Point(707, 261);
            this.labelDateVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDateVal.Name = "labelDateVal";
            this.labelDateVal.Size = new System.Drawing.Size(24, 19);
            this.labelDateVal.TabIndex = 21;
            this.labelDateVal.Text = "...";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Depth = 0;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelStatus.Location = new System.Drawing.Point(579, 303);
            this.labelStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(54, 19);
            this.labelStatus.TabIndex = 22;
            this.labelStatus.Text = "Status";
            // 
            // labelStatusVal
            // 
            this.labelStatusVal.AutoSize = true;
            this.labelStatusVal.Depth = 0;
            this.labelStatusVal.Font = new System.Drawing.Font("Arial", 10F);
            this.labelStatusVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelStatusVal.Location = new System.Drawing.Point(707, 303);
            this.labelStatusVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelStatusVal.Name = "labelStatusVal";
            this.labelStatusVal.Size = new System.Drawing.Size(24, 19);
            this.labelStatusVal.TabIndex = 23;
            this.labelStatusVal.Text = "...";
            // 
            // labelActivity
            // 
            this.labelActivity.AutoSize = true;
            this.labelActivity.Depth = 0;
            this.labelActivity.Font = new System.Drawing.Font("Arial", 10F);
            this.labelActivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelActivity.Location = new System.Drawing.Point(579, 346);
            this.labelActivity.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelActivity.Name = "labelActivity";
            this.labelActivity.Size = new System.Drawing.Size(94, 19);
            this.labelActivity.TabIndex = 24;
            this.labelActivity.Text = "Last activity";
            // 
            // labelActivityVal
            // 
            this.labelActivityVal.AutoSize = true;
            this.labelActivityVal.Depth = 0;
            this.labelActivityVal.Font = new System.Drawing.Font("Arial", 10F);
            this.labelActivityVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelActivityVal.Location = new System.Drawing.Point(707, 346);
            this.labelActivityVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelActivityVal.Name = "labelActivityVal";
            this.labelActivityVal.Size = new System.Drawing.Size(24, 19);
            this.labelActivityVal.TabIndex = 25;
            this.labelActivityVal.Text = "...";
            // 
            // labelHash
            // 
            this.labelHash.AutoSize = true;
            this.labelHash.Depth = 0;
            this.labelHash.Font = new System.Drawing.Font("Arial", 10F);
            this.labelHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelHash.Location = new System.Drawing.Point(579, 219);
            this.labelHash.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelHash.Name = "labelHash";
            this.labelHash.Size = new System.Drawing.Size(46, 19);
            this.labelHash.TabIndex = 26;
            this.labelHash.Text = "Hash";
            // 
            // labelHashVal
            // 
            this.labelHashVal.AutoSize = true;
            this.labelHashVal.Depth = 0;
            this.labelHashVal.Font = new System.Drawing.Font("Arial", 10F);
            this.labelHashVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelHashVal.Location = new System.Drawing.Point(707, 219);
            this.labelHashVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelHashVal.Name = "labelHashVal";
            this.labelHashVal.Size = new System.Drawing.Size(24, 19);
            this.labelHashVal.TabIndex = 27;
            this.labelHashVal.Text = "...";
            // 
            // labelNumVotesVal
            // 
            this.labelNumVotesVal.AutoSize = true;
            this.labelNumVotesVal.Depth = 0;
            this.labelNumVotesVal.Font = new System.Drawing.Font("Arial", 10F);
            this.labelNumVotesVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNumVotesVal.Location = new System.Drawing.Point(707, 390);
            this.labelNumVotesVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelNumVotesVal.Name = "labelNumVotesVal";
            this.labelNumVotesVal.Size = new System.Drawing.Size(24, 19);
            this.labelNumVotesVal.TabIndex = 29;
            this.labelNumVotesVal.Text = "...";
            // 
            // labelNumVotes
            // 
            this.labelNumVotes.AutoSize = true;
            this.labelNumVotes.Depth = 0;
            this.labelNumVotes.Font = new System.Drawing.Font("Arial", 10F);
            this.labelNumVotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNumVotes.Location = new System.Drawing.Point(579, 390);
            this.labelNumVotes.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelNumVotes.Name = "labelNumVotes";
            this.labelNumVotes.Size = new System.Drawing.Size(109, 19);
            this.labelNumVotes.TabIndex = 28;
            this.labelNumVotes.Text = "Votes number";
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Depth = 0;
            this.labelUserInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelUserInfo.Location = new System.Drawing.Point(621, 95);
            this.labelUserInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(76, 19);
            this.labelUserInfo.TabIndex = 30;
            this.labelUserInfo.Text = "User Info";
            // 
            // UsersStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 578);
            this.Controls.Add(this.labelUserInfo);
            this.Controls.Add(this.labelNumVotesVal);
            this.Controls.Add(this.labelNumVotes);
            this.Controls.Add(this.labelHashVal);
            this.Controls.Add(this.labelHash);
            this.Controls.Add(this.labelActivityVal);
            this.Controls.Add(this.labelActivity);
            this.Controls.Add(this.labelStatusVal);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelDateVal);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelNameVal);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelIdVal);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelUserVotings);
            this.Controls.Add(this.listViewVotings);
            this.Controls.Add(this.listViewSearchUsers);
            this.Controls.Add(this.labelSearchUsers);
            this.Controls.Add(this.textBoxSearchUsers);
            this.Name = "UsersStatisticsForm";
            this.Text = "UsersStatisticsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView listViewSearchUsers;
        private System.Windows.Forms.ColumnHeader columnHeaderHash;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private MaterialSkin.Controls.MaterialLabel labelSearchUsers;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxSearchUsers;
        private MaterialSkin.Controls.MaterialListView listViewVotings;
        private System.Windows.Forms.ColumnHeader columnHeaderVotingName;
        private System.Windows.Forms.ColumnHeader columnHeaderVotingHash;
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateName;
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateHash;
        private MaterialSkin.Controls.MaterialLabel labelUserVotings;
        private MaterialSkin.Controls.MaterialLabel labelId;
        private MaterialSkin.Controls.MaterialLabel labelIdVal;
        private MaterialSkin.Controls.MaterialLabel labelName;
        private MaterialSkin.Controls.MaterialLabel labelNameVal;
        private MaterialSkin.Controls.MaterialLabel labelDate;
        private MaterialSkin.Controls.MaterialLabel labelDateVal;
        private MaterialSkin.Controls.MaterialLabel labelStatus;
        private MaterialSkin.Controls.MaterialLabel labelStatusVal;
        private MaterialSkin.Controls.MaterialLabel labelActivity;
        private MaterialSkin.Controls.MaterialLabel labelActivityVal;
        private MaterialSkin.Controls.MaterialLabel labelHash;
        private MaterialSkin.Controls.MaterialLabel labelHashVal;
        private MaterialSkin.Controls.MaterialLabel labelNumVotesVal;
        private MaterialSkin.Controls.MaterialLabel labelNumVotes;
        private MaterialSkin.Controls.MaterialLabel labelUserInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
    }
}