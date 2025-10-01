namespace MyErp.Models
{
    public class EmployeeAttendance : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string CustomEmployeeId {  get; set; }
        public DateTime InTime {  get; set; }
        public DateTime OutTime {  get; set; }
    }
}
