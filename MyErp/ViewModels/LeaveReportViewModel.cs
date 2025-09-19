using MyErp.Models;

namespace MyErp.ViewModels
{
    public class LeaveReportViewModel
    {
        public Users Users { get; set; }
        public LeaveAllocation LeaveAllocation { get; set; }
        public List<LeaveRequest> LeaveRequest { get; set; }

        public int CalculateTotalSick()
        {
            int totalSick = 0;
            foreach (var item in LeaveRequest)
            {
                totalSick += item.Days; 
            }
            return totalSick;
        }
    }
}
