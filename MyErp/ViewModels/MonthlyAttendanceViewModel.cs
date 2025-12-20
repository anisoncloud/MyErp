namespace MyErp.ViewModels
{
    public class MonthlyAttendanceViewModel
    {
        public string EmployeeId {  get; set; }
        public string CustomEmployeeId {  get; set; }
        public string EmployeeName {  get; set; }
        public int PresentDays {  get; set; }
        public int WorkingDaysInAMonth {  get; set; }
    }
}
