using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadEmployeeAttendaceeSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        //unique key
        public string Email { get; set; }
        public string Address { get; set; }
        // unique key constraint
        [StringLength(255)]
        public string UserName { get; set; }
        public Department Department { get; set; }
        public string DepartmentId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
