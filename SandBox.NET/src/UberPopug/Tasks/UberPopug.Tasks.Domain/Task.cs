using Common.Domain.ValueObjects;

namespace UberPopug.Tasks.Domain;

/// <summary>
/// Задача
/// </summary>
public class Task
{
    /// <summary>
    /// Конструктор <see cref="Task"/>
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    public Task(Id<Task> id)
    {
        Id = id;
    }

    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    public Id<Task> Id { get; }
}