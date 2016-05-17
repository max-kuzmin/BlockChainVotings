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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelVotingName = new System.Windows.Forms.Label();
            this.textBoxVotingName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(217, 217);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelVotingName
            // 
            this.labelVotingName.AutoSize = true;
            this.labelVotingName.Location = new System.Drawing.Point(56, 76);
            this.labelVotingName.Name = "labelVotingName";
            this.labelVotingName.Size = new System.Drawing.Size(85, 17);
            this.labelVotingName.TabIndex = 1;
            this.labelVotingName.Text = "VotingName";
            // 
            // textBoxVotingName
            // 
            this.textBoxVotingName.Location = new System.Drawing.Point(164, 73);
            this.textBoxVotingName.Name = "textBoxVotingName";
            this.textBoxVotingName.Size = new System.Drawing.Size(295, 22);
            this.textBoxVotingName.TabIndex = 2;
            this.textBoxVotingName.TextChanged += new System.EventHandler(this.textBoxVotingName_TextChanged);
            // 
            // CreateVotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 328);
            this.Controls.Add(this.textBoxVotingName);
            this.Controls.Add(this.labelVotingName);
            this.Controls.Add(this.buttonCreate);
            this.Name = "CreateVotingForm";
            this.Text = "CreateVoting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label labelVotingName;
        private System.Windows.Forms.TextBox textBoxVotingName;
    }
}