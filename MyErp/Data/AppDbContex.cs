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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMainCategory> ProductMainCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductMainCategory>()
                .HasKey(c => new { c.ProductId, c.CategoryId }); // Defines the key of this table
            builder.Entity<ProductMainCategory>()
                .HasOne(pc => pc.Product) //ProductMainCategory Table has one product. A single row in ProductMainCategory points to one Product
                .WithMany(pc => pc.ProductMainCategories) // A product can be relate to many ProductMainCategory entries. Many row in join table. So One Product-> Many ProductMainCategory Rows. 
                .HasForeignKey(pc => pc.ProductId);
            builder.Entity<ProductMainCategory>()
                .HasOne(pc=>pc.MainCategory) // ProductMainCategory has one MainCategory. A single row in ProductMainCategory Points to one MainCategory
                .WithMany(pc=>pc.ProductMainCategories) // A MainCategory can be relate to many ProductMainCategory entries. Many row in join table. So One MainCategory-> Many ProductMainCategory Rows. Same as, One Product-> Many ProductMainCategory Rows.
                .HasForeignKey(pc=>pc.CategoryId);
        }
    }
}
