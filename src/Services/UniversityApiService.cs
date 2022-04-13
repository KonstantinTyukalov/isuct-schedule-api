using Newtonsoft.Json;
using Models;
using Interfaces;

namespace Services;

public class UniversityApiService : IUniversityApiService
{
    private Schedule _schedule = null;
    private readonly FileService _fileService;

    public UniversityApiService(FileService fileService)
    {
        _fileService = fileService;
    }

    public Schedule GetSchedule()
    {
        try
        {
            if (_schedule != null)
            {
                Console.WriteLine("Schedule already exist in memory");
                return _schedule;
            }
            var scheduleFromFile = this.GetScheduleFromFile("schedule.json");
            if (scheduleFromFile != null)
            {
                _schedule = scheduleFromFile;
                return _schedule;
            }

            _schedule = this.FetchSchedule();
            Console.WriteLine("Writing schedule to the file...");
            this.WriteScheduleToFile(_schedule, "schedule.json");

            return _schedule;
        }
        catch (Exception e)
        {
            throw new Exception("Error with getting the schedule: " + e.Message);
        }
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

    private Schedule GetScheduleFromFile(string fileName)
    {
        try
        {
            Console.WriteLine("Getting schedule from file...");
            var rawJson = _fileService.ReadFile(fileName);

            var schedule = JsonConvert.DeserializeObject<Schedule>(rawJson);

            return schedule;
        }
        catch (Exception e)
        {
            Console.WriteLine("Problems with getting schedule from file: " + e.Message);

            return null;
        }
    }

    private void WriteScheduleToFile(Schedule schedule, string fileName)
    {
        try
        {
            var scheduleString = JsonConvert.SerializeObject(schedule);

            _fileService.WriteFile(fileName, scheduleString);
            Console.WriteLine($"Schedule was recorded in {fileName} cache file");
        }
        catch (Exception e)
        {
            throw new Exception($"Error when writing schedule to file {fileName}: " + e.Message);
        }
    }
}
