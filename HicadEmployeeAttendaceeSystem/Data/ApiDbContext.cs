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
    }
}
