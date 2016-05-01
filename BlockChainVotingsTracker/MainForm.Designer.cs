namespace BlockChainVotingsTracker
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartTracker = new System.Windows.Forms.Button();
            this.buttonStopTracker = new System.Windows.Forms.Button();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStartTracker
            // 
            this.buttonStartTracker.Location = new System.Drawing.Point(12, 12);
            this.buttonStartTracker.Name = "buttonStartTracker";
            this.buttonStartTracker.Size = new System.Drawing.Size(75, 23);
            this.buttonStartTracker.TabIndex = 0;
            this.buttonStartTracker.Text = "Start";
            this.buttonStartTracker.UseVisualStyleBackColor = true;
            this.buttonStartTracker.Click += new System.EventHandler(this.buttonStartTracker_Click);
            // 
            // buttonStopTracker
            // 
            this.buttonStopTracker.Location = new System.Drawing.Point(93, 12);
            this.buttonStopTracker.Name = "buttonStopTracker";
            this.buttonStopTracker.Size = new System.Drawing.Size(75, 23);
            this.buttonStopTracker.TabIndex = 1;
            this.buttonStopTracker.Text = "Stop";
            this.buttonStopTracker.UseVisualStyleBackColor = true;
            this.buttonStopTracker.Click += new System.EventHandler(this.buttonStopTracker_Click);
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Location = new System.Drawing.Point(12, 42);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(668, 199);
            this.textBoxConsole.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 253);
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.buttonStopTracker);
            this.Controls.Add(this.buttonStartTracker);
            this.Name = "MainForm";
            this.Text = "BlockChainVotingsTracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartTracker;
        private System.Windows.Forms.Button buttonStopTracker;
        private System.Windows.Forms.TextBox textBoxConsole;
    }
}

