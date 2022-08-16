using Identity.Infrastructure.Database.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Infrastructure.Services
{
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
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("string.Empty")); // todo Encoding.UTF8.GetBytes(config["TokenKey"])
        }

        /// <inheritdoc />
        public string CreateToken(UserModel userModel)
        {
            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, userModel.UserName) };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7), // todo
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}