using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models;

/// <summary>
/// بيانات المهام
/// </summary>
public partial class TaskModel
{
    [Key]
    public int TaskId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DueDate { get; set; }

    public string Priority { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual User? User { get; set; }
}
