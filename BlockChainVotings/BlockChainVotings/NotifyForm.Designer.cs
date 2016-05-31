namespace BlockChainVotings
{
    partial class NotifyForm
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
            this.materialRaisedButtonShow = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelNewVoting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // materialRaisedButtonShow
            // 
            this.materialRaisedButtonShow.Depth = 0;
            this.materialRaisedButtonShow.Location = new System.Drawing.Point(57, 164);
            this.materialRaisedButtonShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.materialRaisedButtonShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonShow.Name = "materialRaisedButtonShow";
            this.materialRaisedButtonShow.Size = new System.Drawing.Size(149, 34);
            this.materialRaisedButtonShow.TabIndex = 0;
            this.materialRaisedButtonShow.Text = "Show";
            this.materialRaisedButtonShow.UseVisualStyleBackColor = true;
            this.materialRaisedButtonShow.Click += new System.EventHandler(this.materialRaisedButtonShow_Click);
            // 
            // labelNewVoting
            // 
            this.labelNewVoting.Location = new System.Drawing.Point(7, 98);
            this.labelNewVoting.Name = "labelNewVoting";
            this.labelNewVoting.Size = new System.Drawing.Size(253, 46);
            this.labelNewVoting.TabIndex = 1;
            this.labelNewVoting.Text = "Voting";
            this.labelNewVoting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(275, 224);
            this.Controls.Add(this.labelNewVoting);
            this.Controls.Add(this.materialRaisedButtonShow);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotifyForm";
            this.Sizable = false;
            this.Text = "New voting";
            this.Load += new System.EventHandler(this.NotifyForm_Load);
            this.Shown += new System.EventHandler(this.NotifyForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonShow;
        private System.Windows.Forms.Label labelNewVoting;
    }
}