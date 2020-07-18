using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagementSystem.Models
{
    public partial class Management_SystemContext : DbContext
    {
        public Management_SystemContext()
        {
        }

        public Management_SystemContext(DbContextOptions<Management_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<AttendenceDetails> AttendenceDetails { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-NCGTQKP;Database=Management_System;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendenceDetails>(entity =>
            {
                entity.HasKey(e => e.Attendence_Detail_ID);
                entity.Property(e => e.Attendence_Detail_ID).HasColumnName("Attendence_Detail_ID");
                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.Attendence).HasColumnName("Attendence");
                entity.Property(e => e.Date).HasColumnName("Date");
            });
       
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.DepartmentName).HasColumnName("Department_Name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EId);

                entity.Property(e => e.EId).HasColumnName("E_ID");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.EAddress)
                    .IsRequired()
                    .HasColumnName("E_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.ECity)
                    .IsRequired()
                    .HasColumnName("E_City")
                    .HasMaxLength(50);

                entity.Property(e => e.EEmail)
                    .IsRequired()
                    .HasColumnName("E_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.EFirstName)
                    .IsRequired()
                    .HasColumnName("E_FIrstName")
                    .HasMaxLength(50);

                entity.Property(e => e.EGender)
                    .IsRequired()
                    .HasColumnName("E_Gender")
                    .HasMaxLength(50);

                entity.Property(e => e.ELastName)
                    .IsRequired()
                    .HasColumnName("E_LastName")
                    .HasMaxLength(50);

                entity.Property(e => e.EPhoneNumber)
                    .IsRequired()
                    .HasColumnName("E_PhoneNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employee_Department");
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("UserPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("Role")
                    .HasMaxLength(50);

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
