using Microsoft.Extensions.DependencyInjection;
using RestTodo.DTOs;
using RestTodo.Interfaces;
using RestTodo.Services;

namespace RestTodo.Configurations
{
    public static class ServiceConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICrudService<TodoDto>, TodoService>();
            services.AddScoped<ICrudService<AssigneeDto>, AssigneeService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
