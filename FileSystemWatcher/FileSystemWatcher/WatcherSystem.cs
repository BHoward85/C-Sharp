using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace FileWatcher
{
    public partial class FileWatcherSystem : Form
    {
        delegate void SendOutput(string[] output);
        //Working DataBase and Event Set
        private static SQLiteConnection SQLConn;
        private static SQLiteCommand SQLCmd;
        private static EventManger eventMan;
        private static string fullPath;
        private static bool isRunning = false;
        private static bool databaseChanged = false;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static bool Watch(string path, string extension = "")
        {
            string directory = path;
            fullPath = Directory.GetCurrentDirectory();
            
            eventMan.Watch(path, extension);
            isRunning = true;
            return true;
        }

        public SQLiteConnection SQLCON
        {
            get
            {
                return SQLConn;
            }
        }

        public SQLiteCommand SQLCOM
        {
            get
            {
                return SQLCmd;
            }
        }

        public bool Changed
        {
            get
            {
                return databaseChanged;
            }
        }

        public bool Running
        {
            get
            {
                return isRunning;
            }
        }

        public static bool StopWatch()
        {
            eventMan.StopWatching();
            isRunning = false;
            return true;
        }

        public void WriteToDataViewer(string[] output)
        {
            if (this.FileSystemViewer.InvokeRequired)
            {
                SendOutput s = new SendOutput(WriteToDataViewer);
                this.Invoke(s, new string[][]{ output });
            }
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(FileSystemViewer);
                
                switch (output[5])
                {
                    case "Red":
                        row.DefaultCellStyle.BackColor = Color.Red;
                        break;
                    case "Blue":
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                        break;
                    case "Green":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Yellow":
                        row.DefaultCellStyle.BackColor = Color.Gold;
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.Beige;
                        break;
                }

                row.SetValues(output[0], output[1], output[2], output[3], output[4]);
                this.FileSystemViewer.Rows.Add(row);
                databaseChanged = true;
            }
        }
        
        public void WriteDatabase()
        {

            for (int index = 0; index < FileSystemViewer.RowCount; index++)
            {
                SQLCmd = SQLConn.CreateCommand();

                SQLCmd.CommandText = "INSERT INTO log (name, currPath, prevPath, eventType, date) VALUES (?, ?, ?, ?, ?);";
                SQLCmd.Parameters.Add("@name", DbType.String).Value = FileSystemViewer.Rows[index].Cells[0].Value;
                SQLCmd.Parameters.Add("@currPath", DbType.String).Value = FileSystemViewer.Rows[index].Cells[1].Value;
                SQLCmd.Parameters.Add("@prevPath", DbType.String).Value = FileSystemViewer.Rows[index].Cells[2].Value;
                SQLCmd.Parameters.Add("@eventType", DbType.String).Value = FileSystemViewer.Rows[index].Cells[3].Value;
                SQLCmd.Parameters.Add("@date", DbType.String).Value = FileSystemViewer.Rows[index].Cells[4].Value;

                SQLCmd.ExecuteNonQuery();
            }
            databaseChanged = false;
        }

        public void SaveDataBase()
        {
            if (SQLConn != null && SQLConn.State == ConnectionState.Open)
                WriteDatabase();
            else
                SaveDataBaseAs();
        }

        public void SaveDataBaseAs()
        {
            SaveFileDialog saveDatabase = new SaveFileDialog();
            DialogResult DR;

            saveDatabase.DefaultExt = ".db";
            saveDatabase.InitialDirectory = Directory.GetCurrentDirectory();
            DR = saveDatabase.ShowDialog();
            if (DR.ToString() == "OK")
            {
                SetDataBase(saveDatabase.FileName);
                WriteDatabase();
            }
        }

        public void LoadDataBase()
        {
            OpenFileDialog findDatabase = new OpenFileDialog();
            DialogResult DR;

            findDatabase.DefaultExt = ".db";
            findDatabase.SupportMultiDottedExtensions = true;
            findDatabase.InitialDirectory = Directory.GetCurrentDirectory();
            DR = findDatabase.ShowDialog();
            if (DR.ToString() == "OK")
            {
                SetDataBase(findDatabase.FileName);
            }
        }

        private static void SetDataBase(string databaseName)
        {
            if (SQLConn != null && SQLConn.State == ConnectionState.Open)
                SQLConn.Close();

            if (File.Exists(databaseName))
            {
                SQLConn = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;");
                SQLConn.Open();
                SQLCmd = SQLConn.CreateCommand();
            }
            else
            {
                SQLConn = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;New=True;Compress=True;");
                SQLConn.Open();
                SQLCmd = SQLConn.CreateCommand();
                SQLCmd.CommandText = "CREATE TABLE log (name varchar(1000), currPath varchar(1000), prevPath varchar(1000), eventType varchar(20), date varchar(20));";
                SQLCmd.ExecuteNonQuery();
            }
        }
    }
}
