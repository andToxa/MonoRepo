using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UberPopug.Tasks.Controllers;

/// <summary>
/// Контроллер
/// </summary>
[ApiController]
[Authorize]
/*[Authorize(Roles = "FieldOM_supportTeam")]
[Authorize(Policy = "Policy Name")]*/
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// Конструктор <see cref="WeatherForecastController"/>
    /// </summary>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Получение данных
    /// </summary>
    /// <returns><see cref="ClaimsPrincipal"/></returns>
    [HttpGet]
    public ClaimsPrincipal Get()
    {
        return HttpContext.User;
    }
}