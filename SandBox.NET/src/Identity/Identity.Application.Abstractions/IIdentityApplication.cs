using Identity.Application.Commands;
using Identity.Application.Queries;

namespace Identity.Application.Abstractions;

/// <summary>
/// Интерфейс Identity.Application
/// </summary>
public interface IIdentityApplication : IIdentityCommands, IIdentityQueries
{
}