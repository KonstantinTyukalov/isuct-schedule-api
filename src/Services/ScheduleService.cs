using Newtonsoft.Json;
using Models;

namespace Services;

public class ScheduleService
{
    public static object GetGroupSchedule(string group)
    {
        var fullSchedule = ScheduleService.FetchSchedule();
        var groupSchedule = fullSchedule.Faculties.First(x => x.Groups.Any(x => x.Name == group)).Groups.First(x => x.Name == group);

        return groupSchedule;

    }

    public static Schedule FetchSchedule()
    {
        var apiUrl = "https://forms.isuct.ru/timetable/rvuzov";
        using (var http = new HttpClient())
        {
            try
            {
                var jsonStr = http.GetStringAsync(apiUrl).Result;
                var schedule = JsonConvert.DeserializeObject<Schedule>(jsonStr);

                return schedule;
            }
            catch (Exception e)
            {
                throw new Exception("Error when fetching schedule: " + e.Message);
            }
        }
    }
}
