using System.Text.RegularExpressions;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivitiesService _activitiesService;
    public ActivitiesController(IActivitiesService activitiesService)
    {
        _activitiesService = activitiesService;
    }
    [HttpGet]
    public object GetActivitiesByGroup([FromQuery] string group)
    {
        System.Console.WriteLine($"Group: {group} ");
        var fixedGroup = Regex.Replace(group, "/", "-");

        return _activitiesService.GetActivitiesByLessons(fixedGroup);
    }
}
