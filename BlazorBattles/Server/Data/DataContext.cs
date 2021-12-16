using BlazorBattles.Server.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorBattles.Server.Data
{
    public class DataContext : ApiAuthorizationDbContext<AppUser>
    {
        public DataContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Unit> Units { get; set; }

        //public DbSet<UserUnit> UserUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserUnit>()
            //    .HasKey(x => new { x.UnitId, x.UserId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
