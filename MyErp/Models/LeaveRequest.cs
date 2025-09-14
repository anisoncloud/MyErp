using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace MyErp.Models
{
    public class LeaveRequest: BaseEntity
    {
        public int ID   { get; set; }
        public string EmpId { get; set; }
        [ForeignKey("EmpId")]
        public Users? Users { get; set; }
        public int LeaveType {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Days {  get; set; }
        public string Stauts { get; set; } = "Pending";
        public string ManagerId {  get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? DecidedDate { get; set; }
        public string? Comment {  get; set; }


    }
}
