using Identity.Domain.Entities;
using Identity.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Infrastructure.Services;

/// <inheritdoc />
public class JwtGenerator : IJwtGenerator
{
    private readonly SymmetricSecurityKey _key;

    /// <summary>
    /// Конструктор <see cref="JwtGenerator"/>
    /// </summary>
    /// <param name="config"><see cref="IConfiguration"/></param>
    public JwtGenerator(IConfiguration config)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"] ?? "4C62D52D-D788-4940-8925-4A52111C0C85")); // todo переделать
    }

    /// <inheritdoc />
    public string CreateToken(User user) // todo возвращать VO
    {
        var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, user.Name) };

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = credentials,
        };
        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}