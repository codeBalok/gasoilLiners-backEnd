using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GasOilLiners.API.Models
{
    public partial class GasOilLinersContext : DbContext
    {
        public GasOilLinersContext()
        {
        }

        public GasOilLinersContext(DbContextOptions<GasOilLinersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
        public virtual DbSet<EmployeeAttendanceMaster> EmployeeAttendanceMaster { get; set; }
        public virtual DbSet<EmployeeCategoryMaster> EmployeeCategoryMaster { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public virtual DbSet<EmployeeSalaryAdvance> EmployeeSalaryAdvance { get; set; }
        public virtual DbSet<ProjectCategoryMaster> ProjectCategoryMaster { get; set; }
        public virtual DbSet<ProjectEmployee> ProjectEmployee { get; set; }
        public virtual DbSet<ProjectMaster> ProjectMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=GasOilLiners;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAttendance>(entity =>
            {
                entity.Property(e => e.Attendance).IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ProjectEmployee)
                    .WithMany(p => p.EmployeeAttendance)
                    .HasForeignKey(d => d.ProjectEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeAttendance_ProjectEmployee");
            });

            modelBuilder.Entity<EmployeeAttendanceMaster>(entity =>
            {
                entity.Property(e => e.Attendance).IsUnicode(false);

                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EmployeeCategoryMaster>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Primary Key of table. ");

                entity.Property(e => e.Category)
                    .IsUnicode(false)
                    .HasComment("Name of the employee category");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasComment("Description section for employee category");

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EmployeeMaster>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmployeeNumber).IsUnicode(false);

                entity.Property(e => e.Experience).IsUnicode(false);

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Position).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.EmployeeMaster)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeMaster_EmployeeCategoryMaster");
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalary)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSalary_ProjectMaster");
            });

            modelBuilder.Entity<EmployeeSalaryAdvance>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalaryAdvance)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSalaryAdvance_ProjectEmployee");
            });

            modelBuilder.Entity<ProjectCategoryMaster>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProjectEmployee>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProjectEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectEmployee_EmployeeMaster");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectEmployee)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectEmployee_ProjectMaster");
            });

            modelBuilder.Entity<ProjectMaster>(entity =>
            {
                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedIp)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0.0.0.0')");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.ModifiedIp).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.ProjectCategoryNavigation)
                    .WithMany(p => p.ProjectMaster)
                    .HasForeignKey(d => d.ProjectCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectMaster_ProjectCategoryMaster");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
