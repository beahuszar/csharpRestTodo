using AutoMapper;
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
        private readonly IMapper mapper;

        public TodoService(ICrudRepository<Todo> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public IEnumerable<TodoDto> GetAll()
        {
            return mapper.Map<IEnumerable<TodoDto>>(repository.GetAll());
        }

        public TodoDto GetById(long id)
        {
            return mapper.Map<TodoDto>(repository.GetById(id));
        }

        public bool IsInDataBase(long id)
        {
            return repository.IsInDataBase(id);
        }

        public void Save(TodoDto dto)
        {
            repository.Save(mapper.Map<Todo>(dto));
        }

        public void Update(TodoDto dto, long id)
        {
            var todoToUpdate = repository.GetById(id);
            var updatedTodo = mapper.Map<TodoDto, Todo>(dto, todoToUpdate);
            repository.Update(updatedTodo);
        }
    }
}
