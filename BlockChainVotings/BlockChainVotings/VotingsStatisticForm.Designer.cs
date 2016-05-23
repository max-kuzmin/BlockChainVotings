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
            this.listViewCandidates = new MaterialSkin.Controls.MaterialListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelCandidates = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxVoting = new MaterialSkin.Controls.MaterialListBox();
            this.labelChooseVoting = new MaterialSkin.Controls.MaterialLabel();
            this.labelVotingInfo = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateName = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateInfo = new MaterialSkin.Controls.MaterialLabel();
            this.labelVotingName = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // listViewCandidates
            // 
            this.listViewCandidates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderHash,
            this.columnHeaderVotes});
            this.listViewCandidates.Depth = 0;
            this.listViewCandidates.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.listViewCandidates.FullRowSelect = true;
            this.listViewCandidates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCandidates.HideSelection = false;
            this.listViewCandidates.Location = new System.Drawing.Point(604, 139);
            this.listViewCandidates.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewCandidates.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewCandidates.MultiSelect = false;
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.OwnerDraw = true;
            this.listViewCandidates.Size = new System.Drawing.Size(412, 159);
            this.listViewCandidates.TabIndex = 15;
            this.listViewCandidates.UseCompatibleStateImageBehavior = false;
            this.listViewCandidates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            // 
            // columnHeaderHash
            // 
            this.columnHeaderHash.Text = "Hash";
            // 
            // columnHeaderVotes
            // 
            this.columnHeaderVotes.Text = "Votes";
            // 
            // labelCandidates
            // 
            this.labelCandidates.AutoSize = true;
            this.labelCandidates.Depth = 0;
            this.labelCandidates.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidates.Location = new System.Drawing.Point(600, 101);
            this.labelCandidates.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidates.Name = "labelCandidates";
            this.labelCandidates.Size = new System.Drawing.Size(91, 19);
            this.labelCandidates.TabIndex = 14;
            this.labelCandidates.Text = "Сandidates";
            // 
            // comboBoxVoting
            // 
            this.comboBoxVoting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxVoting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comboBoxVoting.Depth = 0;
            this.comboBoxVoting.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxVoting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxVoting.FormattingEnabled = true;
            this.comboBoxVoting.Location = new System.Drawing.Point(78, 123);
            this.comboBoxVoting.MouseLocation = new System.Drawing.Point(-1, -1);
            this.comboBoxVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.comboBoxVoting.Name = "comboBoxVoting";
            this.comboBoxVoting.Size = new System.Drawing.Size(450, 310);
            this.comboBoxVoting.TabIndex = 13;
            this.comboBoxVoting.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoting_SelectedIndexChanged);
            // 
            // labelChooseVoting
            // 
            this.labelChooseVoting.AutoSize = true;
            this.labelChooseVoting.Depth = 0;
            this.labelChooseVoting.Font = new System.Drawing.Font("Arial", 10F);
            this.labelChooseVoting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelChooseVoting.Location = new System.Drawing.Point(74, 101);
            this.labelChooseVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelChooseVoting.Name = "labelChooseVoting";
            this.labelChooseVoting.Size = new System.Drawing.Size(112, 19);
            this.labelChooseVoting.TabIndex = 12;
            this.labelChooseVoting.Text = "Choose voting";
            // 
            // labelVotingInfo
            // 
            this.labelVotingInfo.Depth = 0;
            this.labelVotingInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingInfo.Location = new System.Drawing.Point(609, 332);
            this.labelVotingInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingInfo.Name = "labelVotingInfo";
            this.labelVotingInfo.Size = new System.Drawing.Size(407, 27);
            this.labelVotingInfo.TabIndex = 0;
            this.labelVotingInfo.Text = "In voting";
            this.labelVotingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCandidateName
            // 
            this.labelCandidateName.Depth = 0;
            this.labelCandidateName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateName.Location = new System.Drawing.Point(612, 449);
            this.labelCandidateName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateName.Name = "labelCandidateName";
            this.labelCandidateName.Size = new System.Drawing.Size(404, 46);
            this.labelCandidateName.TabIndex = 4;
            this.labelCandidateName.Text = "...";
            this.labelCandidateName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCandidateInfo
            // 
            this.labelCandidateInfo.Depth = 0;
            this.labelCandidateInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateInfo.Location = new System.Drawing.Point(612, 407);
            this.labelCandidateInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateInfo.Name = "labelCandidateInfo";
            this.labelCandidateInfo.Size = new System.Drawing.Size(404, 23);
            this.labelCandidateInfo.TabIndex = 3;
            this.labelCandidateInfo.Text = "Wons";
            this.labelCandidateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVotingName
            // 
            this.labelVotingName.Depth = 0;
            this.labelVotingName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingName.Location = new System.Drawing.Point(612, 368);
            this.labelVotingName.MouseState = MaterialSkin.MouseState.HOVER;
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
            this.ClientSize = new System.Drawing.Size(1106, 794);
            this.Controls.Add(this.labelCandidateName);
            this.Controls.Add(this.labelCandidateInfo);
            this.Controls.Add(this.labelVotingName);
            this.Controls.Add(this.listViewCandidates);
            this.Controls.Add(this.labelVotingInfo);
            this.Controls.Add(this.labelCandidates);
            this.Controls.Add(this.comboBoxVoting);
            this.Controls.Add(this.labelChooseVoting);
            this.Name = "VotingsStatisticForm";
            this.Text = "VotingsStatisticForm";
            this.Load += new System.EventHandler(this.VotingsStatisticForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialListView listViewCandidates;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderHash;
        private MaterialSkin.Controls.MaterialLabel labelCandidates;
        private MaterialSkin.Controls.MaterialListBox comboBoxVoting;
        private MaterialSkin.Controls.MaterialLabel labelChooseVoting;
        private MaterialSkin.Controls.MaterialLabel labelVotingInfo;
        private MaterialSkin.Controls.MaterialLabel labelCandidateName;
        private MaterialSkin.Controls.MaterialLabel labelCandidateInfo;
        private MaterialSkin.Controls.MaterialLabel labelVotingName;
        private System.Windows.Forms.ColumnHeader columnHeaderVotes;
    }
}