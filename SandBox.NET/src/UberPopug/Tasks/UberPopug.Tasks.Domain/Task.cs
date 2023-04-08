using Common.Domain.ValueObjects;
using System;

namespace UberPopug.Tasks.Domain;

/// <summary>
/// Задача
/// </summary>
public class Task
{
    /// <summary>
    /// Конструктор <see cref="Task"/>
    /// </summary>
    /// <param name="taskId"><see cref="Id{T}"/></param>
    public Task(Id<Task> taskId)
    {
        TaskId = taskId;
    }

    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    public Id<Task> TaskId { get; }

    /// <summary>
    /// Идентификатор в виде <see cref="Guid"/>
    /// </summary>
    public Guid Guid
    {
        get => TaskId.ToGuid();
        set { }
    }
}