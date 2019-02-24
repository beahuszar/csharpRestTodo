using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestTodo.Interfaces;

namespace RestTodo.Controllers
{
    /// <summary>
    /// Manages the Web API calls
    /// [Authorize] is picking the default auth scheme from authconfig, thus we have to specify
    /// here that through this endpoint we want to use google
    /// </summary>
    [Authorize(AuthenticationSchemes = GoogleDefaults.AuthenticationScheme)] //itt most a google-t használja, a default a JWT
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        //azé köpjük vissza mert frontend majd lekezeli
        [HttpGet("/auth")]
        public IActionResult Auth()
        {
            //itt generáljuk a tokent a servicen keresztül
            return Ok(_authService.GetToken(User.Claims));
        }
    }
}
