namespace BlockChainVotings
{
    partial class BanUserForm
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
            this.listViewSearchUsers = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSearchUser = new System.Windows.Forms.Label();
            this.textBoxSearchUser = new System.Windows.Forms.TextBox();
            this.buttonBan = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelCause = new System.Windows.Forms.Label();
            this.textBoxCause = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewSearchUsers
            // 
            this.listViewSearchUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewSearchUsers.Location = new System.Drawing.Point(79, 206);
            this.listViewSearchUsers.MultiSelect = false;
            this.listViewSearchUsers.Name = "listViewSearchUsers";
            this.listViewSearchUsers.Size = new System.Drawing.Size(218, 97);
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
            // labelSearchUser
            // 
            this.labelSearchUser.AutoSize = true;
            this.labelSearchUser.Location = new System.Drawing.Point(76, 134);
            this.labelSearchUser.Name = "labelSearchUser";
            this.labelSearchUser.Size = new System.Drawing.Size(83, 17);
            this.labelSearchUser.TabIndex = 12;
            this.labelSearchUser.Text = "SearchUser";
            // 
            // textBoxSearchUser
            // 
            this.textBoxSearchUser.Location = new System.Drawing.Point(79, 154);
            this.textBoxSearchUser.Name = "textBoxSearchUser";
            this.textBoxSearchUser.Size = new System.Drawing.Size(218, 22);
            this.textBoxSearchUser.TabIndex = 11;
            this.textBoxSearchUser.TextChanged += new System.EventHandler(this.textBoxSearchUser_TextChanged);
            // 
            // buttonBan
            // 
            this.buttonBan.Location = new System.Drawing.Point(117, 327);
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(138, 31);
            this.buttonBan.TabIndex = 14;
            this.buttonBan.Text = "Ban";
            this.buttonBan.UseVisualStyleBackColor = true;
            this.buttonBan.Click += new System.EventHandler(this.buttonBan_Click);
            // 
            // labelCause
            // 
            this.labelCause.AutoSize = true;
            this.labelCause.Location = new System.Drawing.Point(76, 76);
            this.labelCause.Name = "labelCause";
            this.labelCause.Size = new System.Drawing.Size(48, 17);
            this.labelCause.TabIndex = 16;
            this.labelCause.Text = "Cause";
            // 
            // textBoxCause
            // 
            this.textBoxCause.Location = new System.Drawing.Point(79, 96);
            this.textBoxCause.Name = "textBoxCause";
            this.textBoxCause.Size = new System.Drawing.Size(218, 22);
            this.textBoxCause.TabIndex = 15;
            this.textBoxCause.TextChanged += new System.EventHandler(this.textBoxCause_TextChanged);
            // 
            // BanUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 379);
            this.Controls.Add(this.labelCause);
            this.Controls.Add(this.textBoxCause);
            this.Controls.Add(this.buttonBan);
            this.Controls.Add(this.listViewSearchUsers);
            this.Controls.Add(this.labelSearchUser);
            this.Controls.Add(this.textBoxSearchUser);
            this.Name = "BanUserForm";
            this.Text = "BanUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSearchUsers;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label labelSearchUser;
        private System.Windows.Forms.TextBox textBoxSearchUser;
        private System.Windows.Forms.Button buttonBan;
        private System.Windows.Forms.Label labelCause;
        private System.Windows.Forms.TextBox textBoxCause;
    }
}