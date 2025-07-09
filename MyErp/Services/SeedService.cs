using Azure.Identity;
using MyErp.Data;
using MyErp.Models;
using Microsoft.AspNetCore.Identity;

namespace MyErp.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContex>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();


            try
            {
                //ensure the database is created
                logger.LogInformation("Ensuring the database is created");
                await context.Database.EnsureCreatedAsync();

                // adding roles
                logger.LogInformation("Seeding roles");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                //add admin user
                logger.LogInformation("Seeding admin user");
                var adminEmail = "anis.bdinfo@gmail.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Users
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FullName = "Admin User",
                        EmailConfirmed = true,
                        NormalizedEmail = adminEmail.ToUpper(),
                        NormalizedUserName = adminEmail.ToUpper(),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };
                    var result = await userManager.CreateAsync(adminUser, "Admin@1234");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Admin user created successfully");
                        // Assign the admin role to the user
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync( new IdentityRole (roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");                    
                }
                else
                {
                    Console.WriteLine($"Role '{roleName}' created successfully.");
                }
            }
        }
    }
}
