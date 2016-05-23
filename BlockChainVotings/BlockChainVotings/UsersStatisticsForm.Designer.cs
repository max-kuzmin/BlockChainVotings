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
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSearchUsers = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxSearchUsers = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.listViewVotings = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.listViewSearchUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewSearchUsers.Location = new System.Drawing.Point(61, 167);
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.Size = new System.Drawing.Size(398, 97);
            this.listViewSearchUsers.TabIndex = 13;
            this.listViewSearchUsers.UseCompatibleStateImageBehavior = false;
            this.listViewSearchUsers.View = System.Windows.Forms.View.Details;
            this.listViewSearchUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewSearchUsers_ItemSelectionChanged);
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
            // labelSearchUsers
            // 
            this.labelSearchUsers.AutoSize = true;
            this.labelSearchUsers.Location = new System.Drawing.Point(58, 95);
            this.labelSearchUsers.Name = "labelSearchUsers";
            this.labelSearchUsers.Size = new System.Drawing.Size(90, 17);
            this.labelSearchUsers.TabIndex = 12;
            this.labelSearchUsers.Text = "SearchUsers";
            // 
            // textBoxSearchUsers
            // 
            this.textBoxSearchUsers.Location = new System.Drawing.Point(61, 115);
            this.textBoxSearchUsers.Name = "textBoxSearchUsers";
            this.textBoxSearchUsers.Size = new System.Drawing.Size(398, 22);
            this.textBoxSearchUsers.TabIndex = 11;
            this.textBoxSearchUsers.TextChanged += new System.EventHandler(this.textBoxSearchUser_TextChanged);
            // 
            // listViewVotings
            // 
            this.listViewVotings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewVotings.Location = new System.Drawing.Point(61, 342);
            this.listViewVotings.Name = "listViewVotings";
            this.listViewVotings.Size = new System.Drawing.Size(448, 147);
            this.listViewVotings.TabIndex = 14;
            this.listViewVotings.UseCompatibleStateImageBehavior = false;
            this.listViewVotings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Voting Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Voting Hash";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Candidate Name";
            this.columnHeader3.Width = 124;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Candidate Hash";
            this.columnHeader7.Width = 62;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Date";
            // 
            // labelUserVotings
            // 
            this.labelUserVotings.AutoSize = true;
            this.labelUserVotings.Location = new System.Drawing.Point(58, 306);
            this.labelUserVotings.Name = "labelUserVotings";
            this.labelUserVotings.Size = new System.Drawing.Size(85, 17);
            this.labelUserVotings.TabIndex = 15;
            this.labelUserVotings.Text = "UserVotings";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(579, 141);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(21, 17);
            this.labelId.TabIndex = 16;
            this.labelId.Text = "ID";
            // 
            // labelIdVal
            // 
            this.labelIdVal.AutoSize = true;
            this.labelIdVal.Location = new System.Drawing.Point(707, 141);
            this.labelIdVal.Name = "labelIdVal";
            this.labelIdVal.Size = new System.Drawing.Size(20, 17);
            this.labelIdVal.TabIndex = 17;
            this.labelIdVal.Text = "...";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(579, 180);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 17);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Name";
            // 
            // labelNameVal
            // 
            this.labelNameVal.AutoSize = true;
            this.labelNameVal.Location = new System.Drawing.Point(707, 180);
            this.labelNameVal.Name = "labelNameVal";
            this.labelNameVal.Size = new System.Drawing.Size(20, 17);
            this.labelNameVal.TabIndex = 19;
            this.labelNameVal.Text = "...";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(579, 261);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(116, 17);
            this.labelDate.TabIndex = 20;
            this.labelDate.Text = "Registration date";
            // 
            // labelDateVal
            // 
            this.labelDateVal.AutoSize = true;
            this.labelDateVal.Location = new System.Drawing.Point(707, 261);
            this.labelDateVal.Name = "labelDateVal";
            this.labelDateVal.Size = new System.Drawing.Size(20, 17);
            this.labelDateVal.TabIndex = 21;
            this.labelDateVal.Text = "...";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(579, 303);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(48, 17);
            this.labelStatus.TabIndex = 22;
            this.labelStatus.Text = "Status";
            // 
            // labelStatusVal
            // 
            this.labelStatusVal.AutoSize = true;
            this.labelStatusVal.Location = new System.Drawing.Point(707, 303);
            this.labelStatusVal.Name = "labelStatusVal";
            this.labelStatusVal.Size = new System.Drawing.Size(20, 17);
            this.labelStatusVal.TabIndex = 23;
            this.labelStatusVal.Text = "...";
            // 
            // labelActivity
            // 
            this.labelActivity.AutoSize = true;
            this.labelActivity.Location = new System.Drawing.Point(579, 346);
            this.labelActivity.Name = "labelActivity";
            this.labelActivity.Size = new System.Drawing.Size(82, 17);
            this.labelActivity.TabIndex = 24;
            this.labelActivity.Text = "Last activity";
            // 
            // labelActivityVal
            // 
            this.labelActivityVal.AutoSize = true;
            this.labelActivityVal.Location = new System.Drawing.Point(707, 346);
            this.labelActivityVal.Name = "labelActivityVal";
            this.labelActivityVal.Size = new System.Drawing.Size(20, 17);
            this.labelActivityVal.TabIndex = 25;
            this.labelActivityVal.Text = "...";
            // 
            // labelHash
            // 
            this.labelHash.AutoSize = true;
            this.labelHash.Location = new System.Drawing.Point(579, 219);
            this.labelHash.Name = "labelHash";
            this.labelHash.Size = new System.Drawing.Size(41, 17);
            this.labelHash.TabIndex = 26;
            this.labelHash.Text = "Hash";
            // 
            // labelHashVal
            // 
            this.labelHashVal.AutoSize = true;
            this.labelHashVal.Location = new System.Drawing.Point(707, 219);
            this.labelHashVal.Name = "labelHashVal";
            this.labelHashVal.Size = new System.Drawing.Size(20, 17);
            this.labelHashVal.TabIndex = 27;
            this.labelHashVal.Text = "...";
            // 
            // labelNumVotesVal
            // 
            this.labelNumVotesVal.AutoSize = true;
            this.labelNumVotesVal.Location = new System.Drawing.Point(707, 390);
            this.labelNumVotesVal.Name = "labelNumVotesVal";
            this.labelNumVotesVal.Size = new System.Drawing.Size(20, 17);
            this.labelNumVotesVal.TabIndex = 29;
            this.labelNumVotesVal.Text = "...";
            // 
            // labelNumVotes
            // 
            this.labelNumVotes.AutoSize = true;
            this.labelNumVotes.Location = new System.Drawing.Point(579, 390);
            this.labelNumVotes.Name = "labelNumVotes";
            this.labelNumVotes.Size = new System.Drawing.Size(96, 17);
            this.labelNumVotes.TabIndex = 28;
            this.labelNumVotes.Text = "Votes number";
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Location = new System.Drawing.Point(621, 95);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(65, 17);
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
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private MaterialSkin.Controls.MaterialLabel labelSearchUsers;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxSearchUsers;
        private MaterialSkin.Controls.MaterialListView listViewVotings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
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
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}