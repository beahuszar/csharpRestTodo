using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestTodo.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestTodo.Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration Configuration { get; }

        public AuthService(IConfiguration configuration) => this.Configuration = configuration;

        //user claimjeit berakjuk ahova kell, a többit meg bekonfigoljuk
        public string GetToken(IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                //create the credentials used to generate (sign) the token
                signingCredentials: this.GetSigningCredentials(this.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                issuer: Configuration["jwt:issuer"],
                audience: Configuration["jwt:audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                notBefore: DateTime.UtcNow);
            //return token to user
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey() =>
            //make sure we sign with the exact same key, so that is can be decrypted
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:secretKey"]));

        private SigningCredentials GetSigningCredentials(SecurityKey key, string algorithm) =>
            //how it is signed? - inputs are given in above method (our sec key + sha256)
            new SigningCredentials(key, algorithm);
    }
}
