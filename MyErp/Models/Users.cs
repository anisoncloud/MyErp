using Microsoft.AspNetCore.Identity;

namespace MyErp.Models
{
    public class Users : IdentityUser 
    {
        public string FullName { get; set; }
        public UserDetails? UserDetails { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? DesignationId { get; set; }
        public Designation Designation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int? EmployeeTypeId { get; set; }
        public EmployeeType? EmployeeType { get; set; }
        public string? ManagerId {  get; set; }
        public Users? Manager { get; set; }
        public LeaveAllocation? LeaveAllocation { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        public string? GanderId {get; set;}
        public Gender? Gender { get; set; }
    }
}
