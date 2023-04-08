using Common.Domain.ValueObjects;
using Marten;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Task = UberPopug.Tasks.Domain.Task;

namespace UberPopug.Tasks.WebAPI.Controllers;

/// <summary>
/// Контроллер
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize]
[ApiVersion("1.0")]
/*[Authorize(Roles = "FieldOM_supportTeam")]
[Authorize(Policy = "Policy Name")]*/
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IDocumentStore _documentStore;

    /// <summary>
    /// Конструктор <see cref="WeatherForecastController"/>
    /// </summary>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
    /// <param name="documentStore"><see cref="IDocumentStore"/></param>
    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IDocumentStore documentStore)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _documentStore = documentStore ?? throw new ArgumentNullException(nameof(documentStore));
    }

    /// <summary>
    /// Получение данных
    /// </summary>
    /// <param name="guid"><see cref="Guid"/></param>
    /// <remarks>
    /// Пример запроса
    /// </remarks>
    /// <returns><see cref="UberPopug.Tasks.Domain.Task"/></returns>
    [HttpGet("{guid:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult> GetAsync(Guid guid)
    {
        await using var session = _documentStore.QuerySession();
        var existing = await session
            .Query<UberPopug.Tasks.Domain.Task>()
            .SingleAsync(x => x.Guid == guid);

        return Ok(existing.TaskId);
    }

    /// <summary>
    /// Создание задач
    /// </summary>
    /// <returns><see cref="ActionResult"/></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> CreateTaskAsync()
    {
        await using (var session = _documentStore.LightweightSession())
        {
            var user = new UberPopug.Tasks.Domain.Task(new Id<Task>());
            session.Store(user);

            await session.SaveChangesAsync();
        }

        return Ok();
    }
}