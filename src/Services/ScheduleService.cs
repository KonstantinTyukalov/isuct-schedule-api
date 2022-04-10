using Interfaces;
using Models;

namespace Services;

public class ScheduleService : IScheduleService
{
    private List<string> _uselesLessons = null;
    private readonly IUniversityApiService _universityApiService;
    public ScheduleService(IUniversityApiService universityApiService)
    {
        this._universityApiService = universityApiService;
        _uselesLessons = new List<string>()
        {
            "День самостоятельной работы",
        };
    }
    public Group GetGroupSchedule(string group)
    {
        var fullSchedule = this._universityApiService.GetSchedule();
        var groupSchedule = fullSchedule.Faculties.First(x => x.Groups.Any(x => x.Name == group)).Groups.First(x => x.Name == group);

        return groupSchedule;

    }

    public List<Lesson> GetGroupLessons(string group)
    {
        var groupSchedule = this.GetGroupSchedule(group);

        var lessons = groupSchedule.Lessons.FindAll(l => !_uselesLessons.Any(ul => ul == l.Subject));

        return lessons;
    }
}
