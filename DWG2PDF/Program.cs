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
    private static string ScriptsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + @"scripts";
    private static IConfiguration Config = null;
    //private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.ComponentModel.IContainer components;

    static void Main(string[] args)
    {
        string AppSettingsFile = "appSettings.json";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            AppSettingsFile = "appSettings_Windows.json";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            AppSettingsFile = "appSettings_MacOS.json";

        if (!File.Exists(AppSettingsFile))
        {
            //MessageBox.Show("ERROR: appSettings.json file missing!"); // if windows app
            Console.WriteLine("ERROR: " + AppSettingsFile + " file missing!"); // if console app
            return;
        }

        Config = new ConfigurationBuilder().AddJsonFile(AppSettingsFile).Build();

        if (!Directory.Exists(Config.GetSection("Watch_Directory").Value))
        {
            //MessageBox.Show("ERROR: Watch_Directory directory does not exist!"); // if windows app
            Console.WriteLine("ERROR: Watch_Directory " + Config.GetSection("Watch_Directory").Value + " does not exist!"); // if console app
            return;
        }

        using var watcher = new FileSystemWatcher(Config.GetSection("Watch_Directory").Value);
        Console.WriteLine("watching {0}", Config.GetSection("Watch_Directory").Value);
        //Console.WriteLine("Checking if scripts directory exists: " + ScriptsPath);
        if (!Directory.Exists(ScriptsPath))
        {
            Console.WriteLine("Creating directory at " + ScriptsPath);
            Directory.CreateDirectory(ScriptsPath);
        }

        watcher.NotifyFilter = NotifyFilters.LastWrite;

        watcher.Changed += OnChanged;
        watcher.Created += OnCreated;
        //watcher.Renamed += OnRenamed;

        watcher.Filter = "*.dwg";

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
                    Config.GetSection("Output_Directory").Value + Path.DirectorySeparatorChar + JustName, // PDF file name goes here
                    "_N",
                    "_Y",
                    "_QUIT _Yes"
                };
            File.WriteAllLines(ScriptsPath + Path.DirectorySeparatorChar + JustName + ".scr", lines);

            ProcessStartInfo startInfo = new ProcessStartInfo();

            string AutoCadPath = "";
            string AcCoreConsoleName = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                AutoCadPath = Config.GetSection("AutoCAD_Path").Value + Path.DirectorySeparatorChar;
                AcCoreConsoleName = "accoreconsole";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                AutoCadPath = Config.GetSection("AutoCAD_Path").Value + "/Contents/Helpers/AcCoreConsole.app/Contents/MacOS" + Path.DirectorySeparatorChar;
                AcCoreConsoleName = "AcCoreConsole";
            }

            if (!File.Exists(AutoCadPath + AcCoreConsoleName))
            {
                //MessageBox.Show("ERROR: AutoCAD_Path is not correct! accoreconsole app should be present in directory."); // if windows app
                Console.WriteLine("ERROR: AutoCAD_Path " + AutoCadPath + AcCoreConsoleName + " file not found!"); // if console app
                return;
            }

            startInfo.FileName = AutoCadPath + AcCoreConsoleName;
            startInfo.Arguments = "/i \"" + e.FullPath + "\" /s \"" + ScriptsPath + Path.DirectorySeparatorChar + JustName + ".scr\"";
            Process.Start(startInfo);
            //FilesQueue.Add(e.FullPath);
        }
    }


    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("OnChanged() triggered.");
        ProcessFile(e);
    }

    private static void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine("OnCreated() triggered.");
        ProcessFile(e);
    }

    /*private static void OnRenamed(object sender, RenamedEventArgs e)
    {
        ProcessFile(e);
    }*/

}