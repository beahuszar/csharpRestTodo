using Microsoft.AspNetCore.Mvc;
using RestTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTodo.Controllers
{
    [ApiController]
    [Route("todo")]
    public class TodoController : Controller
    {
        [HttpGet("list")]
        public IActionResult GetTodos()
        {
            return Ok(new Todo());
        }

        

    }
}
