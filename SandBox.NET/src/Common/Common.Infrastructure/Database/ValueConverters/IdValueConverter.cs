using Common.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Common.Infrastructure.Database.ValueConverters;

/// <inheritdoc />
// https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations
public class IdValueConverter<T> : ValueConverter<Id<T>, Guid>
{
    /// <inheritdoc cref="ValueConverter"/>
    public IdValueConverter()
    : base(id => id.ToGuid(), guid => new Id<T>(guid))
    {
    }
}

// Then, override ConfigureConventions in your context type and configure the converter as follows:
//
// protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
// {
//     configurationBuilder
//         .Properties<Currency>()
//         .HaveConversion<CurrencyConverter>();
// }