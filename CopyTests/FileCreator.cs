namespace CopyTests;

public class FileCreator
{
    private string _targetPath;
    private string _sourcePath;

    public FileCreator()
    {
        
    }
    
    public FileCreator(string sourcePath, string targetPath)
    {
        this._sourcePath = sourcePath;
        this._targetPath = targetPath;
    }
}