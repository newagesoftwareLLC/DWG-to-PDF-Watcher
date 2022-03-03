using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWG2PDFWatcher
{
    public partial class Service : ServiceBase
    {
        List<string> FilesQueue = new List<string>();
        List<string> FilesToClear = new List<string>();

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            fileSystemWatcher1.Path = Properties.Settings.Default.Watch_Directory;
            Directory.CreateDirectory("scripts");
            if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
        }

        protected override void OnStop()
        {
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            FilesQueue.Add(e.Name);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string s in FilesQueue)
            {
                // Create .scr script file
                string[] lines =
                {
                    "_PLOT",
                    "_Y",
                    Properties.Settings.Default.Print_Layout, // whatever layout you need printed
                    "DWG To PDF.pc3",
                    "ANSI full bleed A (8.50 x 11.00 Inches)",
                    "_Inches",
                    "_Landscape",
                    "_No",
                    "_Extents",
                    "_Fit",
                    "0,0",
                    "_Yes",
                    ".",
                    "_Yes",
                    "_N",
                    "_N",
                    "_Y",
                    s, // PDF file name goes here
                    "_N",
                    "_Y",
                    "_QUIT _Yes"
                };
                File.WriteAllLines("scripts/" + s + ".scr", lines);

                Process.Start(Properties.Settings.Default.AutoCAD_Path + @"\accoreconsole", "/i " + s + " /s " + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/scripts/" + s + ".scr");
                FilesToClear.Add(s);
                Thread.Sleep(5000); // wait for DWG/DXF to process
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (string f2c in FilesToClear)
            {
                FilesQueue.Remove(f2c);
            }
            FilesToClear.Clear();
            Thread.Sleep(500);
            if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            FilesQueue.Add(e.Name);
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            FilesQueue.Add(e.Name);
        }
    }
}
