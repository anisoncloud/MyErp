using Microsoft.AspNetCore.Identity;

namespace MyErp.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
        public UserDetails UserDetails { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
