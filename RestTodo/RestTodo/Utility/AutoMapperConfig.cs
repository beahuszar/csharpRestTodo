using RestTodo.DTOs;
using RestTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
