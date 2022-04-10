using Newtonsoft.Json;
using Models;

namespace Services;

public class ScheduleService
{
    public static object GetGroupSchedule(string group)
    {
        using (var http = new HttpClient())
        {
            var jsonStr = http.GetStringAsync("https://forms.isuct.ru/timetable/rvuzov").Result;
            var fullSchedule = JsonConvert.DeserializeObject<Schedule>(jsonStr);
            var groupSchedule = fullSchedule.Faculties.First(x => x.Groups.Any(x => x.Name == group)).Groups.First(x => x.Name == group);

            return groupSchedule;
        }
    }
}
