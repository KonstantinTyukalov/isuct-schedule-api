using Newtonsoft.Json;
using Models;
using Interfaces;

namespace Services;

public class UniversityApiService: IUniversityApiService
{
    private Schedule _schedule = null;

    public Schedule GetSchedule()
    {
        if (this._schedule != null)
        {
            Console.WriteLine("Schedule already exist in memory");
            return _schedule;
        }
        this._schedule = this.FetchSchedule();

        return this._schedule;
    }

    private Schedule FetchSchedule()
    {
        var apiUrl = "https://forms.isuct.ru/timetable/rvuzov";
        using var http = new HttpClient();
        try
        {
            Console.WriteLine("Fetching university schedule...");
            var jsonStr = http.GetStringAsync(apiUrl).Result;
            var schedule = JsonConvert.DeserializeObject<Schedule>(jsonStr);

            return schedule;
        }
        catch (Exception e)
        {
            this._schedule = null;
            throw new Exception("Error when fetching schedule: " + e.Message);
        }
    }
}
