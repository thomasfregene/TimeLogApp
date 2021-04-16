using HicadEmployeeAttendaceeSystem.Data;
using HicadEmployeeAttendaceeSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.Controllers
{
    [Route("api/[controller]")] // api/EmployeeTimeLog
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

        [HttpPost]
        public async Task<IActionResult> TimeInTimeOutLog(string user)
        {
            var employeeInDB =  _context.EmployeeTimeLogs.Where(e => e.Employee.UserName == user).FirstOrDefault();

            if (employeeInDB!=null)
            {
                var timeIn = new EmployeeTimeLog
                {
                    TimeIn = employeeInDB.TimeIn = DateTime.Now,
                    IsLogin = true
                };

                await _context.EmployeeTimeLogs.AddAsync(timeIn);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmployeeTimeLog", new { timeIn.TimeIn, timeIn.Employee.UserName }, timeIn);
            }
            return Ok();
            //if(employeeInDB.IsLogin==true&&employeeInDB.TimeIn==)
            //{
            //    var timeOut = new EmployeeTimeLog
            //    {
            //        TimeOut = employeeInDB.TimeOut,
            //        IsLogin = false
            //    };
            //    return CreatedAtAction("GetEmployeeTimeLog", new { timeOut.TimeOut, timeOut.Employee.UserName }, timeOut);
            //}
            
            
                
            

        }
    }
}
