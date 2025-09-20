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
            var summary = LeaveRequest.Where(x => x.LeaveType == "Sick").ToList();
            int totalSick = 0;
            foreach (var item in summary)
            {
                totalSick += item.Days;
            }
            return totalSick;
        }
        public int CalculateTotalCasual()
        {
            var summary = LeaveRequest.Where(x => x.LeaveType == "Casual").ToList();
            int totalSick = 0;
            foreach (var item in summary)
            {
                totalSick += item.Days;
            }
            return totalSick;
        }
        public int CalculateTotalEarned()
        {
            var summary = LeaveRequest.Where(x => x.LeaveType == "Earned").ToList();
            int totalSick = 0;
            foreach (var item in summary)
            {
                totalSick += item.Days;
            }
            return totalSick;
        }
    }
}
