using HicadEmployeeAttendaceeSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.Controllers
{
    [Route("api/[controller]")] // api/department
    [ApiController()]
    public class DepartmentController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DepartmentController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var department = await _context.Departments.ToListAsync();

            return Ok(department);
        }
    }
}
