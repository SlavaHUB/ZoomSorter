using CopyTests;

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();

string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string pathSource = Path.Join(pathDesktop, "SortedZoomVideo");

FileCreator fileCreator = new FileCreator(pathSource);
fileCreator.CreateMainFolder("Videos");

Console.Write("INPUT DATE COPY SATRT: ");
string? startDateString = Console.ReadLine();
if (startDateString == null) return;
DateTime startDate = DateTime.ParseExact(startDateString, "dd.MM.yyyy", null);

// string zoomPath = @$"C:\Users\{Environment.UserName}\Documents\Zoom";
string zoomPath = @"D:\test\";

FileCopyRater fileCopyRater = new FileCopyRater(zoomPath, fileCreator.FullPath);
fileCopyRater.CopyFiles(startDate);

Console.WriteLine($"MAIN DIR: {pathSource}");
Console.WriteLine();
