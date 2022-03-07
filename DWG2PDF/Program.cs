using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;
using System.Diagnostics;

class Program
{
    private static ConcurrentBag<string> FilesQueue = new ConcurrentBag<string>();
    private static string ScriptsPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\scripts";
    private static IConfiguration Config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

    static void Main(string[] args)
    {
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

        while (true)
        {

        }
        /*while (true)
        {
            foreach (string s in FilesQueue)
            {
                string JustName = Path.GetFileNameWithoutExtension(s);
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
                startInfo.FileName = Config.GetSection("AutoCAD_Path").Value.Replace("/", "\\") + @"\accoreconsole";
                startInfo.Arguments = "/i \"" + s + "\" /s \"" + ScriptsPath + @"\" + JustName + ".scr\"";
                Process.Start(startInfo);

                Thread.Sleep(5000); // wait for DWG/DXF to process
            }
            while (!FilesQueue.IsEmpty)
            {
                string item = "";
                FilesQueue.TryTake(out item);
            }
        }*/
    }

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