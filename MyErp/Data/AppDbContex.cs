using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyErp.Models;
using System.Reflection.Emit;

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
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategoryPost> PostCategoryPosts { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<PeopleProject> PeopleProjects { get; set; }
        public DbSet<CrmCompany> CrmCompanies { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // this is required
            builder.Entity<ProductMainCategory>()
                .HasKey(c => new { c.ProductId, c.CategoryId }); // Defines the key of this table
            builder.Entity<ProductMainCategory>()
                .HasOne(pc => pc.Product) //ProductMainCategory Table has one product. A single row in ProductMainCategory points to one Product
                .WithMany(pc => pc.ProductMainCategories) // A product can be relate to many ProductMainCategory entries. Many row in join table. So One Product-> Many ProductMainCategory Rows. 
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductMainCategory>()
                .HasOne(pc => pc.MainCategory) // ProductMainCategory has one MainCategory. A single row in ProductMainCategory Points to one MainCategory
                .WithMany(pc => pc.ProductMainCategories) // A MainCategory can be relate to many ProductMainCategory entries. Many row in join table. So One MainCategory-> Many ProductMainCategory Rows. Same as, One Product-> Many ProductMainCategory Rows.
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            //Post and Post Category Relation
            builder.Entity<PostCategoryPost>()
                .HasKey(x => new { x.CategoryId, x.PostId });
            builder.Entity<PostCategoryPost>()
                .HasOne(m => m.Post)
                .WithMany(m => m.PostCategoryPosts)
                .HasForeignKey(m=>m.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PostCategoryPost>()
                .HasOne(p => p.PostCategory)
                .WithMany(p => p.PostCategoryPosts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            //People and Project Relation
            builder.Entity<PeopleProject>()
                .HasKey(x=>new {x.PeopleId, x.ProjectId});
            builder.Entity<PeopleProject>()
                .HasOne(p => p.People)
                .WithMany(p=>p.PeopleProjects)
                .HasForeignKey(p=>p.PeopleId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PeopleProject>()
                .HasOne(p => p.Project)
                .WithMany(p=>p.PeopleProjects)
                .HasForeignKey(p=>p.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
