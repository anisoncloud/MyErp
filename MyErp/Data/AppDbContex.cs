using MyErp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyErp.Data
{
    public class AppDbContex : IdentityDbContext<Users>
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
    }
}
