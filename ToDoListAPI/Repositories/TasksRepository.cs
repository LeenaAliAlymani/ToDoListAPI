using ToDoListAPI.CustomModels;
using ToDoListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Repositories
{
    public class TasksRepository : ITasksRepository
    {

        private readonly ToDoListContext _ToDoListContext;
        public TasksRepository(ToDoListContext context)
        {
            _ToDoListContext = context;
        }



        public async Task<IEnumerable<TaskModel>> Get()
        {
            return await _ToDoListContext.Tasks.ToListAsync();
        }



        public async Task<TaskModel?> Get(int id)
        {
            return await _ToDoListContext.Tasks.Include(x => x.Attachments).FirstOrDefaultAsync(x => x.TaskId == id);
        }



        public async Task<TaskModel> Create(TasksDto b)
        {
            var taskMap = new TaskModel
            {
                TaskId = b.TaskId,
                Title = b.Title,
                Description = b.Description,
                DueDate = b.DueDate,
                Priority = b.Priority,
                Status = b.Status

            };
            _ToDoListContext.Tasks.Add(taskMap);
            await _ToDoListContext.SaveChangesAsync();
            return taskMap;
        }



        public async Task Update(TasksDto b)
        {
            var taskMap = new TaskModel
            {
                TaskId = b.TaskId,
                Title = b.Title,
                Description = b.Description,
                DueDate = b.DueDate,
                Priority = b.Priority,
                Status = b.Status
            };
            _ToDoListContext.Tasks.Update(taskMap);
            await _ToDoListContext.SaveChangesAsync();
        }



        public async Task Delete(int id)
        {
            var TaskToDelete = await _ToDoListContext.Tasks.FindAsync(id);
            _ToDoListContext.Tasks.Remove(TaskToDelete);
            await _ToDoListContext.SaveChangesAsync();
        }




    }
}
