using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.CustomModels
{
    public class TasksDto
    {
        [Key]
        public int TaskId { get; set; }

        //public int? UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Priority { get; set; } = null!;

        public string Status { get; set; } = null!;


    }
}
