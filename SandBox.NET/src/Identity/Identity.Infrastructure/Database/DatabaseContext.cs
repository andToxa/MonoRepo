using Identity.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Identity.Infrastructure.Database;

/// <inheritdoc />
public class DatabaseContext : IdentityUserContext<UserModel, Guid>
{
    /// <inheritdoc cref="IdentityUserContext{TUser, TKey}"/>
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
    }
}