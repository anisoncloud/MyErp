namespace MyErp.ViewModels
{
    public class LeaveRequestViewModel
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string LeaveType {  get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int Days {  get; set; }
        public string LeaveStauts { get; set; } = "Pending";
        public string ManagerId {  get; set; }
        public string ManagerEmail {  get; set; }
        public string Comment { get; set; }
    }
}
