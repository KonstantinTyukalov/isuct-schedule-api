using Models;

namespace Interfaces;

public interface IScheduleService
{
    public Group GetGroupSchedule(string group);

    public List<Lesson> GetGroupLessons(string group);
}
