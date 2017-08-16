/**
 *  Extra features
 *
 *  1. statusbars for both forms Main and Database
 *
 *  2. Group boxes for the Main form
 *
 *  3. Label showing the current database in use
 *
 *  4. a set path button that prechecks the Directory if it Exists
 *
 *  5. if there is no extension sumitted the program tells the user by Mainform Status bar
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace FileWatcher
{
    public partial class FileWatcherSystem : Form
    {
        private string path;
        private string extension;
        public FileWatcherSystem()
        {
            InitializeComponent();
            eventMan = new EventManger(this);
            FormClosing += new FormClosingEventHandler(FileSystemWatcher_Closing);
            path = String.Empty;
        }
        
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void FileSystemWatcher_Load(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Stop.Enabled = false;
            MenuItemStart.Enabled = false;
            MenuItemStop.Enabled = false;
            FileSystemStatus.Text = "Ready";
        }

        private void FileSystemWatcher_Closing(object sender, FormClosingEventArgs e)
        {
            Stop_Click(sender, e);

            if (MessageBox.Show("Do you want to close?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                if (databaseChanged == true)
                {
                    DialogResult dr = MessageBox.Show("Database has not been save, do you want save before closing?", "", MessageBoxButtons.YesNoCancel);

                    if (dr == DialogResult.Yes)
                    {
                        SaveDataBase();

                        if (SQLConn != null)
                            SQLConn.Close();

                        return;
                    }
                    else if (dr == DialogResult.No)
                    {
                        if (SQLConn != null)
                            SQLConn.Close();
                        return;
                    }
                    else
                        e.Cancel = true;
                }
                else
                {
                    if (SQLConn != null)
                        SQLConn.Close();
                    return;
                }
            }
            
            if (SQLConn != null)
                SQLConn.Close();
        }

        private void MenuItemStart_Click(object sender, EventArgs e)
        {
            // start runs the FSW and locks the start button and unlocks stop
            Start_Click(sender, e);
        }

        private void MenuItemStop_Click(object sender, EventArgs e)
        {
            // stops the run of FSW and locks the stop button and unlocks start
            Stop_Click(sender, e);
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            // check if the database needs to be save before closing the program
            Application.Exit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if ((radioButtonUseExtension.Checked == true && extension != "Empty") || radioButtonUseExtension.Checked == false)
            {
                Start.Enabled = false;
                SetPath.Enabled = false;
                Stop.Enabled = true;
                MenuItemStart.Enabled = false;
                MenuItemSetPath.Enabled = false;
                MenuItemStop.Enabled = true;
                filterGroup.Enabled = false;
                PathBox.Enabled = false;
                RunFileSystemWatcher();
            }
            else
            {
                FileSystemStatus.Text = "No Extension is selected";
                Start.Enabled = false;
                MenuItemStart.Enabled = false;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            SetPath.Enabled = true;
            Stop.Enabled = false;
            MenuItemStart.Enabled = false;
            MenuItemSetPath.Enabled = true;
            MenuItemStop.Enabled = false;
            filterGroup.Enabled = true;
            PathBox.Enabled = true;
            StopFileSystemWatcher();

            if (isRunning == false)
            {
                Start.Enabled = false;
                SetPath.Enabled = true;
                Stop.Enabled = false;
                MenuItemStart.Enabled = false;
                MenuItemSetPath.Enabled = true;
                MenuItemStop.Enabled = false;
                filterGroup.Enabled = true;
                PathBox.Enabled = true;
            }
        }

        private void MenuItemLoadDatabase_Click(object sender, EventArgs e)
        {
            if (isRunning == true)
                Stop_Click(sender, e);

            LoadDataBase();

            setDatabaseLabel();
        }

        private void MenuItemSaveDatabase_Click(object sender, EventArgs e)
        {
            if (isRunning == true)
                Stop_Click(sender, e);

            SaveDataBase();

            setDatabaseLabel();
        }

        private void MenuItemSaveDatabaseAs_Click(object sender, EventArgs e)
        {
            if (isRunning == true)
                Stop_Click(sender, e);

            SaveDataBaseAs();

            setDatabaseLabel();
        }

        private void setDatabaseLabel()
        {
            if (SQLConn != null)
                DatabaseLabel.Text = SQLConn.FileName;
        }

        private void MenuItemCheckDatabase_Click(object sender, EventArgs e)
        {
            if(isRunning == true)
                Stop_Click(sender, e);
            
            DatabaseForm DBF = new DatabaseForm(this);
            DBF.SetWorkingDatabase(SQLConn, SQLCmd);
            DBF.Show();
        }

        private void MenuItemInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File Watcher System Ver 1.0\nx64 build\nFramework .NET 4.5.1\nWriten in C# 4.0\n\nThis program watches file system for any changes.");
        }

        private void FileSystemWatcherSubmitButton_Click(object sender, EventArgs e)
        {
            if (ExtensionBox.Text != String.Empty)
                extension = ExtensionBox.Text;
            else if (PrevUsedExtensions.Text != String.Empty)
                extension = PrevUsedExtensions.Text;
            else
            {
                MessageBox.Show("Missing Extension");
                return;
            }
            
            if(!PrevUsedExtensions.Items.Contains(extension))
                PrevUsedExtensions.Items.Add(extension);

            if (extension != String.Empty)
                ListExtensions.Text = extension;
        }

        private bool RunFileSystemWatcher()
        {
            if (radioButtonNoExtension.Checked == true)
            {
                FileSystemStatus.Text = "Running: watching Directory ->" + PathBox.Text;
                return Watch(PathBox.Text);
            }
            else
            {
                FileSystemStatus.Text = "Running: watching Directory ->" + PathBox.Text + " : With Filter set to = " + extension;
                return Watch(PathBox.Text, extension);
            }
        }

        private bool StopFileSystemWatcher()
        {
            FileSystemStatus.Text = "Ready";
            return StopWatch();
        }

        private void SetPath_Click(object sender, EventArgs e)
        {
            path = PathBox.Text;
            extension = ListExtensions.Text;
            if (!Directory.Exists(path))
            {
                FileSystemStatus.Text = "That Directory Does not exists";
            }
            else if (radioButtonUseExtension.Checked == true && extension == "Empty")
            {
                FileSystemStatus.Text = "No Extension is selected";
            }
            else if (radioButtonUseExtension.Checked == true && extension != "Empty")
            {
                Start.Enabled = true;
                MenuItemStart.Enabled = true;
                FileSystemStatus.Text = "Ready to watch -> " + path + " with a filter = " + extension;
            }
            else
            {
                if (extension == "Empty")
                    extension = "";

                Start.Enabled = true;
                MenuItemStart.Enabled = true;
                FileSystemStatus.Text = "Ready to watch -> " + path;
            }
        }

        private void setPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = PathBox.Text;
            extension = ListExtensions.Text;
            if (!Directory.Exists(path))
            {
                FileSystemStatus.Text = "That Directory Does not exists";
            }
            else if (radioButtonUseExtension.Checked == true && extension == "Empty")
            {
                FileSystemStatus.Text = "No Extension is selected";
            }
            else if (radioButtonUseExtension.Checked == true && extension != "Empty")
            {
                Start.Enabled = true;
                MenuItemStart.Enabled = true;
                FileSystemStatus.Text = "Ready to watch -> " + path + " with a filter = " + extension;
            }
            else if (radioButtonNoExtension.Checked == true)
            {
                extension = "";
                Start.Enabled = true;
                MenuItemStart.Enabled = true;
                FileSystemStatus.Text = "Ready to watch -> " + path;
            }
            else
            {
                extension = "";

                Start.Enabled = true;
                MenuItemStart.Enabled = true;
                FileSystemStatus.Text = "Ready to watch -> " + path;
            }
        }

        private void radioButtonNoExtension_CheckedChanged(object sender, EventArgs e)
        {
            ExtensionBox.Enabled = false;
            ExtensionText.Enabled = false;
            PrevUsedExtensions.Enabled = false;
            FileSystemWatcherSubmitButton.Enabled = false;
        }

        private void radioButtonUseExtension_CheckedChanged(object sender, EventArgs e)
        {
            ExtensionBox.Enabled = true;
            ExtensionText.Enabled = true;
            PrevUsedExtensions.Enabled = true;
            FileSystemWatcherSubmitButton.Enabled = true;

            if(Start.Enabled == true && MenuItemStart.Enabled == true)
            {
                Start.Enabled = false;
                MenuItemStart.Enabled = false;
            }
        }

        private void clearViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSystemViewer.Rows.Clear();
            FileSystemViewer.Refresh();
            databaseChanged = false;
        }

        private void changePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop_Click(sender, e);
            PathBox.Focus();
        }

        private void setFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSystemWatcherSubmitButton_Click(sender, e);
        }

        public void setDatabaseLable(string str)
        {
            DatabaseLabel.Text = str;
        }
    }
}
