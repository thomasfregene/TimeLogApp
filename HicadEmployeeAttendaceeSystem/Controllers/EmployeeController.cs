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
    [Route("api/[controller]")] //api/employee
    [ApiController()]
    public class EmployeeController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EmployeeController(ApiDbContext context)
        {
            _context = context;
        }

       [HttpGet]
       public async Task<IActionResult> GetEmployees()
        {
            var employee = await _context.Employees
                .Include(d=>d.Department)
                .ToListAsync();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var validEmployee = new Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Address = employee.Address,
                    PhoneNumber = employee.PhoneNumber,
                    UserName = employee.UserName,
                    DepartmentId = employee.DepartmentId,
                    CreatedOn = employee.CreatedOn = DateTime.Now
                };
                await _context.Employees.AddAsync(validEmployee);

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmployees", new { validEmployee.Id, validEmployee.CreatedOn }, employee);
            }

            return new JsonResult("Something went wrong while creating record");
        }
    }
}
