using RestTodo.DTOs;
using RestTodo.Interfaces;
using RestTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTodo.Services
{
    public class TodoService : ICrudService<TodoDto>
    {
        private readonly ICrudRepository<Todo> repository;

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoDto GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(TodoDto dto)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
