using AutoMapper;
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
            return mapper.Map repository.GetAll();
        }

        public AssigneeDto GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool IsInDataBase(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(AssigneeDto dto)
        {
            throw new NotImplementedException();
        }

        public void Update(AssigneeDto dto, long id)
        {
            throw new NotImplementedException();
        }
    }
}
