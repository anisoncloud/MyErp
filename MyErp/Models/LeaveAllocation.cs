using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.Models
{
    public class LeaveAllocation : BaseEntity
    {
        public int ID { get; set; }
        public string? EmpId {  get; set; }
        [ForeignKey("EmpId")]
        public Users? Users { get; set; }
        public int? Sick {  get; set; }
        public int? Casual {  get; set; }
        public int? Earned {  get; set; }
        public int? CarryForward {  get; set; }
        public int? Maternity {  get; set; }
        public int? Paternity {  get; set; }
        public int? Pilgrimage {  get; set; }
        public int? Compensation {  get; set; }
    }
}
