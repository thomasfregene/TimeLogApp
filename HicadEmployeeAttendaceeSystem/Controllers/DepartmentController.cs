using HicadEmployeeAttendaceeSystem.Data;
using HicadEmployeeAttendaceeSystem.Model;
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

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department dept)
        {
            if (ModelState.IsValid)
            {
                await _context.Departments.AddAsync(dept);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDepartments", new { dept.Id, dept.DepartmentName }, dept);
            }

            return new JsonResult("Something went wrong while creating record please try again");
        }
    }
}
