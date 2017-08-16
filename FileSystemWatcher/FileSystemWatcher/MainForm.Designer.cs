namespace FileWatcher
{
    partial class FileWatcherSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileWatcherSystem));
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.FileSystemStatusBar = new System.Windows.Forms.StatusStrip();
            this.FileSystemStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuSet = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetPath = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLoadDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveDatabaseAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCheckDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.PathText = new System.Windows.Forms.Label();
            this.ExtensionBox = new System.Windows.Forms.TextBox();
            this.ExtensionText = new System.Windows.Forms.Label();
            this.FileSystemWatcherSubmitButton = new System.Windows.Forms.Button();
            this.ListExtensions = new System.Windows.Forms.Label();
            this.FileViewText = new System.Windows.Forms.Label();
            this.PrevUsedExtensions = new System.Windows.Forms.ComboBox();
            this.PrevExtensionText = new System.Windows.Forms.Label();
            this.FileSystemViewer = new System.Windows.Forms.DataGridView();
            this.FileViewerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileViewerFullPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileViewerPrevPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileViewerEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileViewerDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetPath = new System.Windows.Forms.Button();
            this.radioButtonUseExtension = new System.Windows.Forms.RadioButton();
            this.radioButtonNoExtension = new System.Windows.Forms.RadioButton();
            this.pathGroup = new System.Windows.Forms.GroupBox();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.FileNameLable = new System.Windows.Forms.Label();
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.FileSystemStatusBar.SuspendLayout();
            this.MenuSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemViewer)).BeginInit();
            this.pathGroup.SuspendLayout();
            this.filterGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(6, 139);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(121, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "&Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(6, 168);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(121, 23);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "S&top";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // FileSystemStatusBar
            // 
            this.FileSystemStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSystemStatus});
            this.FileSystemStatusBar.Location = new System.Drawing.Point(0, 740);
            this.FileSystemStatusBar.Name = "FileSystemStatusBar";
            this.FileSystemStatusBar.Size = new System.Drawing.Size(1134, 22);
            this.FileSystemStatusBar.TabIndex = 3;
            this.FileSystemStatusBar.Text = "File System Status Bar";
            // 
            // FileSystemStatus
            // 
            this.FileSystemStatus.Name = "FileSystemStatus";
            this.FileSystemStatus.Size = new System.Drawing.Size(101, 17);
            this.FileSystemStatus.Text = "File System Status";
            // 
            // MenuSet
            // 
            this.MenuSet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.DatabaseToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.MenuSet.Location = new System.Drawing.Point(0, 0);
            this.MenuSet.Name = "MenuSet";
            this.MenuSet.Size = new System.Drawing.Size(1134, 24);
            this.MenuSet.TabIndex = 4;
            this.MenuSet.Text = "menuSet";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSetPath,
            this.MenuItemStart,
            this.MenuItemStop,
            this.MenuItemClose});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // MenuItemSetPath
            // 
            this.MenuItemSetPath.Name = "MenuItemSetPath";
            this.MenuItemSetPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.MenuItemSetPath.Size = new System.Drawing.Size(158, 22);
            this.MenuItemSetPath.Text = "Set &Path";
            this.MenuItemSetPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuItemSetPath.ToolTipText = "Set the path to watch";
            this.MenuItemSetPath.Click += new System.EventHandler(this.setPathToolStripMenuItem_Click);
            // 
            // MenuItemStart
            // 
            this.MenuItemStart.Name = "MenuItemStart";
            this.MenuItemStart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemStart.Size = new System.Drawing.Size(158, 22);
            this.MenuItemStart.Text = "&Start";
            this.MenuItemStart.ToolTipText = "Runs the watcher";
            this.MenuItemStart.Click += new System.EventHandler(this.MenuItemStart_Click);
            // 
            // MenuItemStop
            // 
            this.MenuItemStop.Name = "MenuItemStop";
            this.MenuItemStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.MenuItemStop.Size = new System.Drawing.Size(158, 22);
            this.MenuItemStop.Text = "S&top";
            this.MenuItemStop.ToolTipText = "End the watch";
            this.MenuItemStop.Click += new System.EventHandler(this.MenuItemStop_Click);
            // 
            // MenuItemClose
            // 
            this.MenuItemClose.Name = "MenuItemClose";
            this.MenuItemClose.ShortcutKeyDisplayString = "Ctrl+C";
            this.MenuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MenuItemClose.Size = new System.Drawing.Size(158, 22);
            this.MenuItemClose.Text = "&Close";
            this.MenuItemClose.Click += new System.EventHandler(this.MenuItemClose_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePathToolStripMenuItem,
            this.setFilterToolStripMenuItem,
            this.clearViewToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // changePathToolStripMenuItem
            // 
            this.changePathToolStripMenuItem.Name = "changePathToolStripMenuItem";
            this.changePathToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.changePathToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.changePathToolStripMenuItem.Text = "Change Pa&th";
            this.changePathToolStripMenuItem.Click += new System.EventHandler(this.changePathToolStripMenuItem_Click);
            // 
            // setFilterToolStripMenuItem
            // 
            this.setFilterToolStripMenuItem.Name = "setFilterToolStripMenuItem";
            this.setFilterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.setFilterToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.setFilterToolStripMenuItem.Text = "Set Filte&r";
            this.setFilterToolStripMenuItem.Click += new System.EventHandler(this.setFilterToolStripMenuItem_Click);
            // 
            // clearViewToolStripMenuItem
            // 
            this.clearViewToolStripMenuItem.Name = "clearViewToolStripMenuItem";
            this.clearViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.clearViewToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.clearViewToolStripMenuItem.Text = "Clear Vie&w";
            this.clearViewToolStripMenuItem.ToolTipText = "Clear the data from viewer";
            this.clearViewToolStripMenuItem.Click += new System.EventHandler(this.clearViewToolStripMenuItem_Click);
            // 
            // DatabaseToolStripMenuItem
            // 
            this.DatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLoadDatabase,
            this.saveDatabaseToolStripMenuItem,
            this.MenuItemSaveDatabaseAs,
            this.MenuItemCheckDatabase});
            this.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem";
            this.DatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DatabaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.DatabaseToolStripMenuItem.Text = "&Database";
            // 
            // MenuItemLoadDatabase
            // 
            this.MenuItemLoadDatabase.Name = "MenuItemLoadDatabase";
            this.MenuItemLoadDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.MenuItemLoadDatabase.Size = new System.Drawing.Size(207, 22);
            this.MenuItemLoadDatabase.Text = "&Load Database";
            this.MenuItemLoadDatabase.Click += new System.EventHandler(this.MenuItemLoadDatabase_Click);
            // 
            // saveDatabaseToolStripMenuItem
            // 
            this.saveDatabaseToolStripMenuItem.Name = "saveDatabaseToolStripMenuItem";
            this.saveDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.saveDatabaseToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.saveDatabaseToolStripMenuItem.Text = "Sa&ve Database";
            this.saveDatabaseToolStripMenuItem.Click += new System.EventHandler(this.MenuItemSaveDatabase_Click);
            // 
            // MenuItemSaveDatabaseAs
            // 
            this.MenuItemSaveDatabaseAs.Name = "MenuItemSaveDatabaseAs";
            this.MenuItemSaveDatabaseAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.MenuItemSaveDatabaseAs.Size = new System.Drawing.Size(207, 22);
            this.MenuItemSaveDatabaseAs.Text = "S&ave Database As";
            this.MenuItemSaveDatabaseAs.Click += new System.EventHandler(this.MenuItemSaveDatabaseAs_Click);
            // 
            // MenuItemCheckDatabase
            // 
            this.MenuItemCheckDatabase.Name = "MenuItemCheckDatabase";
            this.MenuItemCheckDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.MenuItemCheckDatabase.Size = new System.Drawing.Size(207, 22);
            this.MenuItemCheckDatabase.Text = "C&heck Database";
            this.MenuItemCheckDatabase.Click += new System.EventHandler(this.MenuItemCheckDatabase_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemInfo});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AboutToolStripMenuItem.Text = "A&bout";
            // 
            // MenuItemInfo
            // 
            this.MenuItemInfo.Name = "MenuItemInfo";
            this.MenuItemInfo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.MenuItemInfo.Size = new System.Drawing.Size(152, 22);
            this.MenuItemInfo.Text = "&Info";
            this.MenuItemInfo.Click += new System.EventHandler(this.MenuItemInfo_Click);
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(6, 84);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(773, 20);
            this.PathBox.TabIndex = 5;
            // 
            // PathText
            // 
            this.PathText.AutoSize = true;
            this.PathText.Location = new System.Drawing.Point(6, 68);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(39, 13);
            this.PathText.TabIndex = 6;
            this.PathText.Text = "PATH:";
            // 
            // ExtensionBox
            // 
            this.ExtensionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtensionBox.Location = new System.Drawing.Point(105, 83);
            this.ExtensionBox.Name = "ExtensionBox";
            this.ExtensionBox.Size = new System.Drawing.Size(139, 20);
            this.ExtensionBox.TabIndex = 7;
            // 
            // ExtensionText
            // 
            this.ExtensionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtensionText.AutoSize = true;
            this.ExtensionText.Location = new System.Drawing.Point(102, 67);
            this.ExtensionText.Name = "ExtensionText";
            this.ExtensionText.Size = new System.Drawing.Size(56, 13);
            this.ExtensionText.TabIndex = 8;
            this.ExtensionText.Text = "Extension:";
            // 
            // FileSystemWatcherSubmitButton
            // 
            this.FileSystemWatcherSubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileSystemWatcherSubmitButton.Location = new System.Drawing.Point(250, 80);
            this.FileSystemWatcherSubmitButton.Name = "FileSystemWatcherSubmitButton";
            this.FileSystemWatcherSubmitButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FileSystemWatcherSubmitButton.Size = new System.Drawing.Size(62, 23);
            this.FileSystemWatcherSubmitButton.TabIndex = 9;
            this.FileSystemWatcherSubmitButton.Text = "Sub&mit";
            this.FileSystemWatcherSubmitButton.UseVisualStyleBackColor = true;
            this.FileSystemWatcherSubmitButton.Click += new System.EventHandler(this.FileSystemWatcherSubmitButton_Click);
            // 
            // ListExtensions
            // 
            this.ListExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ListExtensions.AutoSize = true;
            this.ListExtensions.Location = new System.Drawing.Point(167, 67);
            this.ListExtensions.Name = "ListExtensions";
            this.ListExtensions.Size = new System.Drawing.Size(36, 13);
            this.ListExtensions.TabIndex = 10;
            this.ListExtensions.Text = "Empty";
            // 
            // FileViewText
            // 
            this.FileViewText.AutoSize = true;
            this.FileViewText.Location = new System.Drawing.Point(12, 228);
            this.FileViewText.Name = "FileViewText";
            this.FileViewText.Size = new System.Drawing.Size(96, 13);
            this.FileViewText.TabIndex = 13;
            this.FileViewText.Text = "File Watcher View:";
            // 
            // PrevUsedExtensions
            // 
            this.PrevUsedExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrevUsedExtensions.FormattingEnabled = true;
            this.PrevUsedExtensions.Items.AddRange(new object[] {
            "exe",
            "txt",
            "dll",
            "cs",
            "vb",
            "cbl",
            "c",
            "cpp",
            "h",
            "hpp",
            "bmp",
            "gif",
            "tiff",
            "tif",
            "png",
            "jpg",
            "jpeg",
            "pdf",
            "doc",
            "docx",
            "xsl",
            "xslx",
            "ppt",
            "pptx",
            "db",
            "xml",
            "htmp",
            "php",
            "as",
            "ada",
            "ads",
            "adb",
            "asp",
            "asm",
            "au3",
            "sh",
            "bsh",
            "bat",
            "cmd",
            "nt",
            "css",
            "f",
            "for",
            "f90",
            "f95",
            "f2k",
            "class",
            "java",
            "js",
            "mak",
            "py",
            "pyw",
            "sql",
            "v",
            "vhdl",
            "rex",
            "mips",
            "fs",
            "fsi",
            "dat",
            "LOG1",
            "sqlite",
            "db"});
            this.PrevUsedExtensions.Location = new System.Drawing.Point(105, 140);
            this.PrevUsedExtensions.Name = "PrevUsedExtensions";
            this.PrevUsedExtensions.Size = new System.Drawing.Size(207, 21);
            this.PrevUsedExtensions.TabIndex = 11;
            // 
            // PrevExtensionText
            // 
            this.PrevExtensionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrevExtensionText.AutoSize = true;
            this.PrevExtensionText.Location = new System.Drawing.Point(102, 124);
            this.PrevExtensionText.Name = "PrevExtensionText";
            this.PrevExtensionText.Size = new System.Drawing.Size(128, 13);
            this.PrevExtensionText.TabIndex = 14;
            this.PrevExtensionText.Text = "Previous Extension Used ";
            // 
            // FileSystemViewer
            // 
            this.FileSystemViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileSystemViewer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FileSystemViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileSystemViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileViewerName,
            this.FileViewerFullPath,
            this.FileViewerPrevPath,
            this.FileViewerEventType,
            this.FileViewerDate});
            this.FileSystemViewer.Location = new System.Drawing.Point(12, 244);
            this.FileSystemViewer.Name = "FileSystemViewer";
            this.FileSystemViewer.ReadOnly = true;
            this.FileSystemViewer.Size = new System.Drawing.Size(1110, 482);
            this.FileSystemViewer.TabIndex = 12;
            // 
            // FileViewerName
            // 
            this.FileViewerName.HeaderText = "Name";
            this.FileViewerName.Name = "FileViewerName";
            this.FileViewerName.ReadOnly = true;
            this.FileViewerName.Width = 200;
            // 
            // FileViewerFullPath
            // 
            this.FileViewerFullPath.HeaderText = "Full Path";
            this.FileViewerFullPath.Name = "FileViewerFullPath";
            this.FileViewerFullPath.ReadOnly = true;
            this.FileViewerFullPath.Width = 325;
            // 
            // FileViewerPrevPath
            // 
            this.FileViewerPrevPath.HeaderText = "Previous Path";
            this.FileViewerPrevPath.Name = "FileViewerPrevPath";
            this.FileViewerPrevPath.ReadOnly = true;
            this.FileViewerPrevPath.Width = 325;
            // 
            // FileViewerEventType
            // 
            this.FileViewerEventType.HeaderText = "Type of Event";
            this.FileViewerEventType.Name = "FileViewerEventType";
            this.FileViewerEventType.ReadOnly = true;
            // 
            // FileViewerDate
            // 
            this.FileViewerDate.HeaderText = "Date";
            this.FileViewerDate.Name = "FileViewerDate";
            this.FileViewerDate.ReadOnly = true;
            // 
            // SetPath
            // 
            this.SetPath.Location = new System.Drawing.Point(6, 110);
            this.SetPath.Name = "SetPath";
            this.SetPath.Size = new System.Drawing.Size(121, 23);
            this.SetPath.TabIndex = 15;
            this.SetPath.Text = "Set Path";
            this.SetPath.UseVisualStyleBackColor = true;
            this.SetPath.Click += new System.EventHandler(this.SetPath_Click);
            // 
            // radioButtonUseExtension
            // 
            this.radioButtonUseExtension.AutoSize = true;
            this.radioButtonUseExtension.Checked = true;
            this.radioButtonUseExtension.Location = new System.Drawing.Point(6, 86);
            this.radioButtonUseExtension.Name = "radioButtonUseExtension";
            this.radioButtonUseExtension.Size = new System.Drawing.Size(93, 17);
            this.radioButtonUseExtension.TabIndex = 16;
            this.radioButtonUseExtension.TabStop = true;
            this.radioButtonUseExtension.Text = "Use Extension";
            this.radioButtonUseExtension.UseVisualStyleBackColor = true;
            this.radioButtonUseExtension.CheckedChanged += new System.EventHandler(this.radioButtonUseExtension_CheckedChanged);
            // 
            // radioButtonNoExtension
            // 
            this.radioButtonNoExtension.AutoSize = true;
            this.radioButtonNoExtension.Location = new System.Drawing.Point(6, 108);
            this.radioButtonNoExtension.Name = "radioButtonNoExtension";
            this.radioButtonNoExtension.Size = new System.Drawing.Size(80, 17);
            this.radioButtonNoExtension.TabIndex = 17;
            this.radioButtonNoExtension.Text = "Look For all";
            this.radioButtonNoExtension.UseVisualStyleBackColor = true;
            this.radioButtonNoExtension.CheckedChanged += new System.EventHandler(this.radioButtonNoExtension_CheckedChanged);
            // 
            // pathGroup
            // 
            this.pathGroup.Controls.Add(this.DatabaseLabel);
            this.pathGroup.Controls.Add(this.FileNameLable);
            this.pathGroup.Controls.Add(this.PathBox);
            this.pathGroup.Controls.Add(this.PathText);
            this.pathGroup.Controls.Add(this.SetPath);
            this.pathGroup.Controls.Add(this.Start);
            this.pathGroup.Controls.Add(this.Stop);
            this.pathGroup.Location = new System.Drawing.Point(12, 27);
            this.pathGroup.Name = "pathGroup";
            this.pathGroup.Size = new System.Drawing.Size(785, 198);
            this.pathGroup.TabIndex = 18;
            this.pathGroup.TabStop = false;
            this.pathGroup.Text = "Path Setting";
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.AutoSize = true;
            this.DatabaseLabel.Location = new System.Drawing.Point(6, 39);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(50, 13);
            this.DatabaseLabel.TabIndex = 21;
            this.DatabaseLabel.Text = "{ Empty }";
            // 
            // FileNameLable
            // 
            this.FileNameLable.AutoSize = true;
            this.FileNameLable.Location = new System.Drawing.Point(6, 16);
            this.FileNameLable.Name = "FileNameLable";
            this.FileNameLable.Size = new System.Drawing.Size(90, 13);
            this.FileNameLable.TabIndex = 20;
            this.FileNameLable.Text = "Database Name :";
            // 
            // filterGroup
            // 
            this.filterGroup.Controls.Add(this.radioButtonNoExtension);
            this.filterGroup.Controls.Add(this.radioButtonUseExtension);
            this.filterGroup.Controls.Add(this.FileSystemWatcherSubmitButton);
            this.filterGroup.Controls.Add(this.ExtensionBox);
            this.filterGroup.Controls.Add(this.PrevExtensionText);
            this.filterGroup.Controls.Add(this.ExtensionText);
            this.filterGroup.Controls.Add(this.ListExtensions);
            this.filterGroup.Controls.Add(this.PrevUsedExtensions);
            this.filterGroup.Location = new System.Drawing.Point(804, 28);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Size = new System.Drawing.Size(318, 197);
            this.filterGroup.TabIndex = 19;
            this.filterGroup.TabStop = false;
            this.filterGroup.Text = "Filter Setting";
            // 
            // FileWatcherSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 762);
            this.Controls.Add(this.FileViewText);
            this.Controls.Add(this.FileSystemViewer);
            this.Controls.Add(this.FileSystemStatusBar);
            this.Controls.Add(this.MenuSet);
            this.Controls.Add(this.pathGroup);
            this.Controls.Add(this.filterGroup);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuSet;
            this.MaximizeBox = false;
            this.Name = "FileWatcherSystem";
            this.Text = " File System Watcher";
            this.Load += new System.EventHandler(this.FileSystemWatcher_Load);
            this.FileSystemStatusBar.ResumeLayout(false);
            this.FileSystemStatusBar.PerformLayout();
            this.MenuSet.ResumeLayout(false);
            this.MenuSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemViewer)).EndInit();
            this.pathGroup.ResumeLayout(false);
            this.pathGroup.PerformLayout();
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.StatusStrip FileSystemStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel FileSystemStatus;
        private System.Windows.Forms.MenuStrip MenuSet;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemStart;
        private System.Windows.Forms.ToolStripMenuItem MenuItemStop;
        private System.Windows.Forms.ToolStripMenuItem DatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLoadDatabase;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveDatabaseAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCheckDatabase;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInfo;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label PathText;
        private System.Windows.Forms.TextBox ExtensionBox;
        private System.Windows.Forms.Label ExtensionText;
        private System.Windows.Forms.Button FileSystemWatcherSubmitButton;
        private System.Windows.Forms.Label ListExtensions;
        private System.Windows.Forms.Label FileViewText;
        private System.Windows.Forms.ComboBox PrevUsedExtensions;
        private System.Windows.Forms.Label PrevExtensionText;
        private System.Windows.Forms.DataGridView FileSystemViewer;
        private System.Windows.Forms.Button SetPath;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetPath;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setFilterToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileViewerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileViewerFullPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileViewerPrevPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileViewerEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileViewerDate;
        private System.Windows.Forms.RadioButton radioButtonUseExtension;
        private System.Windows.Forms.RadioButton radioButtonNoExtension;
        private System.Windows.Forms.GroupBox pathGroup;
        private System.Windows.Forms.GroupBox filterGroup;
        private System.Windows.Forms.ToolStripMenuItem clearViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseToolStripMenuItem;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.Label FileNameLable;
    }
}

