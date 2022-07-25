using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagment.Web.Data
{
    public class LeaveAllocation:BaseEntity
    {
        public string NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveTypes { get; set; }
        public int LeaveTypeId { get; set; }
        public int EmployeeId { get; set; }
      
    }
}
