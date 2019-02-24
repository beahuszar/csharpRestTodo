using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestTodo.DTOs;
using RestTodo.Extenstions;
using RestTodo.Interfaces;
using RestTodo.Utility;

namespace RestTodo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("ass")]
    public class AssigneeController : Controller
    {
        private readonly ICrudService<AssigneeDto> service;

        public AssigneeController(ICrudService<AssigneeDto> service)
        {
            this.service = service;
        }

        [HttpPost("new")]
        [Consumes("application/json")]
        public IActionResult CreateAssignee(AssigneeDto dto)
        {
            if (dto.IsAnyStringPropertyEmpty() || dto.IsAnyPropertyNull())
            {
                return StatusCode(400, new ErrorMessage("One or more fields are missing"));
            }
            service.Save(dto);
            return StatusCode(201);
        }

        [HttpGet("list")]
        public IActionResult GetAllAssignees()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetAssigneeById(long id)
        {
            return service.IsInDataBase(id) ? Ok(service.GetById(id)) : StatusCode(404, new ErrorMessage("Assignee not found"));
        }

        [HttpPut("edit/{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateTodo(AssigneeDto dto, long id)
        {
            if (service.IsInDataBase(id))
            {
                service.Update(dto, id);
                return StatusCode(201, new ResponseMessage("Updated"));
            }
            return StatusCode(404, new ErrorMessage("No such assignee"));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAssignee(long id)
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
