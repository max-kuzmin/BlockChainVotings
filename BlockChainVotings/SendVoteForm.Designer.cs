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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendVoteForm));
            this.labelChooseVoting = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxVoting = new MaterialSkin.Controls.MaterialListBox();
            this.materialContextMenuStripVoting = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonVote = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelCandidate = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateName = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateInfo = new MaterialSkin.Controls.MaterialLabel();
            this.checkBoxAgree = new MaterialSkin.Controls.MaterialCheckBox();
            this.labelVotingName = new MaterialSkin.Controls.MaterialLabel();
            this.labelVotingInfo = new MaterialSkin.Controls.MaterialLabel();
            this.listViewCandidates = new MaterialSkin.Controls.MaterialListView();
            this.columnHeaderCandidateHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCandidateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCandidateID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialContextMenuStripCandidate = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialContextMenuStripVoting.SuspendLayout();
            this.materialContextMenuStripCandidate.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelChooseVoting
            // 
            this.labelChooseVoting.AutoSize = true;
            this.labelChooseVoting.Depth = 0;
            this.labelChooseVoting.Font = new System.Drawing.Font("Arial", 10F);
            this.labelChooseVoting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelChooseVoting.Location = new System.Drawing.Point(70, 105);
            this.labelChooseVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelChooseVoting.Name = "labelChooseVoting";
            this.labelChooseVoting.Size = new System.Drawing.Size(112, 19);
            this.labelChooseVoting.TabIndex = 0;
            this.labelChooseVoting.Text = "Choose voting";
            // 
            // comboBoxVoting
            // 
            this.comboBoxVoting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxVoting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comboBoxVoting.ContextMenuStrip = this.materialContextMenuStripVoting;
            this.comboBoxVoting.Depth = 0;
            this.comboBoxVoting.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxVoting.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.comboBoxVoting.FormattingEnabled = true;
            this.comboBoxVoting.Location = new System.Drawing.Point(71, 136);
            this.comboBoxVoting.MouseLocation = new System.Drawing.Point(-1, -1);
            this.comboBoxVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.comboBoxVoting.Name = "comboBoxVoting";
            this.comboBoxVoting.Size = new System.Drawing.Size(560, 150);
            this.comboBoxVoting.TabIndex = 0;
            this.comboBoxVoting.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoting_TextUpdate);
            // 
            // materialContextMenuStripVoting
            // 
            this.materialContextMenuStripVoting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStripVoting.Depth = 0;
            this.materialContextMenuStripVoting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStripVoting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.materialContextMenuStripVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStripVoting.Name = "materialContextMenuStripUser";
            this.materialContextMenuStripVoting.Size = new System.Drawing.Size(119, 30);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 26);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // buttonVote
            // 
            this.buttonVote.Depth = 0;
            this.buttonVote.Location = new System.Drawing.Point(465, 574);
            this.buttonVote.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonVote.Name = "buttonVote";
            this.buttonVote.Size = new System.Drawing.Size(225, 35);
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
            this.labelCandidate.Location = new System.Drawing.Point(70, 320);
            this.labelCandidate.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidate.Name = "labelCandidate";
            this.labelCandidate.Size = new System.Drawing.Size(141, 19);
            this.labelCandidate.TabIndex = 4;
            this.labelCandidate.Text = "Choose candidate";
            // 
            // labelCandidateName
            // 
            this.labelCandidateName.AutoEllipsis = true;
            this.labelCandidateName.Depth = 0;
            this.labelCandidateName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateName.Location = new System.Drawing.Point(706, 332);
            this.labelCandidateName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateName.Name = "labelCandidateName";
            this.labelCandidateName.Size = new System.Drawing.Size(412, 80);
            this.labelCandidateName.TabIndex = 4;
            this.labelCandidateName.Text = "...";
            this.labelCandidateName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCandidateInfo
            // 
            this.labelCandidateInfo.Depth = 0;
            this.labelCandidateInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateInfo.Location = new System.Drawing.Point(706, 296);
            this.labelCandidateInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateInfo.Name = "labelCandidateInfo";
            this.labelCandidateInfo.Size = new System.Drawing.Size(412, 23);
            this.labelCandidateInfo.TabIndex = 3;
            this.labelCandidateInfo.Text = "I vote for";
            this.labelCandidateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxAgree
            // 
            this.checkBoxAgree.AutoSize = true;
            this.checkBoxAgree.Depth = 0;
            this.checkBoxAgree.Font = new System.Drawing.Font("Arial", 10F);
            this.checkBoxAgree.Location = new System.Drawing.Point(838, 456);
            this.checkBoxAgree.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAgree.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxAgree.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxAgree.Name = "checkBoxAgree";
            this.checkBoxAgree.Ripple = true;
            this.checkBoxAgree.Size = new System.Drawing.Size(75, 30);
            this.checkBoxAgree.TabIndex = 2;
            this.checkBoxAgree.Text = "agree";
            this.checkBoxAgree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxAgree.UseVisualStyleBackColor = true;
            this.checkBoxAgree.CheckedChanged += new System.EventHandler(this.checkBoxAgree_CheckedChanged);
            // 
            // labelVotingName
            // 
            this.labelVotingName.AutoEllipsis = true;
            this.labelVotingName.Depth = 0;
            this.labelVotingName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingName.Location = new System.Drawing.Point(706, 173);
            this.labelVotingName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingName.Name = "labelVotingName";
            this.labelVotingName.Size = new System.Drawing.Size(412, 80);
            this.labelVotingName.TabIndex = 1;
            this.labelVotingName.Text = "...";
            this.labelVotingName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVotingInfo
            // 
            this.labelVotingInfo.Depth = 0;
            this.labelVotingInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingInfo.Location = new System.Drawing.Point(706, 134);
            this.labelVotingInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingInfo.Name = "labelVotingInfo";
            this.labelVotingInfo.Size = new System.Drawing.Size(412, 27);
            this.labelVotingInfo.TabIndex = 0;
            this.labelVotingInfo.Text = "Taking part in voting";
            this.labelVotingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.listViewCandidates.Location = new System.Drawing.Point(71, 355);
            this.listViewCandidates.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewCandidates.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewCandidates.MultiSelect = false;
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.OwnerDraw = true;
            this.listViewCandidates.Size = new System.Drawing.Size(560, 150);
            this.listViewCandidates.TabIndex = 1;
            this.listViewCandidates.UseCompatibleStateImageBehavior = false;
            this.listViewCandidates.View = System.Windows.Forms.View.Details;
            this.listViewCandidates.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewCandidates_ItemSelectionChanged);
            // 
            // columnHeaderCandidateHash
            // 
            this.columnHeaderCandidateHash.Text = "Hash";
            this.columnHeaderCandidateHash.Width = 150;
            // 
            // columnHeaderCandidateName
            // 
            this.columnHeaderCandidateName.Text = "Name";
            this.columnHeaderCandidateName.Width = 250;
            // 
            // columnHeaderCandidateID
            // 
            this.columnHeaderCandidateID.Text = "ID";
            this.columnHeaderCandidateID.Width = 150;
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
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(662, 101);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 420);
            this.materialDivider1.TabIndex = 12;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // SendVoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 665);
            this.Controls.Add(this.materialDivider1);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SendVoteForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendVoteForm";
            this.Load += new System.EventHandler(this.SendVoteForm_Load);
            this.Shown += new System.EventHandler(this.SendVoteForm_Shown);
            this.materialContextMenuStripVoting.ResumeLayout(false);
            this.materialContextMenuStripCandidate.ResumeLayout(false);
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
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateHash;
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateName;
        private System.Windows.Forms.ColumnHeader columnHeaderCandidateID;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStripVoting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStripCandidate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}