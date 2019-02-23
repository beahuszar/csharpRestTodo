using RestTodo.Data;
using RestTodo.Interfaces;
using RestTodo.Models;
using System;
using System.Collections.Generic;

namespace RestTodo.Repositories
{
    public class TodoRepository : ICrudRepository<Todo>
    {
        private readonly CsharpTodoDb context;

        public TodoRepository(CsharpTodoDb context)
        {
            this.context = context;
        }

        public void Delete(long id)
        {
            context.Todos.Remove(GetById(id));
        }

        public IEnumerable<Todo> GetAll()
        {
            return context.Todos;
        }

        public Todo GetById(long id)
        {
            return context.Todos.Find(id);
        }

        public void Save(Todo entity)
        {
            context.Todos.Add(entity);
            context.SaveChanges();
        }

        public void Update(Todo entity)
        {
            throw new NotImplementedException();
        }
    }
}
