using RestTodo.Data;
using RestTodo.Interfaces;
using RestTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool IsInDataBase(long id)
        {
            return context.Todos.Any(todo => todo.Id == id) ? true : false;
        }

        public void Update(Todo entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
