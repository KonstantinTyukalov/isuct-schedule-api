using Interfaces;
using Models;

namespace Services;

public class ScheduleService: IScheduleService
{
    private readonly IUniversityApiService _universityApiService;
    public ScheduleService(IUniversityApiService universityApiService)
    {
        this._universityApiService = universityApiService;
    }
    public Group GetGroupSchedule(string group)
    {
        var fullSchedule = this._universityApiService.GetSchedule();
        var groupSchedule = fullSchedule.Faculties.First(x => x.Groups.Any(x => x.Name == group)).Groups.First(x => x.Name == group);

        return groupSchedule;

    }
}
