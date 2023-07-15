using System;
using System.Collections.Generic;
using System.IO;

namespace CopyTests;

public class FileCreator
{
    private string _targetPath;
    private string _fullPath;

    public string FullPath => _fullPath;

    public FileCreator()
    {
        string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        _targetPath = Path.Join(pathDesktop, "SortedZoomVideo");
    }
    
    public FileCreator(string targetPath)
    {
        _targetPath = targetPath;
    }

    public void CreateMainFolder(string fileName)
    {
        _fullPath = Path.Join(_targetPath, fileName);
        Directory.CreateDirectory(_fullPath);
        CreateWeekFolders(_fullPath);
    }

    private void CreateWeekFolders(string fullPath)
    {
        var weekDays = new List<string>()
        {
            "ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС"
        };
        
        weekDays.ForEach(weekDay =>
        {
            string pathWeekDay = Path.Join(fullPath, weekDay);
            Directory.CreateDirectory(pathWeekDay);
            CreateCategory(pathWeekDay);
        });
        
    }

    private void CreateCategory(string path)
    {
        Directory.CreateDirectory(Path.Join(path, "Zoom5"));
        Directory.CreateDirectory(Path.Join(path, "Zoom4"));
        Directory.CreateDirectory(Path.Join(path, "Another"));
    }
}