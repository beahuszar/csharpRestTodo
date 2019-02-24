using Microsoft.Extensions.DependencyInjection;
using RestTodo.Interfaces;
using RestTodo.Models;
using RestTodo.Repositories;

namespace RestTodo.Configurations
{
    public static class RepositoryConfig
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICrudRepository<Todo>, TodoRepository>();
            services.AddScoped<ICrudRepository<Assignee>, AssigneeRepository>();
        }
    }
}
