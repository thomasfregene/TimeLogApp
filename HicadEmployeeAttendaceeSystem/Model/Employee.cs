using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        //unique key
        public string Email { get; set; }
        public string Address { get; set; }
        // unique key constraint
        public string UserName { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
