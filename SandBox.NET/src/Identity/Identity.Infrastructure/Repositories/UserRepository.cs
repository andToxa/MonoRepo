using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Identity.Domain.Entities;
using Identity.Domain.Repositories;
using Identity.Domain.ValueObjects;
using Identity.Infrastructure.Database;
using Identity.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories;

/// <inheritdoc />
public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly UserManager<UserModel> _userManager;

    /// <summary>
    /// Конструктор <see cref="UserRepository"/>
    /// </summary>
    /// <param name="databaseContext"><see cref="DatabaseContext"/></param>
    /// <param name="userManager"><see cref="UserManager{TUser}"/></param>
    public UserRepository(DatabaseContext databaseContext, UserManager<UserModel> userManager)
    {
        _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

        _userManager.Options.Password = new PasswordOptions
        {
            RequireDigit = UserPassword.Options.RequireDigit,
            RequiredLength = UserPassword.Options.RequiredLength,
            RequireLowercase = UserPassword.Options.RequireLowercase,
            RequireUppercase = UserPassword.Options.RequireUppercase,
            RequiredUniqueChars = UserPassword.Options.RequiredUniqueChars,
            RequireNonAlphanumeric = UserPassword.Options.RequireNonAlphanumeric,
        };

        // todo _userManager.Options.User... и т.п.
    }

    /// <inheritdoc cref="IUserRepository.RegisterAsync"/>
    public async Task<User> RegisterAsync(UserName userName, UserPassword userPassword)
    {
        if (await _databaseContext.Users.AnyAsync(user => user.UserName == userName))
        {
            throw new DomainException("Пользователь уже существует");
        }

        var userModel = new UserModel { UserName = userName }; // todo
        var result = await _userManager.CreateAsync(userModel, userPassword);

        if (result.Succeeded)
        {
            var id = Id<User>.New(userModel.Id);
            var name = UserName.New(userModel.UserName);
            var user = User.New(id, name);
            return user;
        }

        var domainException = new DomainException("Ошибка регистрации пользователя");
        foreach (var error in result.Errors)
        {
            domainException.Data.Add(error.Code, error.Description);
        }

        throw domainException;
    }
}