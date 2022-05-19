using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private static ConcurrentBag<string> FilesQueue = new ConcurrentBag<string>();
    private static string ScriptsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\scripts";
    private static IConfiguration Config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
    //private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.ComponentModel.IContainer components;

    static void Main(string[] args)
    {
        if (!File.Exists("appSettings.json"))
        {
            //MessageBox.Show("ERROR: appSettings.json file missing!"); // if windows app
            Console.WriteLine("ERROR: appSettings.json file missing!"); // if console app
            return;
        }

        if (!Directory.Exists(Config.GetSection("Watch_Directory").Value.Replace("/", "\\")))
        {
            //MessageBox.Show("ERROR: Watch_Directory directory does not exist!"); // if windows app
            Console.WriteLine("ERROR: Watch_Directory directory does not exist!"); // if console app
            return;
        }

        using var watcher = new FileSystemWatcher(Config.GetSection("Watch_Directory").Value.Replace("/", "\\"));
        Console.WriteLine("watching {0}", Config.GetSection("Watch_Directory").Value.Replace("/", "\\"));
        Directory.CreateDirectory(ScriptsPath);

        watcher.NotifyFilter = NotifyFilters.Attributes
                             | NotifyFilters.CreationTime
                             | NotifyFilters.DirectoryName
                             | NotifyFilters.FileName
                             | NotifyFilters.LastAccess
                             | NotifyFilters.LastWrite;

        watcher.Changed += OnChanged;
        //watcher.Created += OnCreated;
        //watcher.Renamed += OnRenamed;

        //watcher.IncludeSubdirectories = false;
        watcher.EnableRaisingEvents = true;

        // hide window (Windows only atm)
        if (Config.GetSection("Hide_Window").Value.Equals("true"))
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
                ShowWindow(h, 0);
            }
        }

        //Program p = new Program();
        //p.test();

        // keep app running
        while (true)
        {
            System.Threading.Thread.Sleep(1);
        }
    }

    /*public void test() // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.notifyicon?view=windowsdesktop-6.0 WORKS!
    {
        this.components = new System.ComponentModel.Container();
        this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
        string[] test = Assembly.GetAssembly(typeof(Icon)).GetManifestResourceNames();
        notifyIcon1.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("DWG2PDF.Resources.appicon.ico"));//new Icon("appicon.ico"); // TODO: PUT IN RESOURCES
        notifyIcon1.Text = "DWG2PDF Started";
        notifyIcon1.Visible = true;
    }*/

    private static void ProcessFile(FileSystemEventArgs e)
    {
        string strFileExt = Path.GetExtension(e.FullPath);
        if (strFileExt.ToLower().Equals(".dwg") || strFileExt.ToLower().Equals(".dxf"))
        {
            Console.WriteLine("processing {0}", e.FullPath);
            string JustName = Path.GetFileNameWithoutExtension(e.FullPath);
            // Create .scr script file
            string[] lines =
            {
                    "_PLOT",
                    "_Y",
                    Config.GetSection("Print_Layout").Value, // whatever layout you need printed
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
                    Config.GetSection("Output_Directory").Value + @"\" + JustName, // PDF file name goes here
                    "_N",
                    "_Y",
                    "_QUIT _Yes"
                };
            File.WriteAllLines(ScriptsPath + "/" + JustName + ".scr", lines);

            ProcessStartInfo startInfo = new ProcessStartInfo();

            if (!File.Exists(Config.GetSection("AutoCAD_Path").Value.Replace("/", "\\") + @"\accoreconsole"))
            {
                //MessageBox.Show("ERROR: AutoCAD_Path is not correct! accoreconsole app should be present in directory."); // if windows app
                Console.WriteLine("ERROR: AutoCAD_Path is not correct! accoreconsole app should be present in directory."); // if console app
                return;
            }

            startInfo.FileName = Config.GetSection("AutoCAD_Path").Value.Replace("/", "\\") + @"\accoreconsole";
            startInfo.Arguments = "/i \"" + e.FullPath + "\" /s \"" + ScriptsPath + @"\" + JustName + ".scr\"";
            Process.Start(startInfo);
            //FilesQueue.Add(e.FullPath);
        }
    }


    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        ProcessFile(e);
    }

    /*private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        ProcessFile(e);
    }

    private static void OnRenamed(object sender, RenamedEventArgs e)
    {
        ProcessFile(e);
    }*/

}