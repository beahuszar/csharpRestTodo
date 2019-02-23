using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestTodo.Configurations;
using RestTodo.Data;
using RestTodo.Utility;

namespace RestTodo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CsharpTodoDb>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRepositories();
            services.AddServices();
            var configuredMapper = new AutoMapper.MapperConfiguration(c => c.AddProfile(new AutoMapperConfig())).CreateMapper();
            services.AddSingleton(configuredMapper);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
