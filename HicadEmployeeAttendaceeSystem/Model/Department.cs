using System.ComponentModel.DataAnnotations;

namespace HicadEmployeeAttendaceeSystem.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
}