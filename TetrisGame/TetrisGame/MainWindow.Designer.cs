namespace TetrisGame
{
    partial class MainWindow
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
            this.TempBox = new System.Windows.Forms.GroupBox();
            this.MinoPlaceholder = new System.Windows.Forms.GroupBox();
            this.NextMinoPic = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.CurrentLevel = new System.Windows.Forms.Label();
            this.CurrentLines = new System.Windows.Forms.Label();
            this.CurrentLineValue = new System.Windows.Forms.Label();
            this.NextLevelLabel = new System.Windows.Forms.Label();
            this.NextLevelValue = new System.Windows.Forms.Label();
            this.gameStatus = new System.Windows.Forms.StatusStrip();
            this.gameStateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAdvance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemResetGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEndGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPause = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGameInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemScorceBoards = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNormalMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAdvanceMode = new System.Windows.Forms.ToolStripMenuItem();
            this.ScoreValue = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.PlayerName = new System.Windows.Forms.Label();
            this.playerNameBox = new System.Windows.Forms.TextBox();
            this.modeLabel = new System.Windows.Forms.Label();
            this.modeValue = new System.Windows.Forms.Label();
            this.gameStatus.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TempBox
            // 
            this.TempBox.BackColor = System.Drawing.Color.Transparent;
            this.TempBox.Location = new System.Drawing.Point(150, 40);
            this.TempBox.Name = "TempBox";
            this.TempBox.Size = new System.Drawing.Size(240, 540);
            this.TempBox.TabIndex = 0;
            this.TempBox.TabStop = false;
            this.TempBox.Text = "Temp placeholder";
            this.TempBox.Visible = false;
            // 
            // MinoPlaceholder
            // 
            this.MinoPlaceholder.BackColor = System.Drawing.Color.Transparent;
            this.MinoPlaceholder.Location = new System.Drawing.Point(420, 80);
            this.MinoPlaceholder.Name = "MinoPlaceholder";
            this.MinoPlaceholder.Size = new System.Drawing.Size(100, 100);
            this.MinoPlaceholder.TabIndex = 1;
            this.MinoPlaceholder.TabStop = false;
            this.MinoPlaceholder.Text = "Temp placeholder";
            this.MinoPlaceholder.Visible = false;
            // 
            // NextMinoPic
            // 
            this.NextMinoPic.AutoSize = true;
            this.NextMinoPic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.NextMinoPic.Location = new System.Drawing.Point(426, 57);
            this.NextMinoPic.Name = "NextMinoPic";
            this.NextMinoPic.Size = new System.Drawing.Size(88, 20);
            this.NextMinoPic.TabIndex = 2;
            this.NextMinoPic.Text = "Next Mino";
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.LevelLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LevelLabel.Location = new System.Drawing.Point(13, 63);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(51, 20);
            this.LevelLabel.TabIndex = 3;
            this.LevelLabel.Text = "Level";
            // 
            // CurrentLevel
            // 
            this.CurrentLevel.AutoSize = true;
            this.CurrentLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CurrentLevel.ForeColor = System.Drawing.Color.Red;
            this.CurrentLevel.Location = new System.Drawing.Point(95, 63);
            this.CurrentLevel.Name = "CurrentLevel";
            this.CurrentLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CurrentLevel.Size = new System.Drawing.Size(49, 20);
            this.CurrentLevel.TabIndex = 4;
            this.CurrentLevel.Text = "0000";
            // 
            // CurrentLines
            // 
            this.CurrentLines.AutoSize = true;
            this.CurrentLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CurrentLines.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CurrentLines.Location = new System.Drawing.Point(13, 120);
            this.CurrentLines.Name = "CurrentLines";
            this.CurrentLines.Size = new System.Drawing.Size(52, 20);
            this.CurrentLines.TabIndex = 5;
            this.CurrentLines.Text = "Lines";
            // 
            // CurrentLineValue
            // 
            this.CurrentLineValue.AutoSize = true;
            this.CurrentLineValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CurrentLineValue.ForeColor = System.Drawing.Color.Red;
            this.CurrentLineValue.Location = new System.Drawing.Point(95, 120);
            this.CurrentLineValue.Name = "CurrentLineValue";
            this.CurrentLineValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CurrentLineValue.Size = new System.Drawing.Size(49, 20);
            this.CurrentLineValue.TabIndex = 6;
            this.CurrentLineValue.Text = "0000";
            // 
            // NextLevelLabel
            // 
            this.NextLevelLabel.AutoSize = true;
            this.NextLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.NextLevelLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NextLevelLabel.Location = new System.Drawing.Point(13, 177);
            this.NextLevelLabel.Name = "NextLevelLabel";
            this.NextLevelLabel.Size = new System.Drawing.Size(70, 20);
            this.NextLevelLabel.TabIndex = 7;
            this.NextLevelLabel.Text = "To Next";
            // 
            // NextLevelValue
            // 
            this.NextLevelValue.AutoSize = true;
            this.NextLevelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.NextLevelValue.ForeColor = System.Drawing.Color.Red;
            this.NextLevelValue.Location = new System.Drawing.Point(95, 177);
            this.NextLevelValue.Name = "NextLevelValue";
            this.NextLevelValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NextLevelValue.Size = new System.Drawing.Size(49, 20);
            this.NextLevelValue.TabIndex = 8;
            this.NextLevelValue.Text = "0000";
            // 
            // gameStatus
            // 
            this.gameStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStateLabel});
            this.gameStatus.Location = new System.Drawing.Point(0, 600);
            this.gameStatus.Name = "gameStatus";
            this.gameStatus.Size = new System.Drawing.Size(564, 22);
            this.gameStatus.TabIndex = 9;
            this.gameStatus.Text = "statusStrip1";
            // 
            // gameStateLabel
            // 
            this.gameStateLabel.Name = "gameStateLabel";
            this.gameStateLabel.Size = new System.Drawing.Size(73, 17);
            this.gameStateLabel.Text = "Game Status";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemGame,
            this.menuItemSetting,
            this.infoToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(564, 24);
            this.mainMenu.TabIndex = 10;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuItemGame
            // 
            this.menuItemGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSave,
            this.menuItemLoad,
            this.menuItemExit});
            this.menuItemGame.Name = "menuItemGame";
            this.menuItemGame.Size = new System.Drawing.Size(50, 20);
            this.menuItemGame.Text = "&Game";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Size = new System.Drawing.Size(133, 22);
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemLoad
            // 
            this.menuItemLoad.Name = "menuItemLoad";
            this.menuItemLoad.Size = new System.Drawing.Size(133, 22);
            this.menuItemLoad.Text = "&Load";
            this.menuItemLoad.Click += new System.EventHandler(this.menuItemLoad_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuItemExit.Size = new System.Drawing.Size(133, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemSetting
            // 
            this.menuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemGameMode,
            this.menuItemNewGame,
            this.menuItemResetGame,
            this.menuItemEndGame,
            this.menuItemPause});
            this.menuItemSetting.Name = "menuItemSetting";
            this.menuItemSetting.Size = new System.Drawing.Size(56, 20);
            this.menuItemSetting.Text = "S&etting";
            // 
            // menuItemGameMode
            // 
            this.menuItemGameMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNormal,
            this.menuItemAdvance});
            this.menuItemGameMode.Name = "menuItemGameMode";
            this.menuItemGameMode.Size = new System.Drawing.Size(177, 22);
            this.menuItemGameMode.Text = "Game &Mode";
            // 
            // menuItemNormal
            // 
            this.menuItemNormal.Name = "menuItemNormal";
            this.menuItemNormal.Size = new System.Drawing.Size(120, 22);
            this.menuItemNormal.Text = "&Normal";
            this.menuItemNormal.Click += new System.EventHandler(this.menuItemNormal_Click);
            // 
            // menuItemAdvance
            // 
            this.menuItemAdvance.Name = "menuItemAdvance";
            this.menuItemAdvance.Size = new System.Drawing.Size(120, 22);
            this.menuItemAdvance.Text = "&Advance";
            this.menuItemAdvance.Click += new System.EventHandler(this.menuItemAdvance_Click);
            // 
            // menuItemNewGame
            // 
            this.menuItemNewGame.Name = "menuItemNewGame";
            this.menuItemNewGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.menuItemNewGame.Size = new System.Drawing.Size(177, 22);
            this.menuItemNewGame.Text = "New &Game";
            this.menuItemNewGame.Click += new System.EventHandler(this.menuItemNewGame_Click);
            // 
            // menuItemResetGame
            // 
            this.menuItemResetGame.Name = "menuItemResetGame";
            this.menuItemResetGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuItemResetGame.Size = new System.Drawing.Size(177, 22);
            this.menuItemResetGame.Text = "&Reset Game";
            this.menuItemResetGame.Click += new System.EventHandler(this.menuItemResetGame_Click);
            // 
            // menuItemEndGame
            // 
            this.menuItemEndGame.Name = "menuItemEndGame";
            this.menuItemEndGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuItemEndGame.Size = new System.Drawing.Size(177, 22);
            this.menuItemEndGame.Text = "En&d Game";
            this.menuItemEndGame.Click += new System.EventHandler(this.menuItemEndGame_Click);
            // 
            // menuItemPause
            // 
            this.menuItemPause.Name = "menuItemPause";
            this.menuItemPause.Size = new System.Drawing.Size(177, 22);
            this.menuItemPause.Text = "&Pause";
            this.menuItemPause.Click += new System.EventHandler(this.menuItemPause_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelp,
            this.menuItemGameInfo,
            this.menuItemScorceBoards});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "&Info";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(142, 22);
            this.menuItemHelp.Text = "&Help";
            this.menuItemHelp.Click += new System.EventHandler(this.menuItemHelp_Click);
            // 
            // menuItemGameInfo
            // 
            this.menuItemGameInfo.Name = "menuItemGameInfo";
            this.menuItemGameInfo.Size = new System.Drawing.Size(142, 22);
            this.menuItemGameInfo.Text = "Game I&nfo";
            this.menuItemGameInfo.Click += new System.EventHandler(this.menuItemGameInfo_Click);
            // 
            // menuItemScorceBoards
            // 
            this.menuItemScorceBoards.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNormalMode,
            this.menuItemAdvanceMode});
            this.menuItemScorceBoards.Name = "menuItemScorceBoards";
            this.menuItemScorceBoards.Size = new System.Drawing.Size(142, 22);
            this.menuItemScorceBoards.Text = "Score &Boards";
            // 
            // menuItemNormalMode
            // 
            this.menuItemNormalMode.Name = "menuItemNormalMode";
            this.menuItemNormalMode.Size = new System.Drawing.Size(154, 22);
            this.menuItemNormalMode.Text = "Normal Mode";
            this.menuItemNormalMode.Click += new System.EventHandler(this.menuItemNormalMode_Click);
            // 
            // menuItemAdvanceMode
            // 
            this.menuItemAdvanceMode.Name = "menuItemAdvanceMode";
            this.menuItemAdvanceMode.Size = new System.Drawing.Size(154, 22);
            this.menuItemAdvanceMode.Text = "Advance Mode";
            this.menuItemAdvanceMode.Click += new System.EventHandler(this.menuItemAdvanceMode_Click);
            // 
            // ScoreValue
            // 
            this.ScoreValue.AutoSize = true;
            this.ScoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ScoreValue.ForeColor = System.Drawing.Color.Red;
            this.ScoreValue.Location = new System.Drawing.Point(75, 234);
            this.ScoreValue.Name = "ScoreValue";
            this.ScoreValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ScoreValue.Size = new System.Drawing.Size(69, 20);
            this.ScoreValue.TabIndex = 12;
            this.ScoreValue.Text = "000000";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ScoreLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ScoreLabel.Location = new System.Drawing.Point(13, 234);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(56, 20);
            this.ScoreLabel.TabIndex = 11;
            this.ScoreLabel.Text = "Score";
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSize = true;
            this.PlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerName.Location = new System.Drawing.Point(420, 187);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(110, 16);
            this.PlayerName.TabIndex = 13;
            this.PlayerName.Text = "Player\'s Name";
            // 
            // playerNameBox
            // 
            this.playerNameBox.Location = new System.Drawing.Point(423, 206);
            this.playerNameBox.Name = "playerNameBox";
            this.playerNameBox.ShortcutsEnabled = false;
            this.playerNameBox.Size = new System.Drawing.Size(107, 20);
            this.playerNameBox.TabIndex = 14;
            this.playerNameBox.Text = "Player";
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.modeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.modeLabel.Location = new System.Drawing.Point(419, 245);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(53, 20);
            this.modeLabel.TabIndex = 15;
            this.modeLabel.Text = "Mode";
            // 
            // modeValue
            // 
            this.modeValue.AutoSize = true;
            this.modeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.modeValue.ForeColor = System.Drawing.Color.Red;
            this.modeValue.Location = new System.Drawing.Point(423, 280);
            this.modeValue.Name = "modeValue";
            this.modeValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.modeValue.Size = new System.Drawing.Size(106, 20);
            this.modeValue.TabIndex = 16;
            this.modeValue.Text = "Game Mode";
            this.modeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 622);
            this.Controls.Add(this.modeValue);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.playerNameBox);
            this.Controls.Add(this.PlayerName);
            this.Controls.Add(this.ScoreValue);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.gameStatus);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.NextLevelValue);
            this.Controls.Add(this.NextLevelLabel);
            this.Controls.Add(this.CurrentLineValue);
            this.Controls.Add(this.CurrentLines);
            this.Controls.Add(this.CurrentLevel);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.NextMinoPic);
            this.Controls.Add(this.MinoPlaceholder);
            this.Controls.Add(this.TempBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.gameStatus.ResumeLayout(false);
            this.gameStatus.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox TempBox;
        private System.Windows.Forms.GroupBox MinoPlaceholder;
        private System.Windows.Forms.Label NextMinoPic;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label CurrentLevel;
        private System.Windows.Forms.Label CurrentLines;
        private System.Windows.Forms.Label CurrentLineValue;
        private System.Windows.Forms.Label NextLevelLabel;
        private System.Windows.Forms.Label NextLevelValue;
        private System.Windows.Forms.StatusStrip gameStatus;
        private System.Windows.Forms.ToolStripStatusLabel gameStateLabel;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemGame;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoad;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem menuItemGameMode;
        private System.Windows.Forms.ToolStripMenuItem menuItemNormal;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdvance;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewGame;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemGameInfo;
        private System.Windows.Forms.ToolStripMenuItem menuItemPause;
        private System.Windows.Forms.ToolStripMenuItem menuItemEndGame;
        private System.Windows.Forms.Label ScoreValue;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.ToolStripMenuItem menuItemScorceBoards;
        private System.Windows.Forms.ToolStripMenuItem menuItemNormalMode;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdvanceMode;
        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.TextBox playerNameBox;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetGame;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label modeValue;

    }
}

