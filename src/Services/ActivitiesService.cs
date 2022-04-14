using System;
using Interfaces;
using Models;
using Models.Activities;

namespace Services;

public class ActivitiesService : IActivitiesService
{
    private readonly IScheduleService _scheduleService;
    public ActivitiesService(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }
    public List<Activity> GetActivitiesByLessons(string group)
    {
        var lessons = _scheduleService.GetGroupLessons(group);
        var activities = new List<Activity>();

        foreach (var lesson in lessons)
        {
            activities.Add(this.ConvertLessonToActivity(lesson));
        }
        return activities;
    }

    private Activity ConvertLessonToActivity(Lesson lesson)
    {
        var name = $"{lesson.Subject}({lesson.Type})";

        var tl = new List<string>();
        foreach (var t in lesson.Teachers)
        {
            tl.Add(t.Name);
        }
        var teachers = String.Join(", ", tl);

        var desctiption = $"Аудитория: {lesson.Audiences[0].Name}\n Преподаватели: {teachers}";
        var time = new ActivityTime()
        {
            StartTime = lesson.Time.Start,
            EndTime = lesson.Time.End
        };

        var date = DateTime.Today;

        return new Activity()
        {
            Name = name,
            Description = desctiption,
            Time = time,
            Date = date
        };
    }


}
