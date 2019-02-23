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
            return mapper.Map<IEnumerable<AssigneeDto>>(GetAll());
        }

        public AssigneeDto GetById(long id)
        {
            return mapper.Map<AssigneeDto>(GetById(id));
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
