using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace UberPopug.Tasks.Pages;

/// <inheritdoc />
[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
public class ErrorModel : PageModel
{
    private readonly ILogger<ErrorModel> _logger;

    /// <summary>
    /// Конструктор <see cref="ErrorModel"/>
    /// </summary>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Идентификатор запроса
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Флаг отображения <see cref="RequestId"/>
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    /// <summary>
    /// Получение <see cref="RequestId"/>
    /// </summary>
    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}