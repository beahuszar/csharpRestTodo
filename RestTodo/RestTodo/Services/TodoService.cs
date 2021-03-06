﻿using AutoMapper;
using RestTodo.DTOs;
using RestTodo.Interfaces;
using RestTodo.Models;
using System.Collections.Generic;

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
            var newTodo = mapper.Map<Todo>(dto);
            newTodo.Assignee = null;
            repository.Save(newTodo);
        }

        public void Update(TodoDto dto, long id)
        {
            repository.Update(mapper.Map<TodoDto, Todo>(dto, repository.GetById(id)));
        }
    }
}
