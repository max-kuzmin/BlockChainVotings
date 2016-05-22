namespace BlockChainVotings
{
    partial class VotingsStatisticForm
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
            this.listViewCandidates = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelCandidates = new System.Windows.Forms.Label();
            this.comboBoxVoting = new System.Windows.Forms.ComboBox();
            this.labelChooseVoting = new System.Windows.Forms.Label();
            this.labelVotingInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCandidateName = new System.Windows.Forms.Label();
            this.labelCandidateInfo = new System.Windows.Forms.Label();
            this.labelVotingName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCandidates
            // 
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader7});
            this.listViewCandidates.FullRowSelect = true;
            this.listViewCandidates.HideSelection = false;
            this.listViewCandidates.Location = new System.Drawing.Point(77, 192);
            this.listViewCandidates.MultiSelect = false;
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.Size = new System.Drawing.Size(413, 97);
            this.listViewCandidates.TabIndex = 15;
            this.listViewCandidates.UseCompatibleStateImageBehavior = false;
            this.listViewCandidates.View = System.Windows.Forms.View.Details;
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
            // columnHeader7
            // 
            this.columnHeader7.Text = "Votes";
            // 
            // labelCandidates
            // 
            this.labelCandidates.AutoSize = true;
            this.labelCandidates.Location = new System.Drawing.Point(74, 172);
            this.labelCandidates.Name = "labelCandidates";
            this.labelCandidates.Size = new System.Drawing.Size(79, 17);
            this.labelCandidates.TabIndex = 14;
            this.labelCandidates.Text = "Сandidates";
            // 
            // comboBoxVoting
            // 
            this.comboBoxVoting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoting.FormattingEnabled = true;
            this.comboBoxVoting.Location = new System.Drawing.Point(77, 121);
            this.comboBoxVoting.Name = "comboBoxVoting";
            this.comboBoxVoting.Size = new System.Drawing.Size(413, 24);
            this.comboBoxVoting.TabIndex = 13;
            this.comboBoxVoting.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoting_SelectedIndexChanged);
            // 
            // labelChooseVoting
            // 
            this.labelChooseVoting.AutoSize = true;
            this.labelChooseVoting.Location = new System.Drawing.Point(74, 101);
            this.labelChooseVoting.Name = "labelChooseVoting";
            this.labelChooseVoting.Size = new System.Drawing.Size(98, 17);
            this.labelChooseVoting.TabIndex = 12;
            this.labelChooseVoting.Text = "Choose voting";
            // 
            // labelVotingInfo
            // 
            this.labelVotingInfo.Location = new System.Drawing.Point(3, 10);
            this.labelVotingInfo.Name = "labelVotingInfo";
            this.labelVotingInfo.Size = new System.Drawing.Size(407, 27);
            this.labelVotingInfo.TabIndex = 0;
            this.labelVotingInfo.Text = "В голосовании";
            this.labelVotingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCandidateName);
            this.panel1.Controls.Add(this.labelCandidateInfo);
            this.panel1.Controls.Add(this.labelVotingName);
            this.panel1.Controls.Add(this.labelVotingInfo);
            this.panel1.Location = new System.Drawing.Point(77, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 173);
            this.panel1.TabIndex = 16;
            // 
            // labelCandidateName
            // 
            this.labelCandidateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCandidateName.Location = new System.Drawing.Point(6, 127);
            this.labelCandidateName.Name = "labelCandidateName";
            this.labelCandidateName.Size = new System.Drawing.Size(404, 46);
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
            this.labelCandidateInfo.Text = "Побеждает";
            this.labelCandidateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // VotingsStatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 794);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewCandidates);
            this.Controls.Add(this.labelCandidates);
            this.Controls.Add(this.comboBoxVoting);
            this.Controls.Add(this.labelChooseVoting);
            this.Name = "VotingsStatisticForm";
            this.Text = "VotingsStatisticForm";
            this.Load += new System.EventHandler(this.VotingsStatisticForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewCandidates;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label labelCandidates;
        private System.Windows.Forms.ComboBox comboBoxVoting;
        private System.Windows.Forms.Label labelChooseVoting;
        private System.Windows.Forms.Label labelVotingInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCandidateName;
        private System.Windows.Forms.Label labelCandidateInfo;
        private System.Windows.Forms.Label labelVotingName;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}