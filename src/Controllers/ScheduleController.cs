using System.Text.RegularExpressions;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;
    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }
    [HttpGet]
    public object Get([FromQuery] string group)
    {
        System.Console.WriteLine($"Group: {group} ");
        var fixedGroup = Regex.Replace(group, "/", "-");

        return _scheduleService.GetGroupLessons(fixedGroup);
    }
}
