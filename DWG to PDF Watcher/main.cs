using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace DWG2PDFWatcher
{
    public partial class main : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        List<string> FilesQueue = new List<string>();

        public static void ScrollToBottom(RichTextBox MyRichTextBox)
        {
            SendMessage(MyRichTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
        }

        public main()
        {
            InitializeComponent();
        }

        void AppendOutputText(string text, Color color = default(Color))
        {
            try
            {
                outputBox.SelectionStart = outputBox.TextLength;
                outputBox.SelectionLength = 0;

                outputBox.SelectionColor = color;
                outputBox.AppendText(text + Environment.NewLine);
                ScrollToBottom(outputBox);
            }
            catch
            {
                //error
            }
        }

        string getBrowsePath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog(this) == DialogResult.OK)
                return fbd.SelectedPath;
            return "";
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            FilesQueue.Add(e.Name);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string value = (string)e.Argument;
            AppendOutputText(DateTime.Now + " | CREATING PDF FOR " + value);
            if (FormWindowState.Minimized == this.WindowState && showNotifications.Checked)
                notifyIcon1.ShowBalloonTip(1000, "DWG to PDF Watcher", DateTime.Now + " CREATING PDF FOR " + value, toolTip1.ToolTipIcon);
            string arguments = "";
            if (cadConvBox.Text.Contains("dp.exe"))
                arguments = "/Hide /InFile" + " \"" + watchBox.Text + "\\" + value + ".dwg\" /OutFile \"" + outDirBox.Text + "\\" + value + ".pdf\"\"";
            if (cadConvBox.Text.Contains("AcmeCADConverter.exe"))
                arguments = "/r /e /f 105 /d \"" + outDirBox.Text + "\\" + value + ".pdf\"" + " \"" + watchBox.Text + "\\" + value + ".dwg\"";
            Process.Start(cadConvBox.Text, arguments);

            if (copyDirBox.Text.Count() > 0 && Directory.Exists(copyDirBox.Text))
            {
                File.Copy(watchBox.Text + "\\" + value + ".dwg", copyDirBox.Text + "\\" + value + ".dwg", true);
                AppendOutputText(DateTime.Now + " | COPIED " + value + " TO " + copyDirBox.Text);
            }
            else if (copyDirBox.Text.Count() > 0 && Directory.Exists(copyDirBox.Text))
                AppendOutputText("ERROR: " + copyDirBox.Text + " DIRECTORY DOESN'T EXIST!", Color.Red);

            FilesQueue.RemoveAt(0);
            return;
        }

        private void watchBox_TextChanged(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = watchBox.Text;
        }

        private void dirWatchBrowse_Click(object sender, EventArgs e)
        {
            watchBox.Text = getBrowsePath();
        }

        private void copyDirBrowse_Click(object sender, EventArgs e)
        {
            copyDirBox.Text = getBrowsePath();
        }

        private void OutputDirBrowse_Click(object sender, EventArgs e)
        {
            outDirBox.Text = getBrowsePath();
        }

        private void cadConvBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "EXE Files (*.exe)|*.exe";
            browseFile.Title = "Browse EXE file";
            if (browseFile.ShowDialog(this) == DialogResult.OK)
                cadConvBox.Text = browseFile.FileName;
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.outputBox = outDirBox.Text;
            Properties.Settings.Default.watchBox = watchBox.Text;
            Properties.Settings.Default.cadconvBox = cadConvBox.Text;
            Properties.Settings.Default.exportOnExit = exportOnExit.Checked;
            Properties.Settings.Default.showNotifications = showNotifications.Checked;
            Properties.Settings.Default.copydirBox = copyDirBox.Text;
            Properties.Settings.Default.Save();

            if (exportOnExit.Checked)
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();
                saveFile1.DefaultExt = "*.rtf";
                saveFile1.Filter = "RTF Files|*.rtf";
                if (saveFile1.ShowDialog() == DialogResult.OK && saveFile1.FileName.Length > 0)
                    outputBox.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help aboutForm = new help();
            aboutForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!FilesQueue.Any())
                return;

            FilesQueue = FilesQueue.Distinct().ToList();

            if (backgroundWorker1.IsBusy == false)
                backgroundWorker1.RunWorkerAsync(Path.GetFileNameWithoutExtension(FilesQueue.First()));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created for AutoDWG and AcmeDWG");
        }

        private void cadConvHelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Browse to your AutoDWG or AcmeDWG executable file.");
        }

        private void dirWatchHelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Directory of DWG files to watch for changes.");
        }

        private void outputDirHelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Directory to send PDF files to.");
        }

        private void copyDirHelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copy DWG changed files to here. Good for file backups.");
        }

        private void main_Shown(object sender, EventArgs e)
        {
            outDirBox.Text = Properties.Settings.Default.outputBox;
            watchBox.Text = Properties.Settings.Default.watchBox;
            cadConvBox.Text = Properties.Settings.Default.cadconvBox;
            exportOnExit.Checked = Properties.Settings.Default.exportOnExit;
            showNotifications.Checked = Properties.Settings.Default.showNotifications;
            copyDirBox.Text = Properties.Settings.Default.copydirBox;
            WindowState = FormWindowState.Minimized;
            notifyIcon1.ShowBalloonTip(1000, "DWG to PDF Watcher", "program started", toolTip1.ToolTipIcon);
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
