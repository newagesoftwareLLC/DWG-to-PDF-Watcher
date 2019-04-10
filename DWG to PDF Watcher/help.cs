using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace DWG2PDFWatcher
{
    public partial class help : Form
    {
        public help()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.dwgtool.com/cadconvert.htm");
            Process.Start(sInfo);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.autodwg.com/PDF/");
            Process.Start(sInfo);
        }
    }
}
