using MyErp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyErp.ViewModels
{
    public class LeaveAllocationViewModel
    {
        public string EmpId { get; set; }
        public Users? Users { get; set; }
        public int? Sick { get; set; }
        public int? Casual { get; set; }
        public int? Earned { get; set; }
        public int? CarryForward { get; set; }
        public int? Maternity { get; set; }
        public int? Paternity { get; set; }
        public int? Pilgrimage { get; set; }
        public int? Compensation { get; set; }
    }
}
