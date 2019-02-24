using RestTodo.DTOs;
using RestTodo.Models;

namespace RestTodo.Utility
{
    public class AutoMapperConfig : AutoMapper.Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Todo, TodoDto>()
                .ReverseMap();
            CreateMap<Assignee, AssigneeDto>()
                .ReverseMap();
        }
    }
}
