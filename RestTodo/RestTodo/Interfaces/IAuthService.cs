using System.Collections.Generic;
using System.Security.Claims;

namespace RestTodo.Interfaces
{
    public interface IAuthService
    {
        string GetToken(IEnumerable<Claim> claims); //token "propertijei"
    }
}
