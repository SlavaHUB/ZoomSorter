using CopyTests;

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();

string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string pathSource = Path.Join(pathDesktop, "SortedZoomVideo");

FileCreator fileCreator = new FileCreator(pathSource);
fileCreator.CreateMainFolder("Videos");

string zoomPath = @$"C:\Users\{Environment.UserName}\Documents\Zoom";

FileCopyRater fileCopyRater = new FileCopyRater(zoomPath, fileCreator.FullPath);
fileCopyRater.CopyFiles();

Console.WriteLine($"MAIN DIR: {pathSource}");
Console.WriteLine();
