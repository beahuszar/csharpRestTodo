using Microsoft.EntityFrameworkCore;

namespace RestTodo.Data
{
    public class CsharpTodoDb : DbContext
    {
        public CsharpTodoDb(DbContextOptions<CsharpTodoDb> options) : base(options)
        {
        }
    }
}
