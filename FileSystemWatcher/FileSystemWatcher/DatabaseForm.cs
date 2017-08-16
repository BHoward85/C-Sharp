using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace FileWatcher
{
    public partial class DatabaseForm : Form
    {
        private SQLiteConnection SQLConn;
        private SQLiteCommand SQLCmd;
        private SQLiteDataReader SQLReader;
        private FileWatcherSystem fileWS;
        private string extension = "";
        public DatabaseForm(FileWatcherSystem FWS)
        {
            InitializeComponent();
            QueryStatusText.Text = "Ready for New Query";
            fileWS = FWS;
        }

        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            if(SQLConn != null && SQLConn.State == ConnectionState.Open)
                FileLable.Text = SQLConn.FileName;
        }

        public void SetWorkingDatabase(SQLiteConnection SQLConn, SQLiteCommand SQLCmd)
        {
            this.SQLConn = SQLConn;
            this.SQLCmd = SQLCmd;
        }

        private void run_Click(object sender, EventArgs e)
        {
            if (SQLConn == null || SQLConn.State == ConnectionState.Closed)
            {
                MessageBox.Show("There is no database opened");
                return;
            }

            if (extension != "")
            {
                SQLCmd.CommandText = "SELECT * FROM log WHERE name LIKE \"%." + extension + "\"";
            }
            else
                SQLCmd.CommandText = "SELECT * FROM log";

            SQLReader = SQLCmd.ExecuteReader();



            while (SQLReader.HasRows == true && SQLReader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DatabaseViewer);

                if (SQLReader["name"] != DBNull.Value && SQLReader["currPath"] != DBNull.Value && SQLReader["prevPath"] != DBNull.Value && SQLReader["eventType"] != DBNull.Value && SQLReader["date"] != DBNull.Value)
                    row.SetValues(SQLReader["name"], SQLReader["currPath"], SQLReader["prevPath"], SQLReader["eventType"], SQLReader["date"]);
                
                if (SQLReader["name"] != DBNull.Value && (String)SQLReader["name"] != String.Empty)
                    DatabaseViewer.Rows.Add(row);
            }
            SQLReader.Close();
            QueryStatusText.Text = "Query Done";
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (SQLConn != null && SQLConn.State == ConnectionState.Open)
            {
                if (MessageBox.Show("Do you want to delete data in the database?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DatabaseViewer.Rows.Clear();
                    DatabaseViewer.Refresh();
                    extension = "";
                    extensionList.Text = "Empty";
                    extensionBox.Text = "";
                    SQLCmd.CommandText = "DELETE FROM log";
                    SQLCmd.ExecuteNonQuery();
                    QueryStatusText.Text = "Log table was cleared of Data";
                }
            }
            else
                MessageBox.Show("There is no database opened");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            DatabaseViewer.Rows.Clear();
            DatabaseViewer.Refresh();
            extension = "";
            extensionList.Text = "Empty";
            extensionBox.Text = "";
            QueryStatusText.Text = "Ready for New Query";
        }

        private void DatabaseSubmit_Click(object sender, EventArgs e)
        {
            extension = extensionBox.Text;
            extensionList.Text = extension;
            DatabaseViewer.Rows.Clear();
            DatabaseViewer.Refresh();
            QueryStatusText.Text = "Ready for New Query with filter set to " + extension;
        }

        private void menuItemExitWindow_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void menuItemRunQuery_Click(object sender, EventArgs e)
        {
            run_Click(sender, e);
        }

        private void menuItemDeleteQuery_Click(object sender, EventArgs e)
        {
            delete_Click(sender, e);
        }

        private void menuItemClearQuery_Click(object sender, EventArgs e)
        {
            clear_Click(sender, e);
        }

        private void menuItemLoadDatabase_Click(object sender, EventArgs e)
        {
            if (fileWS != null)
                fileWS.LoadDataBase();
            else
                MessageBox.Show("Link Error");

            SQLConn = fileWS.SQLCON;
            SQLCmd = fileWS.SQLCOM;
            clear_Click(sender, e);

            setFileNameLabels();
        }

        private void MenuItemSaveDatabaseAs_Click(object sender, EventArgs e)
        {
            if (fileWS != null)
                fileWS.SaveDataBaseAs();
            else
                MessageBox.Show("Link Error");

            SQLConn = fileWS.SQLCON;
            SQLCmd = fileWS.SQLCOM;

            setFileNameLabels();
        }

        private void MenuItemSaveDatabase_Click(object sender, EventArgs e)
        {
            if (fileWS != null)
                fileWS.SaveDataBase();
            else
                MessageBox.Show("Link Error");

            SQLConn = fileWS.SQLCON;
            SQLCmd = fileWS.SQLCOM;

            setFileNameLabels();
        }

        private void setFileNameLabels()
        {
            if (SQLConn != null)
            {
                FileLable.Text = SQLConn.FileName;
                fileWS.setDatabaseLable(SQLConn.FileName);
            }
        }
    }
}
