using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.Model
{
    public class EmployeeTimeLog
    {
        public int Id { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public bool? IsLogin { get; set; }
    }
}
