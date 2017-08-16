namespace PacketSniffer
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
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusState = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetNormalMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetPromiscuousMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWriteToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInfoSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProgramInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.packetViewer = new System.Windows.Forms.DataGridView();
            this.PacketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuperProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProtocolMain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPsource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPDestation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortDestation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartSniff = new System.Windows.Forms.Button();
            this.StopSniff = new System.Windows.Forms.Button();
            this.groupScanSettings = new System.Windows.Forms.GroupBox();
            this.ClearFilter = new System.Windows.Forms.Button();
            this.SetFilter = new System.Windows.Forms.Button();
            this.labelFilterStuff = new System.Windows.Forms.Label();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.LabelFileStuff = new System.Windows.Forms.Label();
            this.checkBoxOfFilters = new System.Windows.Forms.CheckedListBox();
            this.checkWriteToFile = new System.Windows.Forms.CheckBox();
            this.labelScanMode = new System.Windows.Forms.Label();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.radioPromiscuous = new System.Windows.Forms.RadioButton();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelFileLocal = new System.Windows.Forms.Label();
            this.ClearLog = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetViewer)).BeginInit();
            this.groupScanSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusState});
            this.statusBar.Location = new System.Drawing.Point(0, 740);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1184, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusState
            // 
            this.statusState.Name = "statusState";
            this.statusState.Size = new System.Drawing.Size(88, 17);
            this.statusState.Text = "Program Status";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemSetting,
            this.viewToolStripMenuItem,
            this.menuItemInfoSet});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1184, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "Main";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSaveLog,
            this.menuItemLoadLog,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemSaveLog
            // 
            this.menuItemSaveLog.Name = "menuItemSaveLog";
            this.menuItemSaveLog.Size = new System.Drawing.Size(152, 22);
            this.menuItemSaveLog.Text = "&Save Log";
            this.menuItemSaveLog.Click += new System.EventHandler(this.menuItemSaveLog_Click);
            // 
            // menuItemLoadLog
            // 
            this.menuItemLoadLog.Name = "menuItemLoadLog";
            this.menuItemLoadLog.Size = new System.Drawing.Size(152, 22);
            this.menuItemLoadLog.Text = "&Load Log";
            this.menuItemLoadLog.Click += new System.EventHandler(this.menuItemLoadLog_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(152, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemSetting
            // 
            this.menuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSetNormalMode,
            this.menuItemSetPromiscuousMode,
            this.menuItemWriteToFile});
            this.menuItemSetting.Name = "menuItemSetting";
            this.menuItemSetting.Size = new System.Drawing.Size(56, 20);
            this.menuItemSetting.Text = "Setting";
            // 
            // menuItemSetNormalMode
            // 
            this.menuItemSetNormalMode.Name = "menuItemSetNormalMode";
            this.menuItemSetNormalMode.Size = new System.Drawing.Size(196, 22);
            this.menuItemSetNormalMode.Text = "Set &Normal Mode";
            this.menuItemSetNormalMode.Click += new System.EventHandler(this.menuItemSetNormalMode_Click);
            // 
            // menuItemSetPromiscuousMode
            // 
            this.menuItemSetPromiscuousMode.Name = "menuItemSetPromiscuousMode";
            this.menuItemSetPromiscuousMode.Size = new System.Drawing.Size(196, 22);
            this.menuItemSetPromiscuousMode.Text = "Set &Promiscuous Mode";
            this.menuItemSetPromiscuousMode.Click += new System.EventHandler(this.menuItemSetPromiscuousMode_Click);
            // 
            // menuItemWriteToFile
            // 
            this.menuItemWriteToFile.Name = "menuItemWriteToFile";
            this.menuItemWriteToFile.Size = new System.Drawing.Size(196, 22);
            this.menuItemWriteToFile.Text = "&Write to File";
            this.menuItemWriteToFile.Click += new System.EventHandler(this.menuItemWriteToFile_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClearLog,
            this.menuItemSetFilter});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // menuItemClearLog
            // 
            this.menuItemClearLog.Name = "menuItemClearLog";
            this.menuItemClearLog.Size = new System.Drawing.Size(152, 22);
            this.menuItemClearLog.Text = "&Clear Log";
            this.menuItemClearLog.Click += new System.EventHandler(this.menuItemClearLog_Click);
            // 
            // menuItemSetFilter
            // 
            this.menuItemSetFilter.Name = "menuItemSetFilter";
            this.menuItemSetFilter.Size = new System.Drawing.Size(152, 22);
            this.menuItemSetFilter.Text = "S&et Filter";
            // 
            // menuItemInfoSet
            // 
            this.menuItemInfoSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProgramInfo,
            this.menuItemHelp});
            this.menuItemInfoSet.Name = "menuItemInfoSet";
            this.menuItemInfoSet.Size = new System.Drawing.Size(40, 20);
            this.menuItemInfoSet.Text = "&Info";
            // 
            // menuItemProgramInfo
            // 
            this.menuItemProgramInfo.Name = "menuItemProgramInfo";
            this.menuItemProgramInfo.Size = new System.Drawing.Size(152, 22);
            this.menuItemProgramInfo.Text = "&Info";
            this.menuItemProgramInfo.Click += new System.EventHandler(this.menuItemProgramInfo_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(152, 22);
            this.menuItemHelp.Text = "&Help";
            this.menuItemHelp.Click += new System.EventHandler(this.menuItemHelp_Click);
            // 
            // packetViewer
            // 
            this.packetViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packetViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packetViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PacketNumber,
            this.Time,
            this.SuperProtocol,
            this.ProtocolMain,
            this.PacketType,
            this.IPsource,
            this.PortSource,
            this.IPDestation,
            this.PortDestation,
            this.PacketLength});
            this.packetViewer.Location = new System.Drawing.Point(12, 157);
            this.packetViewer.Name = "packetViewer";
            this.packetViewer.Size = new System.Drawing.Size(1160, 580);
            this.packetViewer.TabIndex = 2;
            // 
            // PacketNumber
            // 
            this.PacketNumber.HeaderText = "No.";
            this.PacketNumber.Name = "PacketNumber";
            this.PacketNumber.Width = 40;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.Width = 175;
            // 
            // SuperProtocol
            // 
            this.SuperProtocol.HeaderText = "Network Protocol";
            this.SuperProtocol.Name = "SuperProtocol";
            this.SuperProtocol.Width = 75;
            // 
            // ProtocolMain
            // 
            this.ProtocolMain.HeaderText = "Transport Protocol";
            this.ProtocolMain.Name = "ProtocolMain";
            this.ProtocolMain.Width = 75;
            // 
            // PacketType
            // 
            this.PacketType.HeaderText = "App Protocol";
            this.PacketType.Name = "PacketType";
            this.PacketType.Width = 75;
            // 
            // IPsource
            // 
            this.IPsource.HeaderText = "Source";
            this.IPsource.Name = "IPsource";
            this.IPsource.Width = 225;
            // 
            // PortSource
            // 
            this.PortSource.HeaderText = "Source (Port)";
            this.PortSource.Name = "PortSource";
            this.PortSource.Width = 80;
            // 
            // IPDestation
            // 
            this.IPDestation.HeaderText = "Destation";
            this.IPDestation.Name = "IPDestation";
            this.IPDestation.Width = 225;
            // 
            // PortDestation
            // 
            this.PortDestation.HeaderText = "Destation (Port)";
            this.PortDestation.Name = "PortDestation";
            this.PortDestation.Width = 80;
            // 
            // PacketLength
            // 
            this.PacketLength.HeaderText = "Length";
            this.PacketLength.Name = "PacketLength";
            this.PacketLength.Width = 60;
            // 
            // StartSniff
            // 
            this.StartSniff.Location = new System.Drawing.Point(12, 99);
            this.StartSniff.Name = "StartSniff";
            this.StartSniff.Size = new System.Drawing.Size(101, 23);
            this.StartSniff.TabIndex = 5;
            this.StartSniff.Text = "Start Sniff";
            this.StartSniff.UseVisualStyleBackColor = true;
            this.StartSniff.Click += new System.EventHandler(this.StartSniff_Click);
            // 
            // StopSniff
            // 
            this.StopSniff.Location = new System.Drawing.Point(12, 128);
            this.StopSniff.Name = "StopSniff";
            this.StopSniff.Size = new System.Drawing.Size(101, 23);
            this.StopSniff.TabIndex = 6;
            this.StopSniff.Text = "Stop Sniff";
            this.StopSniff.UseVisualStyleBackColor = true;
            this.StopSniff.Click += new System.EventHandler(this.StopSniff_Click);
            // 
            // groupScanSettings
            // 
            this.groupScanSettings.Controls.Add(this.ClearFilter);
            this.groupScanSettings.Controls.Add(this.SetFilter);
            this.groupScanSettings.Controls.Add(this.labelFilterStuff);
            this.groupScanSettings.Controls.Add(this.filePathBox);
            this.groupScanSettings.Controls.Add(this.LabelFileStuff);
            this.groupScanSettings.Controls.Add(this.checkBoxOfFilters);
            this.groupScanSettings.Controls.Add(this.checkWriteToFile);
            this.groupScanSettings.Controls.Add(this.labelScanMode);
            this.groupScanSettings.Controls.Add(this.radioNormal);
            this.groupScanSettings.Controls.Add(this.radioPromiscuous);
            this.groupScanSettings.Location = new System.Drawing.Point(282, 61);
            this.groupScanSettings.Name = "groupScanSettings";
            this.groupScanSettings.Size = new System.Drawing.Size(890, 90);
            this.groupScanSettings.TabIndex = 7;
            this.groupScanSettings.TabStop = false;
            this.groupScanSettings.Text = "Scan Settings";
            // 
            // ClearFilter
            // 
            this.ClearFilter.Location = new System.Drawing.Point(597, 58);
            this.ClearFilter.Name = "ClearFilter";
            this.ClearFilter.Size = new System.Drawing.Size(101, 23);
            this.ClearFilter.TabIndex = 12;
            this.ClearFilter.Text = "Clear Filter";
            this.ClearFilter.UseVisualStyleBackColor = true;
            this.ClearFilter.Click += new System.EventHandler(this.ClearFliter_Click);
            // 
            // SetFilter
            // 
            this.SetFilter.Location = new System.Drawing.Point(597, 32);
            this.SetFilter.Name = "SetFilter";
            this.SetFilter.Size = new System.Drawing.Size(101, 23);
            this.SetFilter.TabIndex = 11;
            this.SetFilter.Text = "Set Filter";
            this.SetFilter.UseVisualStyleBackColor = true;
            this.SetFilter.Click += new System.EventHandler(this.SetFliter_Click);
            // 
            // labelFilterStuff
            // 
            this.labelFilterStuff.AutoSize = true;
            this.labelFilterStuff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilterStuff.Location = new System.Drawing.Point(594, 14);
            this.labelFilterStuff.Name = "labelFilterStuff";
            this.labelFilterStuff.Size = new System.Drawing.Size(95, 16);
            this.labelFilterStuff.TabIndex = 8;
            this.labelFilterStuff.Text = "Filter Setting";
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(170, 61);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(395, 20);
            this.filePathBox.TabIndex = 7;
            this.filePathBox.Text = "Enter in a File name";
            // 
            // LabelFileStuff
            // 
            this.LabelFileStuff.AutoSize = true;
            this.LabelFileStuff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFileStuff.Location = new System.Drawing.Point(167, 14);
            this.LabelFileStuff.Name = "LabelFileStuff";
            this.LabelFileStuff.Size = new System.Drawing.Size(86, 16);
            this.LabelFileStuff.TabIndex = 6;
            this.LabelFileStuff.Text = "File Writing";
            // 
            // checkBoxOfFilters
            // 
            this.checkBoxOfFilters.FormattingEnabled = true;
            this.checkBoxOfFilters.Items.AddRange(new object[] {
            "IPv4",
            "IPv6",
            "ARP",
            "ICMP",
            "ICMPv6",
            "IGMP",
            "IGMPv6",
            "ENCAP",
            "OSPF",
            "SCTP",
            "TCP",
            "UDP",
            "DNS",
            "mDNS",
            "SSH",
            "FTP-C",
            "FTP-DT",
            "NBNS",
            "LLMNR",
            "SSDP",
            "RADSEC",
            "BROWSER",
            "Telnet",
            "BGP",
            "RTP",
            "RTCP",
            "RTSP",
            "DHCP",
            "DHCPv6",
            "HTTP",
            "SMTP"});
            this.checkBoxOfFilters.Location = new System.Drawing.Point(704, 19);
            this.checkBoxOfFilters.Name = "checkBoxOfFilters";
            this.checkBoxOfFilters.Size = new System.Drawing.Size(180, 64);
            this.checkBoxOfFilters.TabIndex = 5;
            this.checkBoxOfFilters.Tag = "";
            // 
            // checkWriteToFile
            // 
            this.checkWriteToFile.AutoSize = true;
            this.checkWriteToFile.Location = new System.Drawing.Point(170, 38);
            this.checkWriteToFile.Name = "checkWriteToFile";
            this.checkWriteToFile.Size = new System.Drawing.Size(82, 17);
            this.checkWriteToFile.TabIndex = 3;
            this.checkWriteToFile.Text = "Write to File";
            this.checkWriteToFile.UseVisualStyleBackColor = true;
            this.checkWriteToFile.CheckedChanged += new System.EventHandler(this.checkWriteToFile_CheckedChanged);
            // 
            // labelScanMode
            // 
            this.labelScanMode.AutoSize = true;
            this.labelScanMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScanMode.Location = new System.Drawing.Point(16, 22);
            this.labelScanMode.Name = "labelScanMode";
            this.labelScanMode.Size = new System.Drawing.Size(86, 16);
            this.labelScanMode.TabIndex = 2;
            this.labelScanMode.Text = "Scan Mode";
            // 
            // radioNormal
            // 
            this.radioNormal.AutoSize = true;
            this.radioNormal.Location = new System.Drawing.Point(19, 41);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(88, 17);
            this.radioNormal.TabIndex = 1;
            this.radioNormal.TabStop = true;
            this.radioNormal.Text = "Normal Mode";
            this.radioNormal.UseVisualStyleBackColor = true;
            this.radioNormal.CheckedChanged += new System.EventHandler(this.radioNormal_CheckedChanged);
            // 
            // radioPromiscuous
            // 
            this.radioPromiscuous.AutoSize = true;
            this.radioPromiscuous.Location = new System.Drawing.Point(19, 64);
            this.radioPromiscuous.Name = "radioPromiscuous";
            this.radioPromiscuous.Size = new System.Drawing.Size(115, 17);
            this.radioPromiscuous.TabIndex = 0;
            this.radioPromiscuous.TabStop = true;
            this.radioPromiscuous.Text = "Promiscuous Mode";
            this.radioPromiscuous.UseVisualStyleBackColor = true;
            this.radioPromiscuous.CheckedChanged += new System.EventHandler(this.radioPromiscuous_CheckedChanged);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(9, 28);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(54, 13);
            this.labelFile.TabIndex = 8;
            this.labelFile.Text = "File Name";
            // 
            // labelFileLocal
            // 
            this.labelFileLocal.AutoSize = true;
            this.labelFileLocal.Location = new System.Drawing.Point(69, 28);
            this.labelFileLocal.Name = "labelFileLocal";
            this.labelFileLocal.Size = new System.Drawing.Size(58, 13);
            this.labelFileLocal.TabIndex = 9;
            this.labelFileLocal.Text = "{ EMPTY }";
            // 
            // ClearLog
            // 
            this.ClearLog.Location = new System.Drawing.Point(148, 128);
            this.ClearLog.Name = "ClearLog";
            this.ClearLog.Size = new System.Drawing.Size(101, 23);
            this.ClearLog.TabIndex = 10;
            this.ClearLog.Text = "Clear Log";
            this.ClearLog.UseVisualStyleBackColor = true;
            this.ClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.ClearLog);
            this.Controls.Add(this.labelFileLocal);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.groupScanSettings);
            this.Controls.Add(this.StopSniff);
            this.Controls.Add(this.StartSniff);
            this.Controls.Add(this.packetViewer);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Packet Sniffer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Closing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetViewer)).EndInit();
            this.groupScanSettings.ResumeLayout(false);
            this.groupScanSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusState;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.DataGridView packetViewer;
        private System.Windows.Forms.Button StartSniff;
        private System.Windows.Forms.Button StopSniff;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuperProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProtocolMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPsource;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPDestation;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortDestation;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketLength;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadLog;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetFilter;
        private System.Windows.Forms.GroupBox groupScanSettings;
        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.RadioButton radioPromiscuous;
        private System.Windows.Forms.Label labelScanMode;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelFileLocal;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetNormalMode;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetPromiscuousMode;
        private System.Windows.Forms.ToolStripMenuItem menuItemWriteToFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemInfoSet;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemProgramInfo;
        private System.Windows.Forms.CheckBox checkWriteToFile;
        private System.Windows.Forms.Button ClearLog;
        private System.Windows.Forms.Button SetFilter;
        private System.Windows.Forms.Label labelFilterStuff;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.Label LabelFileStuff;
        private System.Windows.Forms.CheckedListBox checkBoxOfFilters;
        private System.Windows.Forms.Button ClearFilter;
    }
}

