using BlazorBattles.Server.Entities;
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
                using var dbContext = scope.ServiceProvider.GetService<DataContext>();

                // run migrations
                await dbContext.Database.MigrateAsync();


                // seed data
                await SeedUnits(dbContext);
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
    }
}
