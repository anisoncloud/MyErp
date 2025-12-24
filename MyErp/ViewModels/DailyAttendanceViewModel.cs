namespace MyErp.ViewModels
{
    public class DailyAttendanceViewModel
    {
        public DateTime Date { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime {  get; set; }
        public string Status {  get; set; }
    }
}
