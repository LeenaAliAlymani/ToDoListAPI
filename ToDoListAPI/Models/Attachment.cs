using System;
using System.Collections.Generic;

namespace ToDoListAPI.Models;

public partial class Attachment
{
    public int AttachmentId { get; set; }

    public int? TaskId { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public DateTime? UploadDate { get; set; }

    public virtual TaskModel? Task { get; set; }
}
