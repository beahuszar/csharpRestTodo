using Microsoft.AspNetCore.Mvc;
using RestTodo.Extenstions;
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

        [HttpPost("new")]
        public IActionResult AddNewTodo(Todo todo)
        {
            if (todo.IsAnyPropertyNull() || todo.IsAnyStringPropertyEmpty())
            {
                return StatusCode(400, new ErrorMessage("Please provide all fields"));
            }

            return StatusCode(201, new ErrorMessage("success");
        }

    }
}
