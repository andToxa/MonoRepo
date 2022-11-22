using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Infrastructure.Database.Models;

/// <inheritdoc />
public class UserModel : IdentityUser<Guid>
{
}