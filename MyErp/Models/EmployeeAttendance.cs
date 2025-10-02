using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.Models
{
    public class EmployeeAttendance : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Users Users { get; set; }
        public string CustomEmployeeId {  get; set; }
        public DateTime? InTime {  get; set; }
        public DateTime? OutTime {  get; set; }
    }
}
