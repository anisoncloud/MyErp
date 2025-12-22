namespace MyErp.ViewModels
{
    public class DailyAttendanceViewModel
    {
        public DateTime Date { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime {  get; set; }
        public string Status {  get; set; }
    }
}
