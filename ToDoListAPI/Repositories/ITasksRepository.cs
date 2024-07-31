
using ToDoListAPI.Models;
using ToDoListAPI.CustomModels;
namespace ToDoListAPI.Repositories;

public interface ITasksRepository
{
    Task<IEnumerable<TaskModel>> Get();
    Task<TaskModel> Get(int id);

    Task<TaskModel> Create(TasksDto t);

    Task Update(TasksDto t);

    Task Delete(int id);
}
