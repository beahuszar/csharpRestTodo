using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestTodo.Configurations
{
    public static class AuthConfig
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration Configuration)
        {
            //authenticate the user
            //create, manage users login, logout, remove users
            //sets the HTTPContext.user => authenticated user
            //adds scoped classesfor things like Usermanager, SignInManager, PasswordHasher etc
            services.AddIdentity<IdentityUser, IdentityRole>();

            //add JWT Authentication (bearer token) for API clients
            services.AddAuthentication(options =>
            {
                //we replaced the default cookie authentication to be default JWT
                //mi legyen az alap auth séma -> [Authorize] ez alapján fog authorizálni
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerOptions =>
            {
                JwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    //token claimjei, miket vizsgáljon
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    //-----------how to validate the above claims----------------
                    //turning the key into bytes => symmetric key
                    //has to be min 16char, sha-256 (128bits -> 16bytes)
                    //token is validate through this key
                    //part of the key tells which way it's been encoded -> flexible
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:secretKey"])),
                    //kitől kapjuk a tokent, bármi lehet itt, csak info miatt van
                    ValidIssuer = Configuration["jwt:issuer"],
                    //ki kapja a tokent (webapp/site), bármi lehet itt, csak info miatt van 
                    ValidAudience = Configuration["jwt:audience"]
                };
            })
            .AddGoogle(options => 
            {
                options.ClientId = Configuration["google:clientID"];
                options.ClientSecret = Configuration["google:clientSecret"];
                options.Events.OnCreatingTicket = context =>
                {
                    var profilePic = context.User.SelectToken("image.url").ToString();
                    context.Identity.AddClaim(new Claim("profilePic", profilePic));
                    return Task.CompletedTask;
                };
            });
        }
    }
}
