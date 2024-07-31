using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.CustomModels;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _TasksRepository;

        public TasksController(ITasksRepository TasksRepository)
        {
            _TasksRepository = TasksRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            return await _TasksRepository.Get();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTasks(int id)
        {
            return await _TasksRepository.Get(id);
        }


        //اضافه
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask([FromBody] TasksDto e)
        {
            var newTask = await _TasksRepository.Create(e);
            return CreatedAtAction(nameof(GetTasks), new { id = e.TaskId }, newTask);
        }


        //تعديل
        [HttpPut]
        public async Task<ActionResult> PutTask([FromBody] TasksDto e)
        {
            await _TasksRepository.Update(e);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                var TaskToDelete = await _TasksRepository.Get(id);
                if (TaskToDelete == null)
                {
                    return NotFound();
                }

                await _TasksRepository.Delete(TaskToDelete.TaskId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
