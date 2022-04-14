using Models.Activities;

namespace Interfaces;

public interface IActivitiesService
{
    public List<Activity> GetActivitiesByLessons(string group);
}
