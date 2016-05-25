namespace BlockChainVotings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.materialRaisedButtonTheme = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.materialRaisedButtonVote = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabelAvaliableVotings = new MaterialSkin.Controls.MaterialLabel();
            this.materialDivider3 = new MaterialSkin.Controls.MaterialDivider();
            this.materialRaisedButtonMyStatistic = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButtonUserStatistic = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButtonVotingStatistic = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButtonCreateVoting = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButtonBanUser = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButtonCreateUser = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialLabelHello = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelStatistics = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelTrackersVal = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelConnectedTrackers = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelUsersVal = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelPeersVal = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelPeers = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelUsers = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelTransactionsVal = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelBlocksVal = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelBlocks = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelTransactions = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.materialLabelNetwork = new MaterialSkin.Controls.MaterialLabel();
            this.buttonStop = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonStart = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabelAbout = new MaterialSkin.Controls.MaterialLabel();
            this.materialCheckBoxCreateBlocks = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabelConsole = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabelTrackers = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.textBoxTrackers = new System.Windows.Forms.TextBox();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.materialTabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialRaisedButtonTheme
            // 
            this.materialRaisedButtonTheme.Depth = 0;
            this.materialRaisedButtonTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialRaisedButtonTheme.Location = new System.Drawing.Point(40, 159);
            this.materialRaisedButtonTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonTheme.Name = "materialRaisedButtonTheme";
            this.materialRaisedButtonTheme.Size = new System.Drawing.Size(242, 30);
            this.materialRaisedButtonTheme.TabIndex = 10;
            this.materialRaisedButtonTheme.Text = "Theme";
            this.materialRaisedButtonTheme.UseVisualStyleBackColor = true;
            this.materialRaisedButtonTheme.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControl1.Controls.Add(this.tabPageMain);
            this.materialTabControl1.Controls.Add(this.tabPageOptions);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(4, 114);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(820, 425);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.BackColor = System.Drawing.Color.White;
            this.tabPageMain.Controls.Add(this.materialRaisedButtonVote);
            this.tabPageMain.Controls.Add(this.materialLabelAvaliableVotings);
            this.tabPageMain.Controls.Add(this.materialDivider3);
            this.tabPageMain.Controls.Add(this.materialRaisedButtonMyStatistic);
            this.tabPageMain.Controls.Add(this.materialRaisedButtonUserStatistic);
            this.tabPageMain.Controls.Add(this.materialRaisedButtonVotingStatistic);
            this.tabPageMain.Controls.Add(this.materialRaisedButtonCreateVoting);
            this.tabPageMain.Controls.Add(this.materialRaisedButtonBanUser);
            this.tabPageMain.Controls.Add(this.materialRaisedButtonCreateUser);
            this.tabPageMain.Controls.Add(this.materialDivider1);
            this.tabPageMain.Controls.Add(this.materialLabelHello);
            this.tabPageMain.Controls.Add(this.materialLabelStatistics);
            this.tabPageMain.Controls.Add(this.materialLabelTrackersVal);
            this.tabPageMain.Controls.Add(this.materialLabelConnectedTrackers);
            this.tabPageMain.Controls.Add(this.materialLabelUsersVal);
            this.tabPageMain.Controls.Add(this.materialLabelPeersVal);
            this.tabPageMain.Controls.Add(this.materialLabelPeers);
            this.tabPageMain.Controls.Add(this.materialLabelUsers);
            this.tabPageMain.Controls.Add(this.materialLabelTransactionsVal);
            this.tabPageMain.Controls.Add(this.materialLabelBlocksVal);
            this.tabPageMain.Controls.Add(this.materialLabelBlocks);
            this.tabPageMain.Controls.Add(this.materialLabelTransactions);
            this.tabPageMain.Location = new System.Drawing.Point(4, 25);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(812, 396);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            // 
            // materialRaisedButtonVote
            // 
            this.materialRaisedButtonVote.Depth = 0;
            this.materialRaisedButtonVote.Location = new System.Drawing.Point(49, 50);
            this.materialRaisedButtonVote.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonVote.Name = "materialRaisedButtonVote";
            this.materialRaisedButtonVote.Size = new System.Drawing.Size(297, 46);
            this.materialRaisedButtonVote.TabIndex = 2;
            this.materialRaisedButtonVote.Text = "Vote";
            this.materialRaisedButtonVote.UseVisualStyleBackColor = true;
            this.materialRaisedButtonVote.Click += new System.EventHandler(this.materialRaisedButtonVote_Click);
            // 
            // materialLabelAvaliableVotings
            // 
            this.materialLabelAvaliableVotings.Depth = 0;
            this.materialLabelAvaliableVotings.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelAvaliableVotings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelAvaliableVotings.Location = new System.Drawing.Point(45, 131);
            this.materialLabelAvaliableVotings.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelAvaliableVotings.Name = "materialLabelAvaliableVotings";
            this.materialLabelAvaliableVotings.Size = new System.Drawing.Size(301, 28);
            this.materialLabelAvaliableVotings.TabIndex = 21;
            this.materialLabelAvaliableVotings.Text = "Avaliable votings";
            this.materialLabelAvaliableVotings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialDivider3
            // 
            this.materialDivider3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Location = new System.Drawing.Point(29, 202);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Size = new System.Drawing.Size(334, 10);
            this.materialDivider3.TabIndex = 20;
            this.materialDivider3.Text = "materialDivider3";
            // 
            // materialRaisedButtonMyStatistic
            // 
            this.materialRaisedButtonMyStatistic.Depth = 0;
            this.materialRaisedButtonMyStatistic.Location = new System.Drawing.Point(49, 330);
            this.materialRaisedButtonMyStatistic.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonMyStatistic.Name = "materialRaisedButtonMyStatistic";
            this.materialRaisedButtonMyStatistic.Size = new System.Drawing.Size(297, 33);
            this.materialRaisedButtonMyStatistic.TabIndex = 7;
            this.materialRaisedButtonMyStatistic.Text = "My statistic";
            this.materialRaisedButtonMyStatistic.UseVisualStyleBackColor = true;
            this.materialRaisedButtonMyStatistic.Click += new System.EventHandler(this.materialRaisedButtonMyStatistic_Click);
            // 
            // materialRaisedButtonUserStatistic
            // 
            this.materialRaisedButtonUserStatistic.Depth = 0;
            this.materialRaisedButtonUserStatistic.Location = new System.Drawing.Point(49, 285);
            this.materialRaisedButtonUserStatistic.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonUserStatistic.Name = "materialRaisedButtonUserStatistic";
            this.materialRaisedButtonUserStatistic.Size = new System.Drawing.Size(297, 33);
            this.materialRaisedButtonUserStatistic.TabIndex = 6;
            this.materialRaisedButtonUserStatistic.Text = "User statistic";
            this.materialRaisedButtonUserStatistic.UseVisualStyleBackColor = true;
            this.materialRaisedButtonUserStatistic.Click += new System.EventHandler(this.materialRaisedButtonUserStatistic_Click);
            // 
            // materialRaisedButtonVotingStatistic
            // 
            this.materialRaisedButtonVotingStatistic.Depth = 0;
            this.materialRaisedButtonVotingStatistic.Location = new System.Drawing.Point(49, 241);
            this.materialRaisedButtonVotingStatistic.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonVotingStatistic.Name = "materialRaisedButtonVotingStatistic";
            this.materialRaisedButtonVotingStatistic.Size = new System.Drawing.Size(297, 33);
            this.materialRaisedButtonVotingStatistic.TabIndex = 5;
            this.materialRaisedButtonVotingStatistic.Text = "Voting statistic";
            this.materialRaisedButtonVotingStatistic.UseVisualStyleBackColor = true;
            this.materialRaisedButtonVotingStatistic.Click += new System.EventHandler(this.materialRaisedButtonVotingStatistic_Click);
            // 
            // materialRaisedButtonCreateVoting
            // 
            this.materialRaisedButtonCreateVoting.Depth = 0;
            this.materialRaisedButtonCreateVoting.Location = new System.Drawing.Point(49, 50);
            this.materialRaisedButtonCreateVoting.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonCreateVoting.Name = "materialRaisedButtonCreateVoting";
            this.materialRaisedButtonCreateVoting.Size = new System.Drawing.Size(297, 33);
            this.materialRaisedButtonCreateVoting.TabIndex = 1;
            this.materialRaisedButtonCreateVoting.Text = "Create voting";
            this.materialRaisedButtonCreateVoting.UseVisualStyleBackColor = true;
            this.materialRaisedButtonCreateVoting.Click += new System.EventHandler(this.materialRaisedButtonCreateVoting_Click);
            // 
            // materialRaisedButtonBanUser
            // 
            this.materialRaisedButtonBanUser.Depth = 0;
            this.materialRaisedButtonBanUser.Location = new System.Drawing.Point(49, 140);
            this.materialRaisedButtonBanUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonBanUser.Name = "materialRaisedButtonBanUser";
            this.materialRaisedButtonBanUser.Size = new System.Drawing.Size(297, 33);
            this.materialRaisedButtonBanUser.TabIndex = 4;
            this.materialRaisedButtonBanUser.Text = "Ban user";
            this.materialRaisedButtonBanUser.UseVisualStyleBackColor = true;
            this.materialRaisedButtonBanUser.Click += new System.EventHandler(this.materialRaisedButtonBanUser_Click);
            // 
            // materialRaisedButtonCreateUser
            // 
            this.materialRaisedButtonCreateUser.Depth = 0;
            this.materialRaisedButtonCreateUser.Location = new System.Drawing.Point(49, 95);
            this.materialRaisedButtonCreateUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonCreateUser.Name = "materialRaisedButtonCreateUser";
            this.materialRaisedButtonCreateUser.Size = new System.Drawing.Size(297, 33);
            this.materialRaisedButtonCreateUser.TabIndex = 3;
            this.materialRaisedButtonCreateUser.Text = "Create user";
            this.materialRaisedButtonCreateUser.UseVisualStyleBackColor = true;
            this.materialRaisedButtonCreateUser.Click += new System.EventHandler(this.materialRaisedButtonCreateUser_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(408, 0);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 381);
            this.materialDivider1.TabIndex = 13;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialLabelHello
            // 
            this.materialLabelHello.Depth = 0;
            this.materialLabelHello.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelHello.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelHello.Location = new System.Drawing.Point(45, 3);
            this.materialLabelHello.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelHello.Name = "materialLabelHello";
            this.materialLabelHello.Size = new System.Drawing.Size(301, 21);
            this.materialLabelHello.TabIndex = 11;
            this.materialLabelHello.Text = "Hello, User";
            this.materialLabelHello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabelStatistics
            // 
            this.materialLabelStatistics.Depth = 0;
            this.materialLabelStatistics.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelStatistics.Location = new System.Drawing.Point(434, 1);
            this.materialLabelStatistics.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelStatistics.Name = "materialLabelStatistics";
            this.materialLabelStatistics.Size = new System.Drawing.Size(349, 23);
            this.materialLabelStatistics.TabIndex = 10;
            this.materialLabelStatistics.Text = "Statistics";
            this.materialLabelStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabelTrackersVal
            // 
            this.materialLabelTrackersVal.AutoSize = true;
            this.materialLabelTrackersVal.Depth = 0;
            this.materialLabelTrackersVal.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelTrackersVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelTrackersVal.Location = new System.Drawing.Point(706, 241);
            this.materialLabelTrackersVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelTrackersVal.Name = "materialLabelTrackersVal";
            this.materialLabelTrackersVal.Size = new System.Drawing.Size(24, 19);
            this.materialLabelTrackersVal.TabIndex = 9;
            this.materialLabelTrackersVal.Text = "...";
            // 
            // materialLabelConnectedTrackers
            // 
            this.materialLabelConnectedTrackers.AutoSize = true;
            this.materialLabelConnectedTrackers.Depth = 0;
            this.materialLabelConnectedTrackers.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelConnectedTrackers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelConnectedTrackers.Location = new System.Drawing.Point(482, 241);
            this.materialLabelConnectedTrackers.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelConnectedTrackers.Name = "materialLabelConnectedTrackers";
            this.materialLabelConnectedTrackers.Size = new System.Drawing.Size(143, 19);
            this.materialLabelConnectedTrackers.TabIndex = 8;
            this.materialLabelConnectedTrackers.Text = "Conected trackers";
            // 
            // materialLabelUsersVal
            // 
            this.materialLabelUsersVal.AutoSize = true;
            this.materialLabelUsersVal.Depth = 0;
            this.materialLabelUsersVal.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelUsersVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelUsersVal.Location = new System.Drawing.Point(706, 151);
            this.materialLabelUsersVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelUsersVal.Name = "materialLabelUsersVal";
            this.materialLabelUsersVal.Size = new System.Drawing.Size(24, 19);
            this.materialLabelUsersVal.TabIndex = 7;
            this.materialLabelUsersVal.Text = "...";
            // 
            // materialLabelPeersVal
            // 
            this.materialLabelPeersVal.AutoSize = true;
            this.materialLabelPeersVal.Depth = 0;
            this.materialLabelPeersVal.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelPeersVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelPeersVal.Location = new System.Drawing.Point(706, 196);
            this.materialLabelPeersVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelPeersVal.Name = "materialLabelPeersVal";
            this.materialLabelPeersVal.Size = new System.Drawing.Size(24, 19);
            this.materialLabelPeersVal.TabIndex = 6;
            this.materialLabelPeersVal.Text = "...";
            // 
            // materialLabelPeers
            // 
            this.materialLabelPeers.AutoSize = true;
            this.materialLabelPeers.Depth = 0;
            this.materialLabelPeers.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelPeers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelPeers.Location = new System.Drawing.Point(482, 196);
            this.materialLabelPeers.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelPeers.Name = "materialLabelPeers";
            this.materialLabelPeers.Size = new System.Drawing.Size(136, 19);
            this.materialLabelPeers.TabIndex = 5;
            this.materialLabelPeers.Text = "Connected Peers";
            // 
            // materialLabelUsers
            // 
            this.materialLabelUsers.AutoSize = true;
            this.materialLabelUsers.Depth = 0;
            this.materialLabelUsers.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelUsers.Location = new System.Drawing.Point(482, 151);
            this.materialLabelUsers.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelUsers.Name = "materialLabelUsers";
            this.materialLabelUsers.Size = new System.Drawing.Size(51, 19);
            this.materialLabelUsers.TabIndex = 4;
            this.materialLabelUsers.Text = "Users";
            // 
            // materialLabelTransactionsVal
            // 
            this.materialLabelTransactionsVal.AutoSize = true;
            this.materialLabelTransactionsVal.Depth = 0;
            this.materialLabelTransactionsVal.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelTransactionsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelTransactionsVal.Location = new System.Drawing.Point(706, 61);
            this.materialLabelTransactionsVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelTransactionsVal.Name = "materialLabelTransactionsVal";
            this.materialLabelTransactionsVal.Size = new System.Drawing.Size(24, 19);
            this.materialLabelTransactionsVal.TabIndex = 3;
            this.materialLabelTransactionsVal.Text = "...";
            // 
            // materialLabelBlocksVal
            // 
            this.materialLabelBlocksVal.AutoSize = true;
            this.materialLabelBlocksVal.Depth = 0;
            this.materialLabelBlocksVal.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelBlocksVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelBlocksVal.Location = new System.Drawing.Point(706, 106);
            this.materialLabelBlocksVal.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelBlocksVal.Name = "materialLabelBlocksVal";
            this.materialLabelBlocksVal.Size = new System.Drawing.Size(24, 19);
            this.materialLabelBlocksVal.TabIndex = 2;
            this.materialLabelBlocksVal.Text = "...";
            // 
            // materialLabelBlocks
            // 
            this.materialLabelBlocks.AutoSize = true;
            this.materialLabelBlocks.Depth = 0;
            this.materialLabelBlocks.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelBlocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelBlocks.Location = new System.Drawing.Point(482, 106);
            this.materialLabelBlocks.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelBlocks.Name = "materialLabelBlocks";
            this.materialLabelBlocks.Size = new System.Drawing.Size(57, 19);
            this.materialLabelBlocks.TabIndex = 1;
            this.materialLabelBlocks.Text = "Blocks";
            // 
            // materialLabelTransactions
            // 
            this.materialLabelTransactions.AutoSize = true;
            this.materialLabelTransactions.Depth = 0;
            this.materialLabelTransactions.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelTransactions.Location = new System.Drawing.Point(482, 61);
            this.materialLabelTransactions.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelTransactions.Name = "materialLabelTransactions";
            this.materialLabelTransactions.Size = new System.Drawing.Size(101, 19);
            this.materialLabelTransactions.TabIndex = 0;
            this.materialLabelTransactions.Text = "Transactions";
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.BackColor = System.Drawing.Color.White;
            this.tabPageOptions.Controls.Add(this.materialDivider2);
            this.tabPageOptions.Controls.Add(this.materialLabelNetwork);
            this.tabPageOptions.Controls.Add(this.buttonStop);
            this.tabPageOptions.Controls.Add(this.buttonStart);
            this.tabPageOptions.Controls.Add(this.materialLabelAbout);
            this.tabPageOptions.Controls.Add(this.materialCheckBoxCreateBlocks);
            this.tabPageOptions.Controls.Add(this.materialRaisedButtonTheme);
            this.tabPageOptions.Controls.Add(this.materialLabelConsole);
            this.tabPageOptions.Controls.Add(this.materialLabelTrackers);
            this.tabPageOptions.Controls.Add(this.textBoxConsole);
            this.tabPageOptions.Controls.Add(this.textBoxTrackers);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 25);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(812, 396);
            this.tabPageOptions.TabIndex = 1;
            this.tabPageOptions.Text = "Options";
            // 
            // materialDivider2
            // 
            this.materialDivider2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(311, 0);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(10, 379);
            this.materialDivider2.TabIndex = 17;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // materialLabelNetwork
            // 
            this.materialLabelNetwork.AutoSize = true;
            this.materialLabelNetwork.Depth = 0;
            this.materialLabelNetwork.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelNetwork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelNetwork.Location = new System.Drawing.Point(36, 217);
            this.materialLabelNetwork.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelNetwork.Name = "materialLabelNetwork";
            this.materialLabelNetwork.Size = new System.Drawing.Size(152, 19);
            this.materialLabelNetwork.TabIndex = 16;
            this.materialLabelNetwork.Text = "Network connection";
            // 
            // buttonStop
            // 
            this.buttonStop.Depth = 0;
            this.buttonStop.Location = new System.Drawing.Point(177, 251);
            this.buttonStop.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(105, 30);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Depth = 0;
            this.buttonStart.Location = new System.Drawing.Point(40, 251);
            this.buttonStart.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(105, 30);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // materialLabelAbout
            // 
            this.materialLabelAbout.BackColor = System.Drawing.Color.Transparent;
            this.materialLabelAbout.Depth = 0;
            this.materialLabelAbout.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelAbout.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.materialLabelAbout.Location = new System.Drawing.Point(137, 329);
            this.materialLabelAbout.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelAbout.Name = "materialLabelAbout";
            this.materialLabelAbout.Size = new System.Drawing.Size(145, 64);
            this.materialLabelAbout.TabIndex = 13;
            this.materialLabelAbout.Text = "About";
            this.materialLabelAbout.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.materialLabelAbout.VisibleChanged += new System.EventHandler(this.materialLabelAbout_VisibleChanged);
            // 
            // materialCheckBoxCreateBlocks
            // 
            this.materialCheckBoxCreateBlocks.AutoSize = true;
            this.materialCheckBoxCreateBlocks.BackColor = System.Drawing.Color.Transparent;
            this.materialCheckBoxCreateBlocks.Depth = 0;
            this.materialCheckBoxCreateBlocks.Font = new System.Drawing.Font("Arial", 10F);
            this.materialCheckBoxCreateBlocks.ForeColor = System.Drawing.SystemColors.ControlText;
            this.materialCheckBoxCreateBlocks.Location = new System.Drawing.Point(34, 110);
            this.materialCheckBoxCreateBlocks.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBoxCreateBlocks.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBoxCreateBlocks.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBoxCreateBlocks.Name = "materialCheckBoxCreateBlocks";
            this.materialCheckBoxCreateBlocks.Ripple = true;
            this.materialCheckBoxCreateBlocks.Size = new System.Drawing.Size(136, 30);
            this.materialCheckBoxCreateBlocks.TabIndex = 9;
            this.materialCheckBoxCreateBlocks.Text = "Create blocks";
            this.materialCheckBoxCreateBlocks.UseVisualStyleBackColor = false;
            this.materialCheckBoxCreateBlocks.CheckedChanged += new System.EventHandler(this.materialCheckBoxCreateBlocks_CheckedChanged);
            // 
            // materialLabelConsole
            // 
            this.materialLabelConsole.AutoSize = true;
            this.materialLabelConsole.Depth = 0;
            this.materialLabelConsole.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelConsole.Location = new System.Drawing.Point(350, 3);
            this.materialLabelConsole.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelConsole.Name = "materialLabelConsole";
            this.materialLabelConsole.Size = new System.Drawing.Size(68, 19);
            this.materialLabelConsole.TabIndex = 11;
            this.materialLabelConsole.Text = "Console";
            // 
            // materialLabelTrackers
            // 
            this.materialLabelTrackers.AutoSize = true;
            this.materialLabelTrackers.Depth = 0;
            this.materialLabelTrackers.Font = new System.Drawing.Font("Arial", 10F);
            this.materialLabelTrackers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelTrackers.Location = new System.Drawing.Point(35, 3);
            this.materialLabelTrackers.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelTrackers.Name = "materialLabelTrackers";
            this.materialLabelTrackers.Size = new System.Drawing.Size(72, 19);
            this.materialLabelTrackers.TabIndex = 10;
            this.materialLabelTrackers.Text = "Trackers";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConsole.Location = new System.Drawing.Point(354, 33);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxConsole.Size = new System.Drawing.Size(422, 333);
            this.textBoxConsole.TabIndex = 9;
            this.textBoxConsole.WordWrap = false;
            // 
            // textBoxTrackers
            // 
            this.textBoxTrackers.Location = new System.Drawing.Point(40, 33);
            this.textBoxTrackers.Multiline = true;
            this.textBoxTrackers.Name = "textBoxTrackers";
            this.textBoxTrackers.Size = new System.Drawing.Size(242, 55);
            this.textBoxTrackers.TabIndex = 8;
            this.textBoxTrackers.Text = "192.168.0.42";
            this.textBoxTrackers.TextChanged += new System.EventHandler(this.textBoxTrackers_TextChanged);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-20, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1844, 31);
            this.materialTabSelector1.TabIndex = 15;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 545);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(829, 545);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockChainVotings";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonTheme;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageOptions;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialLabel materialLabelAbout;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBoxCreateBlocks;
        private MaterialSkin.Controls.MaterialLabel materialLabelConsole;
        private MaterialSkin.Controls.MaterialLabel materialLabelTrackers;
        private System.Windows.Forms.TextBox textBoxConsole;
        private System.Windows.Forms.TextBox textBoxTrackers;
        private MaterialSkin.Controls.MaterialLabel materialLabelTransactionsVal;
        private MaterialSkin.Controls.MaterialLabel materialLabelBlocksVal;
        private MaterialSkin.Controls.MaterialLabel materialLabelBlocks;
        private MaterialSkin.Controls.MaterialLabel materialLabelTransactions;
        private MaterialSkin.Controls.MaterialRaisedButton buttonStop;
        private MaterialSkin.Controls.MaterialRaisedButton buttonStart;
        private MaterialSkin.Controls.MaterialLabel materialLabelUsersVal;
        private MaterialSkin.Controls.MaterialLabel materialLabelPeersVal;
        private MaterialSkin.Controls.MaterialLabel materialLabelPeers;
        private MaterialSkin.Controls.MaterialLabel materialLabelUsers;
        private MaterialSkin.Controls.MaterialLabel materialLabelTrackersVal;
        private MaterialSkin.Controls.MaterialLabel materialLabelConnectedTrackers;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonVote;
        private MaterialSkin.Controls.MaterialLabel materialLabelHello;
        private MaterialSkin.Controls.MaterialLabel materialLabelStatistics;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonCreateVoting;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonBanUser;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonCreateUser;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonUserStatistic;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonVotingStatistic;
        private MaterialSkin.Controls.MaterialLabel materialLabelNetwork;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialDivider materialDivider3;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonMyStatistic;
        private MaterialSkin.Controls.MaterialLabel materialLabelAvaliableVotings;
    }
}

