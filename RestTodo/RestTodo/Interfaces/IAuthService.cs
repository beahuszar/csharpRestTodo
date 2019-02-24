using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestTodo.Interfaces
{
    public interface IAuthService
    {
        string GetToken(IEnumerable<Claim> claims); //token "propertijei"
    }
}
