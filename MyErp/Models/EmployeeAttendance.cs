using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime? InTime {  get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime? OutTime {  get; set; }
    }
}
