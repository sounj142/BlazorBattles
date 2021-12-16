using BlazorBattles.Server.Entities;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Data
{
    public class SeedData
    {
        public static async Task SeedAndMigrationDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            try
            {
                using var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                // run migrations
                await dbContext.Database.MigrateAsync();

                // seed data
                await SeedUnits(dbContext);
                await SeedRoles(roleManager);
                await SeedUsers(userManager);
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetService<ILogger<SeedData>>();
                logger.LogError(ex, "An error occured during seeding/migration");

                throw;
            }
        }

        public static async Task SeedUnits(DataContext dbContext)
        {
            if (!await dbContext.Units.AnyAsync())
            {
                var units = new List<Unit>
                    {
                        new Unit { Title = "Knight", Attack = 10, Defence = 10, BananaCost = 100, HitPoints = 100 },
                        new Unit { Title = "Archer", Attack = 15, Defence = 5, BananaCost = 150, HitPoints = 100 },
                        new Unit { Title = "Mage", Attack = 20, Defence = 1, BananaCost = 200, HitPoints = 100 },
                    };

                dbContext.Units.AddRange(units);

                await dbContext.SaveChangesAsync();
            }
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.Roles.AnyAsync()) return;

            var roles = new []
            {
                new IdentityRole { Name = RoleNames.Member },
                new IdentityRole { Name = RoleNames.Admin },
            };

            foreach (var role in roles) await roleManager.CreateAsync(role);
        }

        public static async Task SeedUsers(UserManager<AppUser> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            var admin = new AppUser
            {
                UserName = "Admin",
                DateOfBirth = new DateTime(1990, 1, 1),
                Bananas = 10000,
                Email = "hoang@hoang.com",
                Bio = "Bio here",
                DateCreated = DateTimeOffset.Now
            };

            await userManager.CreateAsync(admin, "Password@123");
            await userManager.AddToRolesAsync(admin, new[] { "Admin" });
        }
    }
}
