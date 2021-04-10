using HicadEmployeeAttendaceeSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.Controllers
{
    [Route("api/[controller]")] // api/employeetimelog
    [ApiController()]
    public class EmployeeTimeLogController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EmployeeTimeLogController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeTimeLog()
        {
            var timeLog = await _context.EmployeeTimeLogs.ToListAsync();

            return Ok(timeLog);
        }
    }
}
