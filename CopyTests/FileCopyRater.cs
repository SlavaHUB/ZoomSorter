namespace CopyTests;

public class FileCopyRater
{
    private readonly string _targetPath;
    private readonly string _fullPath;
    
    public FileCopyRater(string copyPath, string fullPath)
    {
        _targetPath = copyPath;
        _fullPath = fullPath;
    }

    public void CopyFiles(DateTime dateFilter)
    {
        var targetDirectories = GetDirs();
        var directoriesInfo = GetDirInfoEntities(targetDirectories);
        int totalFiles = directoriesInfo.Sum(dirInfo => dirInfo.videos.Length);
        int copiedFiles = 0;
        int progressBarWidth = 40;
        
        foreach (var directoryInfo in directoriesInfo.Where(directory => directory.time >= dateFilter))
        {
           Console.WriteLine();
            foreach (string filePath in directoryInfo.videos)
            {
                string fileName = Path.GetFileName(directoryInfo.ToString());
                string weekPath = Path.Combine(_fullPath, directoryInfo.dayOfWeek, directoryInfo.categories);
                string targetFilePath = Path.Combine(weekPath, fileName);
                File.Copy(filePath, targetFilePath, true);
                copiedFiles++;
                Console.Clear();
                Console.WriteLine("Copying files:");
                ProgressBar.UpdateProgressBar(copiedFiles, totalFiles, progressBarWidth);
            }
        }
        
        Console.WriteLine($"Total Copy Files: {totalFiles}".ToUpper());
    }

    private string[] GetDirs()
    {
        return Directory.GetDirectories(_targetPath, "*", SearchOption.TopDirectoryOnly);
    }

    private List<DirInfoEntity> GetDirInfoEntities(string[] directories)
    {
        List<DirInfoEntity> directoryInfos = new List<DirInfoEntity>();
        
        for(int i = 0; i < directories.Length; i++)
        {
            string dirName = directories[i].Split(@"\", StringSplitOptions.RemoveEmptyEntries).Last();
            string[] dirNameInfo = dirName.Split(" ");
            string dateString = dirNameInfo[0] + " " + dirNameInfo[1];
            DateTime lessonDate = DateTime.ParseExact(dateString, "yyyy-MM-dd HH.mm.ss", null);
            DayOfWeek dayOfWeek = lessonDate.DayOfWeek;
            string nameWithCather = dirName[(dateString.Length + 1)..];
            string[] dirVideos = GetVideoPaths(directories[i]);

            if (nameWithCather.IndexOf("zoom5", StringComparison.Ordinal) != -1)
            {
                DirInfoEntity dirInfoEntity = new DirInfoEntity()
                {
                    originalDir = directories[i],
                    name = nameWithCather[("zoom5".Length + 1)..],
                    dayOfWeek = DirInfoEntity.GetShortDayOfWeek(dayOfWeek.ToString()),
                    categories = "Zoom5",
                    time = lessonDate,
                    videos = dirVideos
                };
                directoryInfos.Add(dirInfoEntity);
            }
            else if(nameWithCather.IndexOf("zoom5", StringComparison.Ordinal) != -1)
            {
                DirInfoEntity dirInfoEntity = new DirInfoEntity()
                {
                    originalDir = directories[i],
                    name = TruncateFromEnd(nameWithCather, 7),
                    dayOfWeek = DirInfoEntity.GetShortDayOfWeek(dayOfWeek.ToString()),
                    categories = "Zoom4",
                    time = lessonDate,
                    videos = dirVideos
                };
                directoryInfos.Add(dirInfoEntity);
            }
            else
            {
                DirInfoEntity dirInfoEntity = new DirInfoEntity()
                {
                    originalDir = directories[i],
                    name = nameWithCather[(dateString.Length + 1)..],
                    dayOfWeek = DirInfoEntity.GetShortDayOfWeek(dayOfWeek.ToString()),
                    categories = "Zoom4",
                    time = lessonDate,
                    videos = dirVideos
                };
                directoryInfos.Add(dirInfoEntity);
            }
        }
       

        return directoryInfos;
    }
    
    private string TruncateFromEnd(string input, int length)
    {
        if (length >= input.Length)
        {
            return input;
        }

        return input.Substring(0, input.Length - length);
    }
    
    private string[] GetVideoPaths(string directoryPath)
    {
        return Directory.GetFiles(directoryPath, "*.mp4");
    }
    
}
