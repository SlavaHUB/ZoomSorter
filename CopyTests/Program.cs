using System;
using System.IO;

string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string pathSource = Path.Join(pathDesktop, "SortedZoomVideo");


Console.WriteLine(pathSource);