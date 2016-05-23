namespace BlockChainVotings
{
    partial class SendVoteForm
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
            this.labelChooseVoting = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxVoting = new MaterialSkin.Controls.MaterialListBox();
            this.buttonVote = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelCandidate = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateName = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateInfo = new MaterialSkin.Controls.MaterialLabel();
            this.checkBoxAgree = new MaterialSkin.Controls.MaterialCheckBox();
            this.labelVotingName = new MaterialSkin.Controls.MaterialLabel();
            this.labelVotingInfo = new MaterialSkin.Controls.MaterialLabel();
            this.listViewCandidates = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // labelChooseVoting
            // 
            this.labelChooseVoting.AutoSize = true;
            this.labelChooseVoting.Depth = 0;
            this.labelChooseVoting.Font = new System.Drawing.Font("Arial", 10F);
            this.labelChooseVoting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelChooseVoting.Location = new System.Drawing.Point(677, 88);
            this.labelChooseVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelChooseVoting.Name = "labelChooseVoting";
            this.labelChooseVoting.Size = new System.Drawing.Size(112, 19);
            this.labelChooseVoting.TabIndex = 0;
            this.labelChooseVoting.Text = "Choose voting";
            // 
            // comboBoxVoting
            // 
            this.comboBoxVoting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxVoting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBoxVoting.Depth = 0;
            this.comboBoxVoting.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxVoting.FormattingEnabled = true;
            this.comboBoxVoting.Location = new System.Drawing.Point(620, 138);
            this.comboBoxVoting.MouseLocation = new System.Drawing.Point(-1, -1);
            this.comboBoxVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.comboBoxVoting.Name = "comboBoxVoting";
            this.comboBoxVoting.Size = new System.Drawing.Size(413, 232);
            this.comboBoxVoting.TabIndex = 1;
            this.comboBoxVoting.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoting_TextUpdate);
            // 
            // buttonVote
            // 
            this.buttonVote.Depth = 0;
            this.buttonVote.Location = new System.Drawing.Point(266, 532);
            this.buttonVote.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonVote.Name = "buttonVote";
            this.buttonVote.Size = new System.Drawing.Size(75, 23);
            this.buttonVote.TabIndex = 3;
            this.buttonVote.Text = "Vote";
            this.buttonVote.UseVisualStyleBackColor = true;
            this.buttonVote.Click += new System.EventHandler(this.buttonVote_Click);
            // 
            // labelCandidate
            // 
            this.labelCandidate.AutoSize = true;
            this.labelCandidate.Depth = 0;
            this.labelCandidate.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidate.Location = new System.Drawing.Point(104, 158);
            this.labelCandidate.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidate.Name = "labelCandidate";
            this.labelCandidate.Size = new System.Drawing.Size(141, 19);
            this.labelCandidate.TabIndex = 4;
            this.labelCandidate.Text = "Choose candidate";
            // 
            // labelCandidateName
            // 
            this.labelCandidateName.Depth = 0;
            this.labelCandidateName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateName.Location = new System.Drawing.Point(96, 416);
            this.labelCandidateName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateName.Name = "labelCandidateName";
            this.labelCandidateName.Size = new System.Drawing.Size(404, 55);
            this.labelCandidateName.TabIndex = 4;
            this.labelCandidateName.Text = "...";
            this.labelCandidateName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCandidateInfo
            // 
            this.labelCandidateInfo.Depth = 0;
            this.labelCandidateInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateInfo.Location = new System.Drawing.Point(96, 382);
            this.labelCandidateInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateInfo.Name = "labelCandidateInfo";
            this.labelCandidateInfo.Size = new System.Drawing.Size(404, 23);
            this.labelCandidateInfo.TabIndex = 3;
            this.labelCandidateInfo.Text = "Я отдаю свой голос за кандидата";
            this.labelCandidateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxAgree
            // 
            this.checkBoxAgree.AutoSize = true;
            this.checkBoxAgree.Depth = 0;
            this.checkBoxAgree.Font = new System.Drawing.Font("Arial", 10F);
            this.checkBoxAgree.Location = new System.Drawing.Point(246, 481);
            this.checkBoxAgree.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAgree.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxAgree.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxAgree.Name = "checkBoxAgree";
            this.checkBoxAgree.Ripple = true;
            this.checkBoxAgree.Size = new System.Drawing.Size(106, 30);
            this.checkBoxAgree.TabIndex = 2;
            this.checkBoxAgree.Text = "Согласен";
            this.checkBoxAgree.UseVisualStyleBackColor = true;
            this.checkBoxAgree.CheckedChanged += new System.EventHandler(this.checkBoxAgree_CheckedChanged);
            // 
            // labelVotingName
            // 
            this.labelVotingName.Depth = 0;
            this.labelVotingName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingName.Location = new System.Drawing.Point(96, 343);
            this.labelVotingName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingName.Name = "labelVotingName";
            this.labelVotingName.Size = new System.Drawing.Size(404, 23);
            this.labelVotingName.TabIndex = 1;
            this.labelVotingName.Text = "...";
            this.labelVotingName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVotingInfo
            // 
            this.labelVotingInfo.Depth = 0;
            this.labelVotingInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingInfo.Location = new System.Drawing.Point(93, 307);
            this.labelVotingInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingInfo.Name = "labelVotingInfo";
            this.labelVotingInfo.Size = new System.Drawing.Size(407, 27);
            this.labelVotingInfo.TabIndex = 0;
            this.labelVotingInfo.Text = "Принимая участие в голосовании";
            this.labelVotingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewCandidates
            // 
            this.listViewCandidates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader4});
            this.listViewCandidates.Depth = 0;
            this.listViewCandidates.FullRowSelect = true;
            this.listViewCandidates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCandidates.HideSelection = false;
            this.listViewCandidates.Location = new System.Drawing.Point(107, 178);
            this.listViewCandidates.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewCandidates.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewCandidates.MultiSelect = false;
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.OwnerDraw = true;
            this.listViewCandidates.Size = new System.Drawing.Size(413, 97);
            this.listViewCandidates.TabIndex = 11;
            this.listViewCandidates.UseCompatibleStateImageBehavior = false;
            this.listViewCandidates.View = System.Windows.Forms.View.Details;
            this.listViewCandidates.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewCandidates_ItemSelectionChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hash";
            // 
            // SendVoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 602);
            this.Controls.Add(this.labelCandidateName);
            this.Controls.Add(this.listViewCandidates);
            this.Controls.Add(this.labelCandidateInfo);
            this.Controls.Add(this.checkBoxAgree);
            this.Controls.Add(this.labelCandidate);
            this.Controls.Add(this.labelVotingName);
            this.Controls.Add(this.buttonVote);
            this.Controls.Add(this.labelVotingInfo);
            this.Controls.Add(this.comboBoxVoting);
            this.Controls.Add(this.labelChooseVoting);
            this.Name = "SendVoteForm";
            this.Text = "SendVoteForm";
            this.Load += new System.EventHandler(this.SendVoteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel labelChooseVoting;
        private MaterialSkin.Controls.MaterialListBox comboBoxVoting;
        private MaterialSkin.Controls.MaterialRaisedButton buttonVote;
        private MaterialSkin.Controls.MaterialLabel labelCandidate;
        private MaterialSkin.Controls.MaterialLabel labelCandidateName;
        private MaterialSkin.Controls.MaterialLabel labelCandidateInfo;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxAgree;
        private MaterialSkin.Controls.MaterialLabel labelVotingName;
        private MaterialSkin.Controls.MaterialLabel labelVotingInfo;
        private MaterialSkin.Controls.MaterialListView listViewCandidates;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}