namespace CopyTests;

public class DirInfoEntity
{
    public string originalDir { get; set; }
    public string dayOfWeek { get; set; }
    public DateTime time { get; set; }
    public string name { get; set; }
    public string categories { get; set; }
    
    public  string[] videos { get; set; }
    public static string GetShortDayOfWeek(string fullWeekDay)
    {
        var weekDays = new List<string>()
        {
            "ВС", "ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ"
        };

        var dayOfWeek = new Dictionary<string, string>();

        for (int i = 0; i < weekDays.Count; i++)
        {
            dayOfWeek.Add(((DayOfWeek)i).ToString(), weekDays[i]);
        }

        return dayOfWeek[fullWeekDay];
    }

    public override string ToString()
    {
        return $"{time}".Replace(':', '.') + @$"-{name}.mp4";
    }
}