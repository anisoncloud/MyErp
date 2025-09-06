namespace MyErp.Models
{
    public class LeaveEntitlement
    {
        public int ID {  get; set; }
        public int  EmployeeTypeId { get; set; }
        public EmployeeType? EmployeeType { get; set; }
        public int LeaveTypeId {  get; set; }
        public LeaveType? LeaveType { get; set; }
        public int DaysPerYer {  get; set; }
    }
}
