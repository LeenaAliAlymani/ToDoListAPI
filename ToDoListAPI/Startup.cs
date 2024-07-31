using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI
{
    public static class Startup
    {
        public static IServiceCollection AddModule(this IServiceCollection services, string? connectionString)
        {
            //على كيفي
            services.AddScoped<ITasksRepository, TasksRepository>();

            services.AddDbContext<ToDoListContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
