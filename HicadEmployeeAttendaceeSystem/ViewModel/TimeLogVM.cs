using HicadEmployeeAttendaceeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.ViewModel
{
    public class TimeLogVM
    {
        public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public IEnumerable<EmployeeTimeLog> EmployeeTimeLogs { get; set; }
        public EmployeeTimeLog EmployeeTimeLog { get; set; }

    }
}
