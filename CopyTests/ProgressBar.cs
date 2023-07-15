namespace CopyTests;

public static class ProgressBar
{
    public static void UpdateProgressBar(int current, int total, int progressBarWidth)
    {
        decimal progressPercentage = (decimal)current / total;
        int progressLength = (int)(progressBarWidth * progressPercentage);
        int dotsLength = progressBarWidth - progressLength;
        Console.Write("\r[");
        Console.Write(new string('=', progressLength));
        Console.Write(new string('.', dotsLength));
        Console.Write($"] {progressPercentage:P0}");
        Console.WriteLine();
    }
}