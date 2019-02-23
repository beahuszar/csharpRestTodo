using Microsoft.EntityFrameworkCore;
using RestTodo.Models;

namespace RestTodo.Data
{
    public class CsharpTodoDb : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public CsharpTodoDb(DbContextOptions<CsharpTodoDb> options) : base(options)
        {
        }
    }
}
