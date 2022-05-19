### About

* Watches a folder for dwg/dxf files that were changed, renamed or created and runs the AutoCAD console app to create the pdf print file. Runs off of the VS.NET FileSystemWatcher class. Requires [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) be installed. Run this with AutoCAD on the same workstation.

### Requirements

* AutoCAD (no license required)
* Windows or MacOS

### How To Use

* Edit appSettings.json file with a text editor like NotePad.
* Run app and keep it running. If you close the app, it will stop working.
* NOTE: If you plan on running it on a Windows server, you need to have a user logged in.