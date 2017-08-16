namespace TicTacToeV1
{
    partial class TicTacToe
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
            this.gameStatusBar = new System.Windows.Forms.StatusStrip();
            this.gameState = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayersTurnStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.debugStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.CPUMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEndGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPlayCPU = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAdvanceCPU = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRules = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSuperCPU = new System.Windows.Forms.ToolStripMenuItem();
            this.gameStatusBar.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameStatusBar
            // 
            this.gameStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameState,
            this.PlayersTurnStatus,
            this.debugStatus,
            this.CPUMode});
            this.gameStatusBar.Location = new System.Drawing.Point(0, 486);
            this.gameStatusBar.Name = "gameStatusBar";
            this.gameStatusBar.Size = new System.Drawing.Size(484, 22);
            this.gameStatusBar.TabIndex = 0;
            this.gameStatusBar.Text = "statusStrip1";
            // 
            // gameState
            // 
            this.gameState.Name = "gameState";
            this.gameState.Size = new System.Drawing.Size(67, 17);
            this.gameState.Text = "Game State";
            // 
            // PlayersTurnStatus
            // 
            this.PlayersTurnStatus.Name = "PlayersTurnStatus";
            this.PlayersTurnStatus.Size = new System.Drawing.Size(72, 17);
            this.PlayersTurnStatus.Text = "Players Turn";
            // 
            // debugStatus
            // 
            this.debugStatus.Name = "debugStatus";
            this.debugStatus.Size = new System.Drawing.Size(59, 17);
            this.debugStatus.Text = "Debugger";
            // 
            // CPUMode
            // 
            this.CPUMode.Name = "CPUMode";
            this.CPUMode.Size = new System.Drawing.Size(64, 17);
            this.CPUMode.Text = "CPU Mode";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemSetting,
            this.menuItemHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(484, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "Main Menu";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewGame,
            this.menuItemEndGame,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(50, 20);
            this.menuItemFile.Text = "&Game";
            // 
            // menuItemNewGame
            // 
            this.menuItemNewGame.Name = "menuItemNewGame";
            this.menuItemNewGame.Size = new System.Drawing.Size(132, 22);
            this.menuItemNewGame.Text = "&New Game";
            this.menuItemNewGame.Click += new System.EventHandler(this.menuItemNewGame_Click);
            // 
            // menuItemEndGame
            // 
            this.menuItemEndGame.Name = "menuItemEndGame";
            this.menuItemEndGame.Size = new System.Drawing.Size(132, 22);
            this.menuItemEndGame.Text = "&End Game";
            this.menuItemEndGame.Click += new System.EventHandler(this.menuItemEndGame_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(132, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemSetting
            // 
            this.menuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPlayCPU,
            this.menuItemAdvanceCPU,
            this.menuItemSuperCPU});
            this.menuItemSetting.Name = "menuItemSetting";
            this.menuItemSetting.Size = new System.Drawing.Size(56, 20);
            this.menuItemSetting.Text = "&Setting";
            // 
            // menuItemPlayCPU
            // 
            this.menuItemPlayCPU.Name = "menuItemPlayCPU";
            this.menuItemPlayCPU.Size = new System.Drawing.Size(152, 22);
            this.menuItemPlayCPU.Text = "Pla&y CPU";
            this.menuItemPlayCPU.Click += new System.EventHandler(this.menuItemPlayCPU_Click);
            // 
            // menuItemAdvanceCPU
            // 
            this.menuItemAdvanceCPU.Name = "menuItemAdvanceCPU";
            this.menuItemAdvanceCPU.Size = new System.Drawing.Size(152, 22);
            this.menuItemAdvanceCPU.Text = "&Advance CPU";
            this.menuItemAdvanceCPU.Click += new System.EventHandler(this.menuItemAdvanceCPU_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRules,
            this.menuItemInfo});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemRules
            // 
            this.menuItemRules.Name = "menuItemRules";
            this.menuItemRules.Size = new System.Drawing.Size(152, 22);
            this.menuItemRules.Text = "&Rules";
            this.menuItemRules.Click += new System.EventHandler(this.menuItemRules_Click);
            // 
            // menuItemInfo
            // 
            this.menuItemInfo.Name = "menuItemInfo";
            this.menuItemInfo.Size = new System.Drawing.Size(152, 22);
            this.menuItemInfo.Text = "&Info";
            this.menuItemInfo.Click += new System.EventHandler(this.menuItemInfo_Click);
            // 
            // menuItemSuperCPU
            // 
            this.menuItemSuperCPU.Name = "menuItemSuperCPU";
            this.menuItemSuperCPU.Size = new System.Drawing.Size(152, 22);
            this.menuItemSuperCPU.Text = "S&uper CPU";
            this.menuItemSuperCPU.Click += new System.EventHandler(this.menuItemSuperCPU_Click);
            // 
            // TicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 508);
            this.Controls.Add(this.gameStatusBar);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicTacToe";
            this.Text = "Tic Tac Toe";
            this.Load += new System.EventHandler(this.TicTacToe_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TicTacToe_MouseClick);
            this.gameStatusBar.ResumeLayout(false);
            this.gameStatusBar.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip gameStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel gameState;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewGame;
        private System.Windows.Forms.ToolStripMenuItem menuItemEndGame;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemRules;
        private System.Windows.Forms.ToolStripMenuItem menuItemInfo;
        private System.Windows.Forms.ToolStripStatusLabel PlayersTurnStatus;
        private System.Windows.Forms.ToolStripMenuItem menuItemPlayCPU;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdvanceCPU;
        private System.Windows.Forms.ToolStripStatusLabel debugStatus;
        private System.Windows.Forms.ToolStripStatusLabel CPUMode;
        private System.Windows.Forms.ToolStripMenuItem menuItemSuperCPU;
    }
}

