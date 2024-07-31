using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Models;

public partial class ToDoListContext : DbContext
{
    public ToDoListContext()
    {
    }

    public ToDoListContext(DbContextOptions<ToDoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<TaskModel> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.16.160.81;Database=ToDoList;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__97E4BED7FF439D0C");

            entity.ToTable("Attachment", "ToDoList");

            entity.Property(e => e.AttachmentId)
                .ValueGeneratedNever()
                .HasColumnName("Attachment_ID");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .HasColumnName("File_Name");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("File_Path");
            entity.Property(e => e.TaskId).HasColumnName("Task_ID");
            entity.Property(e => e.UploadDate)
                .HasColumnType("datetime")
                .HasColumnName("Upload_Date");

            entity.HasOne(d => d.Task).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK__Attachmen__Task___5165187F");
        });

        modelBuilder.Entity<TaskModel>(entity =>
        {
            entity.ToTable("Task", "ToDoList", tb => tb.HasComment("بيانات المهام"));

            entity.Property(e => e.TaskId).HasColumnName("Task_ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DueDate).HasColumnName("Due_Date");
            entity.Property(e => e.Priority)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Task_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", "ToDoList", tb => tb.HasComment("بيانات المستخدمين"));

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
