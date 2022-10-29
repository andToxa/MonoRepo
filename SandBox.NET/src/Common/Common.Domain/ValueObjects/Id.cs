using Common.Domain.ValueObjects.Converters;
using System;
using System.Text.Json.Serialization;

namespace Common.Domain.ValueObjects;

/// <summary>Идентификатор сущности</summary>
/// <typeparam name="T">Тип Сущности</typeparam>
[JsonConverter(typeof(IdJsonConverterFactory))]
public record Id<T>
{
    private readonly Guid _guid;

    /// <summary>
    /// Конструктор <see cref="Id{T}"/>
    /// </summary>
    public Id()
    {
        _guid = Guid.NewGuid();
    }

    /// <summary>
    /// Конструктор <see cref="Id{T}"/>
    /// </summary>
    /// <param name="guid"><see cref="Guid"/></param>
    public Id(Guid guid)
    {
        _guid = guid;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _guid.ToString();
    }
}