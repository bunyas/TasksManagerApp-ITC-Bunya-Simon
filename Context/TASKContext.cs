using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp_Bunya.Models;

namespace task.context;

public partial class TASKContext : DbContext
{
    public TASKContext()
    {
    }

    public TASKContext(DbContextOptions<TASKContext> options)
        : base(options)
    {
    }

    public virtual DbSet<APriority> APriorities { get; set; }

    public virtual DbSet<AStatus> AStatuses { get; set; }

    public virtual DbSet<TaskManagerApp_Bunya.Models.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Tasks;User Id=sa;password=root85;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<APriority>(entity =>
        {
            entity.HasKey(e => e.PriorityId);

            entity.ToTable("A_Priority");

            entity.Property(e => e.PriorityId)
                .ValueGeneratedNever()
                .HasColumnName("PriorityID");
            entity.Property(e => e.Priority).HasMaxLength(20);
        });

        modelBuilder.Entity<AStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("A_Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("StatusID");
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<TaskManagerApp_Bunya.Models.Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationTimestamp).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedTimestamp).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.PriorityNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Priority)
                .HasConstraintName("FK_Task_A_Priority");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_Task_A_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
