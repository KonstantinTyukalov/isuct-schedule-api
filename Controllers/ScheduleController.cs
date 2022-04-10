using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class ScheduleController : ControllerBase
{
    [HttpGet]
    public object Get([FromQuery] string group)
    {
        System.Console.WriteLine($"Group: {group} ");
        var fixedGroup = Regex.Replace(group, "/", "-");

        return ScheduleService.GetGroupSchedule(fixedGroup);
    }
}
