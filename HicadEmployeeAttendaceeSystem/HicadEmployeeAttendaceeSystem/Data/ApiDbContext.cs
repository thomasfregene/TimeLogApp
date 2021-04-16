using HicadEmployeeAttendaceeSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options)
            : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeTimeLog> EmployeeTimeLogs { get; set; }

        //composite key using fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .HasKey(e => new {e.UserName, e.Email });

            //modelBuilder.Entity<Department>()
            //    .HasKey(d=>new { d.DepartmentName});

            //modelBuilder.Entity<Department>()
            //    .Property(d => d.Id)
            //    .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Employee>()
            //    .Property(e => e.Id)
            //    .ValueGeneratedOnAdd();

            modelBuilder.Entity<Department>()
                .HasData(new { Id=1, DepartmentName = "Admin" },
                new { Id = 2, DepartmentName = "IT" },
                new { Id = 3, DepartmentName = "Office Management" });


        }

    }
}
