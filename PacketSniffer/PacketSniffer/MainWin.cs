using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace PacketSniffer
{
    public partial class MainWindow : Form
    {
        delegate void SendRow(string[] list);
        private List<String[]> logInTheRaw;
        private List<String> filterList;
        private StreamWriter outputFile;
        private StreamReader inputFile;
        private ISniff sniffer;
        private bool logSaved;
        private bool promiscuous;
        private bool writeToFile;
        private string fileToWrite;
        private int no;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            filterList = new List<string>();
            logInTheRaw = new List<string[]>();
            logSaved = false;
            promiscuous = false;
            writeToFile = false;
            radioNormal.Checked = true;
            filePathBox.Enabled = false;
            StopSniff.Enabled = false;
            ClearLog.Enabled = false;
            ClearFilter.Enabled = false;
            statusState.Text = "Ready";
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Closing(object sender, FormClosingEventArgs e)
        {
            if (sniffer != null && sniffer.State == true)
                sniffer.Stop();

            if (outputFile != null)
                outputFile.Close();

            if(MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void UpdataDataGrid(string[] list)
        {
            logSaved = false;

            if (this.packetViewer.InvokeRequired)
            {
                SendRow sr = new SendRow(UpdataDataGrid);
                this.Invoke(sr, new string[][] { list });
            }
            else
            {
                try
                {
                    ClearLog.Enabled = true;
                    DataGridViewRow DGVR = new DataGridViewRow();
                    DGVR.CreateCells(packetViewer);

                    GetRowColor(ref DGVR, list[2]);

                    string[] exList = new string[2 + list.Length];
                    exList[0] = (no++).ToString();
                    exList[1] = DateTime.Now.ToString("yyyy:MM:dd-HH:mm:ss.ffff");
                    exList.AddRange(list, 2);
                    DGVR.SetValues((object[])exList);

                    AddToRaw(exList);

                    packetViewer.Rows.Add(DGVR);
                }
                catch(Exception e)
                {
                    //MessageBox.Show("at UPDATE: " + e.Message);
                    return;
                }
            }
        }

        private void GetRowColor(ref DataGridViewRow DGVR, string protocol)
        {
            switch (protocol)
            {
                case "TCP":
                    DGVR.DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case "UDP":
                    DGVR.DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case "HOPOPT":
                    DGVR.DefaultCellStyle.BackColor = Color.YellowGreen;
                    break;
                case "IGMP":
                    DGVR.DefaultCellStyle.BackColor = Color.YellowGreen;
                    break;
                case "ICMP":
                    DGVR.DefaultCellStyle.BackColor = Color.YellowGreen;
                    break;
                case "ICMPv6":
                    DGVR.DefaultCellStyle.BackColor = Color.YellowGreen;
                    break;
                case "HTTP":
                    DGVR.DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case "RTP":
                    DGVR.DefaultCellStyle.BackColor = Color.YellowGreen;
                    break;
                case "RTCP":
                    DGVR.DefaultCellStyle.BackColor = Color.YellowGreen;
                    break;
                case "SMTP":
                    DGVR.DefaultCellStyle.BackColor = Color.OliveDrab;
                    break;
                case "Secure TCP":
                    DGVR.DefaultCellStyle.BackColor = Color.Violet;
                    break;
                case "LLMNR":
                    DGVR.DefaultCellStyle.BackColor = Color.PowderBlue;
                    break;
                case "NBNS":
                    DGVR.DefaultCellStyle.BackColor = Color.Yellow;
                    break;
                case "ARP":
                    DGVR.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    break;
                case "DNS":
                    DGVR.DefaultCellStyle.BackColor = Color.LightBlue;
                    break;
                case "mDNS":
                    DGVR.DefaultCellStyle.BackColor = Color.LightBlue;
                    break;
                case "SSDP":
                    DGVR.DefaultCellStyle.BackColor = Color.LightBlue;
                    break;
                case "DHCPv6":
                    DGVR.DefaultCellStyle.BackColor = Color.CornflowerBlue;
                    DGVR.DefaultCellStyle.ForeColor = Color.Cyan;
                    break;
                case "DHCP":
                    DGVR.DefaultCellStyle.BackColor = Color.CornflowerBlue;
                    DGVR.DefaultCellStyle.ForeColor = Color.Cyan;
                    break;
                case "RADSEC":
                    DGVR.DefaultCellStyle.BackColor = Color.Violet;
                    break;
                case "BROWSER":
                    DGVR.DefaultCellStyle.BackColor = Color.Gold;
                    break;
                case "Telnet":
                    DGVR.DefaultCellStyle.BackColor = Color.Beige;
                    break;
                case "SSH":
                    DGVR.DefaultCellStyle.BackColor = Color.Lavender;
                    break;
                case "BGP":
                    DGVR.DefaultCellStyle.BackColor = Color.Red;
                    break;
                case "SMB":
                    DGVR.DefaultCellStyle.BackColor = Color.Yellow;
                    break;
                case "EIGRP":
                    DGVR.DefaultCellStyle.BackColor = Color.Red;
                    DGVR.DefaultCellStyle.ForeColor = Color.White;
                    break;
                case "FTP-C":
                    DGVR.DefaultCellStyle.BackColor = Color.LimeGreen;
                    break;
                case "FTP-DT":
                    DGVR.DefaultCellStyle.BackColor = Color.LimeGreen;
                    break;
                default:
                    DGVR.DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }

        private void AddToRaw(string[] list)
        {
            logInTheRaw.Add(list);
        }

        private void StartSniff_Click(object sender, EventArgs e)
        {
            if (writeToFile == false && filterList.Count == 0)
                sniffer = new PacketSniffer(this, promiscuous, writeToFile);
            else if (writeToFile == false && filterList.Count > 0)
                sniffer = new PacketSniffer(this, promiscuous, writeToFile, args: filterList.ToArray<String>());
            else if (writeToFile == true && filterList.Count == 0)
                sniffer = new PacketSniffer(this, promiscuous, writeToFile, filePathBox.Text);
            else if (writeToFile == true && filterList.Count > 0)
                sniffer = new PacketSniffer(this, promiscuous, writeToFile, filePathBox.Text, filterList.ToArray<String>());

            if (writeToFile == true)
                labelFileLocal.Text = filePathBox.Text;
            
            sniffer.Run();
            statusState.Text = "Running in " + (promiscuous == false ? "normal" : "promiscuous") + " mode";
            StartSniff.Enabled = false;
            StopSniff.Enabled = true;
            menuItemSetting.Enabled = false;
            groupScanSettings.Enabled = false;
            no = 1;
        }

        private void StopSniff_Click(object sender, EventArgs e)
        {
            sniffer.Stop();
            statusState.Text = "Ready";
            StartSniff.Enabled = true;
            StopSniff.Enabled = false;
            menuItemSetting.Enabled = true;
            groupScanSettings.Enabled = true;
        }

        private void menuItemClearLog_Click(object sender, EventArgs e)
        {
            if (logSaved == false)
            {
                DialogResult dr = MessageBox.Show("Do you want to clear the log with out saving?", "Log", MessageBoxButtons.YesNo);

                if (dr == DialogResult.No)
                {
                    SaveLog();
                    packetViewer.Rows.Clear();
                    ClearLog.Enabled = false;
                }
                else
                {
                    packetViewer.Rows.Clear();
                    ClearLog.Enabled = false;
                }
            }
            else
            {
                packetViewer.Rows.Clear();
                ClearLog.Enabled = false;
            }
        }

        private void SaveLog()
        {
            if (outputFile != null)
            {
                WriteLog();
                logSaved = true;
            }
            else
                SaveLogAs();
        }

        private void SaveLogAs()
        {
            SaveFileDialog SFD = new SaveFileDialog();
            DialogResult DR;

            SFD.InitialDirectory = Directory.GetCurrentDirectory();
            DR = SFD.ShowDialog();

            if (DR.ToString() == "OK")
            {
                outputFile = new StreamWriter(SFD.FileName);
                labelFileLocal.Text = SFD.FileName;
                WriteLog();
                logSaved = true;
            }
        }

        private void LoadLog()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            DialogResult DR;
            int n = 1;

            OFD.InitialDirectory = Directory.GetCurrentDirectory();
            DR = OFD.ShowDialog();

            if(DR.ToString() == "OK")
            {
                inputFile = new StreamReader(OFD.FileName);
                labelFileLocal.Text = OFD.FileName;
                string t;
                string[] s;
                DataGridViewRow DGVR;

                while(!inputFile.EndOfStream)
                {
                    DGVR = new DataGridViewRow();
                    DGVR.CreateCells(packetViewer);
                    t = inputFile.ReadLine();
                    s = t.Split(new char[] { '|', ' ' }, 10, StringSplitOptions.RemoveEmptyEntries);

                    DGVR.SetValues(s);
                    GetRowColor(ref DGVR, s[4]);
                    
                    if(n++ != 1)
                        packetViewer.Rows.Add(DGVR);

                    ClearLog.Enabled = true;
                }
            }
        }

        private void WriteLog()
        {
            //                          0 |                        1 |      2 |      3 |          4 |                                       5 |                                       6 |                                       7 |                                       8 |   9
            outputFile.WriteLine("No.     | Time                     | NetPtc | Tran P | App Portoc | Source IP                               | Source Port                             | Destation IP                            | Destation Port                          | Length");
            //                    nnnnnnn | yyyy:MM:dd-HH:mm:ss:ffff | AAAAAA | BBBBBB | CCCCCCCCCC | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn:nnnn | nnnnnn
            foreach (string[] r in logInTheRaw)
            {
                    string s;
                    s = string.Format("{0,7} | {1,24} | {2,6} | {3,6} | {4,10} | {5,39} | {6,39} | {7,39} | {8,39} | {9,6}",
                                      r[0], r[1], r[2], r[3], r[4], r[5], r[6], r[7], r[8], r[9]);

                    outputFile.WriteLine(s);
            }

            outputFile.Flush();
        }

        private void radioNormal_CheckedChanged(object sender, EventArgs e)
        {
            promiscuous = false;
            menuItemSetPromiscuousMode.Checked = false;
            menuItemSetNormalMode.Checked = true;
        }

        private void radioPromiscuous_CheckedChanged(object sender, EventArgs e)
        {
            promiscuous = true;
            menuItemSetPromiscuousMode.Checked = true;
            menuItemSetNormalMode.Checked = false;
        }

        private void checkWriteToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWriteToFile.Checked == true)
            {
                menuItemWriteToFile.Checked = true;
                writeToFile = true;
                filePathBox.Enabled = true;
            }
            else
            {
                menuItemWriteToFile.Checked = false;
                writeToFile = false;
                filePathBox.Enabled = false;
            }
        }

        private void menuItemWriteToFile_Click(object sender, EventArgs e)
        {
            if(menuItemWriteToFile.Checked == false)
            {
                menuItemWriteToFile.Checked = true;
                checkWriteToFile.Checked = true;
                writeToFile = true;
            }
            else
            {
                menuItemWriteToFile.Checked = false;
                checkWriteToFile.Checked = false;
                writeToFile = false;
            }
        }

        private void menuItemSetNormalMode_Click(object sender, EventArgs e)
        {
            radioNormal.Checked = true;
            radioPromiscuous.Checked = false;
            promiscuous = false;
            menuItemSetPromiscuousMode.Checked = false;
            menuItemSetNormalMode.Checked = true;
        }

        private void menuItemSetPromiscuousMode_Click(object sender, EventArgs e)
        {
            radioNormal.Checked = false;
            radioPromiscuous.Checked = true;
            promiscuous = true;
            menuItemSetPromiscuousMode.Checked = true;
            menuItemSetNormalMode.Checked = false;
        }

        private void menuItemSaveLog_Click(object sender, EventArgs e)
        {
            SaveLog();
        }

        private void menuItemLoadLog_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            menuItemClearLog_Click(sender, e);
        }

        private void SetFliter_Click(object sender, EventArgs e)
        {
            foreach (string s in checkBoxOfFilters.CheckedItems)
            {
                filterList.Add(s);
            }

            checkBoxOfFilters.Enabled = false;
            ClearFilter.Enabled = true;
            SetFilter.Enabled = false;
        }

        private void ClearFliter_Click(object sender, EventArgs e)
        {
            if(filterList.Count > 0)
                filterList.Clear();

            checkBoxOfFilters.Enabled = true;
            ClearFilter.Enabled = false;
            SetFilter.Enabled = true;
        }

        private void menuItemHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Packet Sniffer Program\n"
                          + "This is will link to the main internet connention\n"
                          + "You can sniff for you own packets (Normal Mode)\n"
                          + "or you can sniff for all packets on the network (Promiscuous Mode)\n"
                          + "Save Log: saves the current log to file\n"
                          + "Load Log: load and displays a save log file\n"
                          + "Write to File: when checked will write to a file as the program runs\n"
                          + "Filters:\n\tSet: Set a filter list to show only what is checked\n"
                          + "\tClear: clear the filter\n"
                          + "Refer to the readme.txt for more help info");
        }

        private void menuItemProgramInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Packet Sniffer ver 1.0\n"
                          + "Build on .NET 4.5.0 using C#\n"
                          + "Using SharpPcap ver 4.2.0");
        }
    }

    public static class EXT
    {
        public static void AddRange(this string[] smallAra, string[] extraAra, int startIndex)
        {
            for (int index = 0, jdex = startIndex; index < extraAra.Length && startIndex < smallAra.Length; index++, jdex++)
            {
                smallAra[jdex] = extraAra[index]; 
            }
        }
    }
}