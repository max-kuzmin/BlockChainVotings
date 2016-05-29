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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VotingsStatisticForm));
            this.listViewCandidates = new MaterialSkin.Controls.MaterialListView();
            this.columnHeaderHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialContextMenuStripCandidate = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCandidates = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxVoting = new MaterialSkin.Controls.MaterialListBox();
            this.materialContextMenuStripVoting = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelChooseVoting = new MaterialSkin.Controls.MaterialLabel();
            this.labelVotingInfo = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateName = new MaterialSkin.Controls.MaterialLabel();
            this.labelCandidateInfo = new MaterialSkin.Controls.MaterialLabel();
            this.labelVotingName = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialLabelWithResult = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelResult = new MaterialSkin.Controls.MaterialLabel();
            this.materialContextMenuStripCandidate.SuspendLayout();
            this.materialContextMenuStripVoting.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCandidates
            // 
            this.listViewCandidates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHash,
            this.columnHeaderName,
            this.columnHeaderID,
            this.columnHeaderVotes});
            this.listViewCandidates.ContextMenuStrip = this.materialContextMenuStripCandidate;
            this.listViewCandidates.Depth = 0;
            this.listViewCandidates.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.listViewCandidates.FullRowSelect = true;
            this.listViewCandidates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCandidates.Location = new System.Drawing.Point(51, 304);
            this.listViewCandidates.Margin = new System.Windows.Forms.Padding(2);
            this.listViewCandidates.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewCandidates.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewCandidates.MultiSelect = false;
            this.listViewCandidates.Name = "listViewCandidates";
            this.listViewCandidates.OwnerDraw = true;
            this.listViewCandidates.Size = new System.Drawing.Size(456, 192);
            this.listViewCandidates.TabIndex = 15;
            this.listViewCandidates.UseCompatibleStateImageBehavior = false;
            this.listViewCandidates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderHash
            // 
            this.columnHeaderHash.Text = "Hash";
            this.columnHeaderHash.Width = 100;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 180;
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            this.columnHeaderID.Width = 100;
            // 
            // columnHeaderVotes
            // 
            this.columnHeaderVotes.Text = "Votes";
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
            this.materialContextMenuStripCandidate.Size = new System.Drawing.Size(103, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem2.Text = "Copy";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // labelCandidates
            // 
            this.labelCandidates.AutoSize = true;
            this.labelCandidates.Depth = 0;
            this.labelCandidates.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidates.Location = new System.Drawing.Point(48, 273);
            this.labelCandidates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCandidates.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidates.Name = "labelCandidates";
            this.labelCandidates.Size = new System.Drawing.Size(80, 16);
            this.labelCandidates.TabIndex = 14;
            this.labelCandidates.Text = "Сandidates";
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
            this.comboBoxVoting.Location = new System.Drawing.Point(51, 124);
            this.comboBoxVoting.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxVoting.MouseLocation = new System.Drawing.Point(-1, -1);
            this.comboBoxVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.comboBoxVoting.Name = "comboBoxVoting";
            this.comboBoxVoting.Size = new System.Drawing.Size(456, 122);
            this.comboBoxVoting.TabIndex = 13;
            this.comboBoxVoting.SelectedIndexChanged += new System.EventHandler(this.comboBoxVoting_SelectedIndexChanged);
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
            this.materialContextMenuStripVoting.Size = new System.Drawing.Size(103, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "Copy";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // labelChooseVoting
            // 
            this.labelChooseVoting.AutoSize = true;
            this.labelChooseVoting.Depth = 0;
            this.labelChooseVoting.Font = new System.Drawing.Font("Arial", 10F);
            this.labelChooseVoting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelChooseVoting.Location = new System.Drawing.Point(48, 93);
            this.labelChooseVoting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChooseVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelChooseVoting.Name = "labelChooseVoting";
            this.labelChooseVoting.Size = new System.Drawing.Size(99, 16);
            this.labelChooseVoting.TabIndex = 12;
            this.labelChooseVoting.Text = "Choose voting";
            // 
            // labelVotingInfo
            // 
            this.labelVotingInfo.Depth = 0;
            this.labelVotingInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingInfo.Location = new System.Drawing.Point(581, 93);
            this.labelVotingInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVotingInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingInfo.Name = "labelVotingInfo";
            this.labelVotingInfo.Size = new System.Drawing.Size(300, 22);
            this.labelVotingInfo.TabIndex = 0;
            this.labelVotingInfo.Text = "In voting";
            this.labelVotingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCandidateName
            // 
            this.labelCandidateName.AutoEllipsis = true;
            this.labelCandidateName.Depth = 0;
            this.labelCandidateName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateName.Location = new System.Drawing.Point(581, 285);
            this.labelCandidateName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCandidateName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateName.Name = "labelCandidateName";
            this.labelCandidateName.Size = new System.Drawing.Size(300, 100);
            this.labelCandidateName.TabIndex = 4;
            this.labelCandidateName.Text = "...";
            this.labelCandidateName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCandidateInfo
            // 
            this.labelCandidateInfo.Depth = 0;
            this.labelCandidateInfo.Font = new System.Drawing.Font("Arial", 10F);
            this.labelCandidateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCandidateInfo.Location = new System.Drawing.Point(581, 255);
            this.labelCandidateInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCandidateInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCandidateInfo.Name = "labelCandidateInfo";
            this.labelCandidateInfo.Size = new System.Drawing.Size(300, 19);
            this.labelCandidateInfo.TabIndex = 3;
            this.labelCandidateInfo.Text = "Wons";
            this.labelCandidateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVotingName
            // 
            this.labelVotingName.AutoEllipsis = true;
            this.labelVotingName.Depth = 0;
            this.labelVotingName.Font = new System.Drawing.Font("Arial", 10F);
            this.labelVotingName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelVotingName.Location = new System.Drawing.Point(581, 134);
            this.labelVotingName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVotingName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelVotingName.Name = "labelVotingName";
            this.labelVotingName.Size = new System.Drawing.Size(300, 100);
            this.labelVotingName.TabIndex = 1;
            this.labelVotingName.Text = "...";
            this.labelVotingName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(538, 93);
            this.materialDivider1.Margin = new System.Windows.Forms.Padding(2);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(8, 419);
            this.materialDivider1.TabIndex = 16;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialLabelWithResult
            // 
            this.materialLabelWithResult.Depth = 0;
            this.materialLabelWithResult.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelWithResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelWithResult.Location = new System.Drawing.Point(581, 405);
            this.materialLabelWithResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabelWithResult.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelWithResult.Name = "materialLabelWithResult";
            this.materialLabelWithResult.Size = new System.Drawing.Size(300, 19);
            this.materialLabelWithResult.TabIndex = 17;
            this.materialLabelWithResult.Text = "With result";
            this.materialLabelWithResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabelResult
            // 
            this.materialLabelResult.AutoEllipsis = true;
            this.materialLabelResult.Depth = 0;
            this.materialLabelResult.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelResult.Location = new System.Drawing.Point(581, 436);
            this.materialLabelResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabelResult.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelResult.Name = "materialLabelResult";
            this.materialLabelResult.Size = new System.Drawing.Size(300, 33);
            this.materialLabelResult.TabIndex = 18;
            this.materialLabelResult.Text = "...";
            this.materialLabelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VotingsStatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 535);
            this.Controls.Add(this.materialLabelResult);
            this.Controls.Add(this.materialLabelWithResult);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.labelCandidateName);
            this.Controls.Add(this.labelCandidateInfo);
            this.Controls.Add(this.labelVotingName);
            this.Controls.Add(this.listViewCandidates);
            this.Controls.Add(this.labelVotingInfo);
            this.Controls.Add(this.labelCandidates);
            this.Controls.Add(this.comboBoxVoting);
            this.Controls.Add(this.labelChooseVoting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "VotingsStatisticForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VotingsStatisticForm";
            this.Load += new System.EventHandler(this.VotingsStatisticForm_Load);
            this.Shown += new System.EventHandler(this.VotingsStatisticForm_Shown);
            this.materialContextMenuStripCandidate.ResumeLayout(false);
            this.materialContextMenuStripVoting.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStripCandidate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStripVoting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private MaterialSkin.Controls.MaterialLabel materialLabelWithResult;
        private MaterialSkin.Controls.MaterialLabel materialLabelResult;
    }
}