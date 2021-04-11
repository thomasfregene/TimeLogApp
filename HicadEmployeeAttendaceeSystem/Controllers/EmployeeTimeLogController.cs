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
            var timeLog = await _context.EmployeeTimeLogs.Include(t=>t.Employee).ToListAsync();

            return Ok(timeLog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimelog(EmployeeTimeLog timeLog)
        {
            var empTimeLog = await _context.EmployeeTimeLogs.Where(t => t.EmployeeId == timeLog.EmployeeId).FirstOrDefaultAsync();
            var timeIn = new EmployeeTimeLog();

            try
            {
                if (empTimeLog.IsLogin == true)
                {
                    return Content("Sorry you're already login for today");
                }
                else if (ModelState.IsValid)
                {

                    timeIn.EmployeeId = timeLog.EmployeeId;
                    timeIn.IsLogin = true;
                    timeIn.TimeIn = DateTime.Now;
                    await _context.EmployeeTimeLogs.AddAsync(timeIn);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetEmployeeTimeLog", new { timeIn.TimeIn, timeIn.EmployeeId }, timeIn);
                }
                else
                {
                    return Content("Sorry can't signin today again");
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<IActionResult> TimeOut(EmployeeTimeLog timeLog)
        {
            var empTimeLog = await _context.EmployeeTimeLogs.FirstOrDefaultAsync(t => t.EmployeeId == timeLog.EmployeeId);

            if (timeLog.EmployeeId == 0)
                return BadRequest();

            else if (empTimeLog.IsLogin == true)
            {
                empTimeLog.TimeOut = DateTime.Now;
                empTimeLog.IsLogin = false;

                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return NoContent();

        }

       
    }
}
