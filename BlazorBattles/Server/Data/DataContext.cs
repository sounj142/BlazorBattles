using BlazorBattles.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorBattles.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }
        //public DbSet<UserUnit> UserUnits { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<UserUnit>()
        //        .HasKey(x => new { x.UnitId, x.UserId });
        //}
    }
}
