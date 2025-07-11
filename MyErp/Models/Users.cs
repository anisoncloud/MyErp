using Microsoft.AspNetCore.Identity;

namespace MyErp.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
        public UserDetails? UserDetails { get; set; }
    }
}
