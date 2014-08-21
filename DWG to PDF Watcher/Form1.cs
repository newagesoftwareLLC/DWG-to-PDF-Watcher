using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace DWG2PDFWatcher
{
    public partial class Form1 : Form
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

        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            outDirBox.Text = Properties.Settings.Default.outputBox;
            watchBox.Text = Properties.Settings.Default.watchBox;
            cadConvBox.Text = Properties.Settings.Default.cadconvBox;
            WindowState = FormWindowState.Minimized;
            BeginInvoke(new MethodInvoker(delegate { Hide(); }));
            notifyIcon1.ShowBalloonTip(1000, "DWG to PDF Watcher", "program started", toolTip1.ToolTipIcon);
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            FilesQueue.Add(e.Name);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string value = (string)e.Argument;
            AppendOutputText(DateTime.Now + " | CREATING PDF FOR " + value);
            if (FormWindowState.Minimized == this.WindowState)
                notifyIcon1.ShowBalloonTip(1000, "DWG to PDF Watcher", DateTime.Now + " CREATING PDF FOR " + value, toolTip1.ToolTipIcon);
            string arguments = "";
            if (cadConvBox.Text.Contains("dp.exe"))
                arguments = "/Hide /InFile" + " \"" + watchBox.Text + "\\" + value + ".dwg\" /OutFile \"" + outDirBox.Text + "\\" + value + ".pdf\"\"";
            if (cadConvBox.Text.Contains("AcmeCADConverter.exe"))
                arguments = "/r /e /f 105 /d \"" + outDirBox.Text + "\\" + value + ".pdf\"" + " \"" + watchBox.Text + "\\" + value + ".dwg\"";
            Process.Start(cadConvBox.Text, arguments);

            FilesQueue.RemoveAt(0);
            return;
        }

        private void watchBox_TextChanged(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = watchBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                watchBox.Text = fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd2 = new FolderBrowserDialog();
            if (fbd2.ShowDialog(this) == DialogResult.OK)
            {
                outDirBox.Text = fbd2.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "EXE Files (*.exe)|*.exe";
            browseFile.Title = "Browse EXE file";
            if (browseFile.ShowDialog(this) == DialogResult.OK)
            {
                cadConvBox.Text = browseFile.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.outputBox = outDirBox.Text;
            Properties.Settings.Default.watchBox = watchBox.Text;
            Properties.Settings.Default.cadconvBox = cadConvBox.Text;
            Properties.Settings.Default.Save();


            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog. 
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                outputBox.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 aboutForm = new Form2();
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
    }
}
