using System;
using System.Collections.Generic;

namespace ToDoListAPI.Models;

/// <summary>
/// بيانات المستخدمين
/// </summary>
public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}
