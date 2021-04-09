using HicadEmployeeAttendaceeSystem.Data;
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
            var employee = await _context.Employees.ToListAsync();

            return Ok(employee);
        }
    }
}
