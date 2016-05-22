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
            this.labelChooseVoting = new System.Windows.Forms.Label();
            this.comboBoxVoting = new System.Windows.Forms.ComboBox();
            this.buttonVote = new System.Windows.Forms.Button();
            this.labelCandidate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCandidateName = new System.Windows.Forms.Label();
            this.labelCandidateInfo = new System.Windows.Forms.Label();
            this.checkBoxAgree = new System.Windows.Forms.CheckBox();
            this.labelVotingName = new System.Windows.Forms.Label();
            this.labelVotingInfo = new System.Windows.Forms.Label();
            this.listViewCandidates = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelChooseVoting
            // 
            this.labelChooseVoting.AutoSize = true;
            this.labelChooseVoting.Location = new System.Drawing.Point(104, 87);
            this.labelChooseVoting.Name = "labelChooseVoting";
            this.labelChooseVoting.Size = new System.Drawing.Size(98, 17);
            this.labelChooseVoting.TabIndex = 0;
            this.labelChooseVoting.Text = "Choose voting";
            // 
            // comboBoxVoting
            // 
            this.comboBoxVoting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoting.FormattingEnabled = true;
            this.comboBoxVoting.Location = new System.Drawing.Point(107, 107);
            this.comboBoxVoting.Name = "comboBoxVoting";
            this.comboBoxVoting.Size = new System.Drawing.Size(413, 24);
            this.comboBoxVoting.TabIndex = 1;
            this.comboBoxVoting.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoting_TextUpdate);
            // 
            // buttonVote
            // 
            this.buttonVote.Location = new System.Drawing.Point(266, 532);
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
            this.labelCandidate.Location = new System.Drawing.Point(104, 158);
            this.labelCandidate.Name = "labelCandidate";
            this.labelCandidate.Size = new System.Drawing.Size(122, 17);
            this.labelCandidate.TabIndex = 4;
            this.labelCandidate.Text = "Choose candidate";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCandidateName);
            this.panel1.Controls.Add(this.labelCandidateInfo);
            this.panel1.Controls.Add(this.checkBoxAgree);
            this.panel1.Controls.Add(this.labelVotingName);
            this.panel1.Controls.Add(this.labelVotingInfo);
            this.panel1.Location = new System.Drawing.Point(107, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 215);
            this.panel1.TabIndex = 5;
            // 
            // labelCandidateName
            // 
            this.labelCandidateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCandidateName.Location = new System.Drawing.Point(6, 119);
            this.labelCandidateName.Name = "labelCandidateName";
            this.labelCandidateName.Size = new System.Drawing.Size(404, 55);
            this.labelCandidateName.TabIndex = 4;
            this.labelCandidateName.Text = "...";
            this.labelCandidateName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCandidateInfo
            // 
            this.labelCandidateInfo.Location = new System.Drawing.Point(6, 85);
            this.labelCandidateInfo.Name = "labelCandidateInfo";
            this.labelCandidateInfo.Size = new System.Drawing.Size(404, 23);
            this.labelCandidateInfo.TabIndex = 3;
            this.labelCandidateInfo.Text = "Я отдаю свой голос за кандидата";
            this.labelCandidateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxAgree
            // 
            this.checkBoxAgree.AutoSize = true;
            this.checkBoxAgree.Location = new System.Drawing.Point(159, 177);
            this.checkBoxAgree.Name = "checkBoxAgree";
            this.checkBoxAgree.Size = new System.Drawing.Size(91, 21);
            this.checkBoxAgree.TabIndex = 2;
            this.checkBoxAgree.Text = "Согласен";
            this.checkBoxAgree.UseVisualStyleBackColor = true;
            this.checkBoxAgree.CheckedChanged += new System.EventHandler(this.checkBoxAgree_CheckedChanged);
            // 
            // labelVotingName
            // 
            this.labelVotingName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVotingName.Location = new System.Drawing.Point(6, 46);
            this.labelVotingName.Name = "labelVotingName";
            this.labelVotingName.Size = new System.Drawing.Size(404, 23);
            this.labelVotingName.TabIndex = 1;
            this.labelVotingName.Text = "...";
            this.labelVotingName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVotingInfo
            // 
            this.labelVotingInfo.Location = new System.Drawing.Point(3, 10);
            this.labelVotingInfo.Name = "labelVotingInfo";
            this.labelVotingInfo.Size = new System.Drawing.Size(407, 27);
            this.labelVotingInfo.TabIndex = 0;
            this.labelVotingInfo.Text = "Принимая участие в голосовании";
            this.labelVotingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewCandidates
            // 
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader4});
            this.listViewCandidates.FullRowSelect = true;
            this.listViewCandidates.HideSelection = false;
            this.listViewCandidates.Location = new System.Drawing.Point(107, 178);
            this.listViewCandidates.MultiSelect = false;
            this.listViewCandidates.Name = "listViewCandidates";
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
            this.ClientSize = new System.Drawing.Size(618, 602);
            this.Controls.Add(this.listViewCandidates);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelCandidate);
            this.Controls.Add(this.buttonVote);
            this.Controls.Add(this.comboBoxVoting);
            this.Controls.Add(this.labelChooseVoting);
            this.Name = "SendVoteForm";
            this.Text = "SendVoteForm";
            this.Load += new System.EventHandler(this.SendVoteForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChooseVoting;
        private System.Windows.Forms.ComboBox comboBoxVoting;
        private System.Windows.Forms.Button buttonVote;
        private System.Windows.Forms.Label labelCandidate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCandidateName;
        private System.Windows.Forms.Label labelCandidateInfo;
        private System.Windows.Forms.CheckBox checkBoxAgree;
        private System.Windows.Forms.Label labelVotingName;
        private System.Windows.Forms.Label labelVotingInfo;
        private System.Windows.Forms.ListView listViewCandidates;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}