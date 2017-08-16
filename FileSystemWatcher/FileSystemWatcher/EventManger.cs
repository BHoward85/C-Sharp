using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWatcher
{
    class EventManger
    {
        private Thread transferThread = null;
        private FileWatcherSystem FWS;
        private static FileSystemWatcher watcher;
        private static string[] output;


        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public EventManger(FileWatcherSystem that)
        {
            FWS = that;
            output = new String[6];
            watcher = new FileSystemWatcher();
        }

        public bool Watch(string path, string extension)
        {
            watcher = new FileSystemWatcher();

            if (!Directory.Exists(path))
            {
                while (!Directory.Exists(path))
                {
                    MessageBox.Show("That Directory Does not exists");
                    return false;
                }
            }

            watcher.Path = path;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.IncludeSubdirectories = true;

            watcher.Changed += new FileSystemEventHandler(Watcher_Change);
            watcher.Created += new FileSystemEventHandler(Watcher_Created);
            watcher.Deleted += new FileSystemEventHandler(Watcher_Deleted);
            watcher.Renamed += new RenamedEventHandler(Watcher_Rename);

            if (extension == "")
                watcher.Filter = extension;
            else
                watcher.Filter = "*." + extension;

            watcher.EnableRaisingEvents = true;
            return true;
        }

        public bool StopWatching()
        {
            watcher.EnableRaisingEvents = false;

            return true;
        }

        private void Watcher_Change(object source, FileSystemEventArgs e)
        {
            output = new string[6];
            output[0] = e.Name;
            output[1] = e.FullPath;
            output[2] = "-";
            output[3] = e.ChangeType.ToString();
            output[4] = DateTime.Now.ToString();
            output[5] = "Green";

            transferThread = new Thread(new ThreadStart(this.Send));
            transferThread.Start();
        }

        private void Watcher_Created(object source, FileSystemEventArgs e)
        {
            output = new string[6];
            output[0] = e.Name;
            output[1] = e.FullPath;
            output[2] = "New Path";
            output[3] = e.ChangeType.ToString();
            output[4] = DateTime.Now.ToString();
            output[5] = "Yellow";

            transferThread = new Thread(new ThreadStart(this.Send));
            transferThread.Start();
        }

        private void Watcher_Deleted(object source, FileSystemEventArgs e)
        {
            output = new string[6];
            output[0] = e.Name;
            output[1] = "Was Deleted";
            output[2] = e.FullPath;
            output[3] = e.ChangeType.ToString();
            output[4] = DateTime.Now.ToString();
            output[5] = "Red";

            transferThread = new Thread(new ThreadStart(this.Send));
            transferThread.Start();
        }

        private void Watcher_Rename(object source, RenamedEventArgs e)
        {
            output = new string[6];
            output[0] = e.Name;
            output[1] = e.FullPath;
            output[2] = e.OldFullPath;
            output[3] = e.ChangeType.ToString();
            output[4] = DateTime.Now.ToString();
            output[5] = "Blue";
            
            transferThread = new Thread(new ThreadStart(this.Send));
            transferThread.Start();
        }

        private void Send()
        {
            FWS.WriteToDataViewer(output);
        }
    }
}
