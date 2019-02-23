using Microsoft.AspNetCore.Mvc;
using RestTodo.Extenstions;
using RestTodo.Models;
using RestTodo.Utility;
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
            
        }

        [HttpGet("{id}")]
        public IActionResult GetTodoById()
        {
           
        }

        [HttpPost("new")]
        [Consumes("application/json")]
        public IActionResult AddNewTodo(PostTodo postTodo)
        {
            
        }

        [HttpPut("edit/{id}")]
        [Consumes("application/json")]
        public IActionResult EditTodo()
        {
            
        }

        [HttpDelete("{id}/delete")]
        public IActionResult DeleteTodo()
        {
            
        }
    }
}
