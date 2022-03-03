### About

Watches a folder for dwg files that were changed, renamed or created.
Must run 24/7 on a server like environment.
Runs off of the VS.NET FileSystemWatcher class.

### Requirements

* AutoCAD (no license required)
* Windows Server

### How To Use

1) Edit the `DWG2PDFWatcher.exe.config` file with Notepad. Change the directory paths to match your system.
2) Open a command prompt as Administrator and use the following commands:
```
SC CREATE "DWG2PDFWatcher" binpath= "C:\PATH\TO\EXE\DWG2PDFWatcher.exe"
net start DWG2PDFWatcher
```
3) If there are any errors starting the service, check your `Event Viewer > Applications`.
