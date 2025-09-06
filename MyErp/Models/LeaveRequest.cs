using System.Globalization;

namespace MyErp.Models
{
    public class LeaveRequest: BaseEntity
    {
        public int ID   { get; set; }
        public int EmployeeId { get; set; }
        public Users? Users { get; set; }
        public int LeaveTypeId {  get; set; }
        public LeaveType? LeaveType { get; set; }
        public DaylightTime StartDate { get; set; }
        public DaylightTime EndDate { get; set; }
        public int Days {  get; set; }
        public LeaveRequestStatus Stauts { get; set; } = LeaveRequestStatus.Pending;
        public string ManagerId {  get; set; }
        public Users? Manager {  get; set; }
        public DateTime CreatedOn {  get; set; }
        public DateTime DecidedOn { get; set; }
        public int Year {  get; set; }
        public string Comment {  get; set; }


    }
}
