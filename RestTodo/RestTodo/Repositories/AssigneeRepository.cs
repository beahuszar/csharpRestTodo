using RestTodo.Data;
using RestTodo.Interfaces;
using RestTodo.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestTodo.Repositories
{
    public class AssigneeRepository : ICrudRepository<Assignee>
    {
        private readonly CsharpTodoDb context;

        public AssigneeRepository(CsharpTodoDb context)
        {
            this.context = context;
        }

        public void Delete(long id)
        {
            context.Remove(GetById(id));
            context.SaveChanges();
        }

        public IEnumerable<Assignee> GetAll()
        {
            return context.Assignees;
        }

        public Assignee GetById(long id)
        {
            return context.Assignees.Find(id);
        }

        public bool IsInDataBase(long id)
        {
            return context.Assignees.Any(assignee => assignee.Id == id) ? true : false;
        }

        public void Save(Assignee entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Assignee entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
