﻿using AutoMapper;
using RestTodo.DTOs;
using RestTodo.Interfaces;
using RestTodo.Models;
using System.Collections.Generic;

namespace RestTodo.Services
{
    public class AssigneeService : ICrudService<AssigneeDto>
    {
        private readonly ICrudRepository<Assignee> repository;
        private readonly IMapper mapper;

        public AssigneeService(ICrudRepository<Assignee> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public IEnumerable<AssigneeDto> GetAll()
        {
            return mapper.Map<IEnumerable<AssigneeDto>>(repository.GetAll());
        }

        public AssigneeDto GetById(long id)
        {
            return mapper.Map<AssigneeDto>(repository.GetById(id));
        }

        public bool IsInDataBase(long id)
        {
            return repository.IsInDataBase(id);
        }

        public void Save(AssigneeDto dto)
        {
            repository.Save(mapper.Map<Assignee>(dto));
        }

        public void Update(AssigneeDto dto, long id)
        {
            repository.Update(mapper.Map<AssigneeDto, Assignee>(dto, repository.GetById(id)));
        }
    }
}
