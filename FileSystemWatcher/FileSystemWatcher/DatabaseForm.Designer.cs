namespace FileWatcher
{
    partial class DatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseForm));
            this.DatabaseViewer = new System.Windows.Forms.DataGridView();
            this.DatabaseViewerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseViewerCurrPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseViewerPrevPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatebaseViewerEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseViewerDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseSubmit = new System.Windows.Forms.Button();
            this.extensionBox = new System.Windows.Forms.TextBox();
            this.extensionQuery = new System.Windows.Forms.Label();
            this.extensionList = new System.Windows.Forms.Label();
            this.QueryStatusBar = new System.Windows.Forms.StatusStrip();
            this.QueryStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.databaseMenu = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRunQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClearQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDeleteQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExitWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLoadDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveDatabaseAs = new System.Windows.Forms.ToolStripMenuItem();
            this.run = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.FileNameLable = new System.Windows.Forms.Label();
            this.FileLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseViewer)).BeginInit();
            this.QueryStatusBar.SuspendLayout();
            this.databaseMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatabaseViewer
            // 
            this.DatabaseViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatabaseViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatabaseViewerName,
            this.DatabaseViewerCurrPath,
            this.DatabaseViewerPrevPath,
            this.DatebaseViewerEventType,
            this.DatabaseViewerDate});
            this.DatabaseViewer.Location = new System.Drawing.Point(12, 103);
            this.DatabaseViewer.Name = "DatabaseViewer";
            this.DatabaseViewer.Size = new System.Drawing.Size(1110, 307);
            this.DatabaseViewer.TabIndex = 0;
            // 
            // DatabaseViewerName
            // 
            this.DatabaseViewerName.HeaderText = "Name";
            this.DatabaseViewerName.Name = "DatabaseViewerName";
            this.DatabaseViewerName.Width = 200;
            // 
            // DatabaseViewerCurrPath
            // 
            this.DatabaseViewerCurrPath.HeaderText = "currPath";
            this.DatabaseViewerCurrPath.Name = "DatabaseViewerCurrPath";
            this.DatabaseViewerCurrPath.Width = 325;
            // 
            // DatabaseViewerPrevPath
            // 
            this.DatabaseViewerPrevPath.HeaderText = "prevPath";
            this.DatabaseViewerPrevPath.Name = "DatabaseViewerPrevPath";
            this.DatabaseViewerPrevPath.Width = 325;
            // 
            // DatebaseViewerEventType
            // 
            this.DatebaseViewerEventType.HeaderText = "eventType";
            this.DatebaseViewerEventType.Name = "DatebaseViewerEventType";
            // 
            // DatabaseViewerDate
            // 
            this.DatabaseViewerDate.HeaderText = "Date";
            this.DatabaseViewerDate.Name = "DatabaseViewerDate";
            // 
            // databaseSubmit
            // 
            this.databaseSubmit.Location = new System.Drawing.Point(453, 74);
            this.databaseSubmit.Name = "databaseSubmit";
            this.databaseSubmit.Size = new System.Drawing.Size(75, 23);
            this.databaseSubmit.TabIndex = 1;
            this.databaseSubmit.Text = "&Submit";
            this.databaseSubmit.UseVisualStyleBackColor = true;
            this.databaseSubmit.Click += new System.EventHandler(this.DatabaseSubmit_Click);
            // 
            // extensionBox
            // 
            this.extensionBox.Location = new System.Drawing.Point(347, 77);
            this.extensionBox.Name = "extensionBox";
            this.extensionBox.Size = new System.Drawing.Size(100, 20);
            this.extensionBox.TabIndex = 2;
            // 
            // extensionQuery
            // 
            this.extensionQuery.AutoSize = true;
            this.extensionQuery.Location = new System.Drawing.Point(344, 58);
            this.extensionQuery.Name = "extensionQuery";
            this.extensionQuery.Size = new System.Drawing.Size(87, 13);
            this.extensionQuery.TabIndex = 3;
            this.extensionQuery.Text = "Extension Query:";
            // 
            // extensionList
            // 
            this.extensionList.AutoSize = true;
            this.extensionList.Location = new System.Drawing.Point(450, 58);
            this.extensionList.Name = "extensionList";
            this.extensionList.Size = new System.Drawing.Size(36, 13);
            this.extensionList.TabIndex = 4;
            this.extensionList.Text = "Empty";
            // 
            // QueryStatusBar
            // 
            this.QueryStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QueryStatusText});
            this.QueryStatusBar.Location = new System.Drawing.Point(0, 420);
            this.QueryStatusBar.Name = "QueryStatusBar";
            this.QueryStatusBar.Size = new System.Drawing.Size(1134, 22);
            this.QueryStatusBar.TabIndex = 5;
            this.QueryStatusBar.Text = "Query Status Bar";
            // 
            // QueryStatusText
            // 
            this.QueryStatusText.Name = "QueryStatusText";
            this.QueryStatusText.Size = new System.Drawing.Size(74, 17);
            this.QueryStatusText.Text = "Query Status";
            // 
            // databaseMenu
            // 
            this.databaseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemDatabase});
            this.databaseMenu.Location = new System.Drawing.Point(0, 0);
            this.databaseMenu.Name = "databaseMenu";
            this.databaseMenu.Size = new System.Drawing.Size(1134, 24);
            this.databaseMenu.TabIndex = 6;
            this.databaseMenu.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemRunQuery,
            this.MenuItemClearQuery,
            this.MenuItemDeleteQuery,
            this.MenuItemExitWindow});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MenuItemFile.Text = "&File";
            // 
            // MenuItemRunQuery
            // 
            this.MenuItemRunQuery.Name = "MenuItemRunQuery";
            this.MenuItemRunQuery.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.MenuItemRunQuery.Size = new System.Drawing.Size(184, 22);
            this.MenuItemRunQuery.Text = "&Run Query";
            this.MenuItemRunQuery.Click += new System.EventHandler(this.menuItemRunQuery_Click);
            // 
            // MenuItemClearQuery
            // 
            this.MenuItemClearQuery.Name = "MenuItemClearQuery";
            this.MenuItemClearQuery.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MenuItemClearQuery.Size = new System.Drawing.Size(184, 22);
            this.MenuItemClearQuery.Text = "&Clear Query";
            this.MenuItemClearQuery.Click += new System.EventHandler(this.menuItemClearQuery_Click);
            // 
            // MenuItemDeleteQuery
            // 
            this.MenuItemDeleteQuery.Name = "MenuItemDeleteQuery";
            this.MenuItemDeleteQuery.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.MenuItemDeleteQuery.Size = new System.Drawing.Size(184, 22);
            this.MenuItemDeleteQuery.Text = "&Delete Query";
            this.MenuItemDeleteQuery.Click += new System.EventHandler(this.menuItemDeleteQuery_Click);
            // 
            // MenuItemExitWindow
            // 
            this.MenuItemExitWindow.Name = "MenuItemExitWindow";
            this.MenuItemExitWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MenuItemExitWindow.Size = new System.Drawing.Size(184, 22);
            this.MenuItemExitWindow.Text = "&Exit Window";
            this.MenuItemExitWindow.Click += new System.EventHandler(this.menuItemExitWindow_Click);
            // 
            // MenuItemDatabase
            // 
            this.MenuItemDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLoadDatabase,
            this.MenuItemSaveDatabase,
            this.MenuItemSaveDatabaseAs});
            this.MenuItemDatabase.Name = "MenuItemDatabase";
            this.MenuItemDatabase.Size = new System.Drawing.Size(67, 20);
            this.MenuItemDatabase.Text = "&Database";
            // 
            // MenuItemLoadDatabase
            // 
            this.MenuItemLoadDatabase.Name = "MenuItemLoadDatabase";
            this.MenuItemLoadDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.MenuItemLoadDatabase.Size = new System.Drawing.Size(207, 22);
            this.MenuItemLoadDatabase.Text = "&Load Database";
            this.MenuItemLoadDatabase.Click += new System.EventHandler(this.menuItemLoadDatabase_Click);
            // 
            // MenuItemSaveDatabase
            // 
            this.MenuItemSaveDatabase.Name = "MenuItemSaveDatabase";
            this.MenuItemSaveDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSaveDatabase.Size = new System.Drawing.Size(207, 22);
            this.MenuItemSaveDatabase.Text = "&Save Database";
            this.MenuItemSaveDatabase.Click += new System.EventHandler(this.MenuItemSaveDatabase_Click);
            // 
            // MenuItemSaveDatabaseAs
            // 
            this.MenuItemSaveDatabaseAs.Name = "MenuItemSaveDatabaseAs";
            this.MenuItemSaveDatabaseAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.MenuItemSaveDatabaseAs.Size = new System.Drawing.Size(207, 22);
            this.MenuItemSaveDatabaseAs.Text = "S&ave Database As";
            this.MenuItemSaveDatabaseAs.Click += new System.EventHandler(this.MenuItemSaveDatabaseAs_Click);
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(12, 74);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(100, 23);
            this.run.TabIndex = 7;
            this.run.Text = "Run Query";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(118, 74);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(100, 23);
            this.clear.TabIndex = 8;
            this.clear.Text = "Clear Query";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(224, 74);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(100, 23);
            this.delete.TabIndex = 9;
            this.delete.Text = "Delete Query";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // FileNameLable
            // 
            this.FileNameLable.AutoSize = true;
            this.FileNameLable.Location = new System.Drawing.Point(9, 36);
            this.FileNameLable.Name = "FileNameLable";
            this.FileNameLable.Size = new System.Drawing.Size(54, 13);
            this.FileNameLable.TabIndex = 10;
            this.FileNameLable.Text = "File Name";
            // 
            // FileLable
            // 
            this.FileLable.AutoSize = true;
            this.FileLable.Location = new System.Drawing.Point(69, 36);
            this.FileLable.Name = "FileLable";
            this.FileLable.Size = new System.Drawing.Size(50, 13);
            this.FileLable.TabIndex = 11;
            this.FileLable.Text = "{ Empty }";
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 442);
            this.ControlBox = false;
            this.Controls.Add(this.FileLable);
            this.Controls.Add(this.FileNameLable);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.run);
            this.Controls.Add(this.QueryStatusBar);
            this.Controls.Add(this.databaseMenu);
            this.Controls.Add(this.extensionList);
            this.Controls.Add(this.extensionQuery);
            this.Controls.Add(this.extensionBox);
            this.Controls.Add(this.databaseSubmit);
            this.Controls.Add(this.DatabaseViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.databaseMenu;
            this.MaximizeBox = false;
            this.Name = "DatabaseForm";
            this.Text = "Database";
            this.Load += new System.EventHandler(this.DatabaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseViewer)).EndInit();
            this.QueryStatusBar.ResumeLayout(false);
            this.QueryStatusBar.PerformLayout();
            this.databaseMenu.ResumeLayout(false);
            this.databaseMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DatabaseViewer;
        private System.Windows.Forms.Button databaseSubmit;
        private System.Windows.Forms.TextBox extensionBox;
        private System.Windows.Forms.Label extensionQuery;
        private System.Windows.Forms.Label extensionList;
        private System.Windows.Forms.StatusStrip QueryStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel QueryStatusText;
        private System.Windows.Forms.MenuStrip databaseMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRunQuery;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDeleteQuery;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExitWindow;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseViewerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseViewerCurrPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseViewerPrevPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatebaseViewerEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseViewerDate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClearQuery;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDatabase;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLoadDatabase;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveDatabaseAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveDatabase;
        private System.Windows.Forms.Label FileNameLable;
        private System.Windows.Forms.Label FileLable;
    }
}