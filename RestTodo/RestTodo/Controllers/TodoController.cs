﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestTodo.DTOs;
using RestTodo.Interfaces;
using RestTodo.Utility;

namespace RestTodo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("todo")]
    public class TodoController : Controller
    {
        private readonly ICrudService<TodoDto> service;

        public TodoController(ICrudService<TodoDto> service)
        {
            this.service = service;
        }

        [HttpPost("new")]
        [Consumes("application/json")]
        public IActionResult CreateTodo(TodoDto dto)
        {
            /*if (dto.IsAnyStringPropertyEmpty() || dto.IsAnyPropertyNull())
            {
                return StatusCode(400, new ErrorMessage("One or more fields are missing"));
            }*/
            service.Save(dto);
            return StatusCode(201);
        }

        [HttpGet("list")]
        public IActionResult GetAllTodos()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetTodoById(long id)
        {
            return service.IsInDataBase(id) ? Ok(service.GetById(id)) : StatusCode(404, new ErrorMessage("Todo not found"));
        }

        [HttpPut("edit/{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateTodo(TodoDto dto, long id)
        {
            if (service.IsInDataBase(id))
            {
                service.Update(dto, id);
                return StatusCode(201, new ResponseMessage("Updated"));
            }
            return StatusCode(404, new ErrorMessage("No such todo"));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTodo(long id)
        {
            if (service.IsInDataBase(id))
            {
                service.Delete(id);
                return Ok();
            }
            return StatusCode(404, new ErrorMessage("No such todo"));
        }
    }
}