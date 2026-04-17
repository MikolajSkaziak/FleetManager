using Microsoft.EntityFrameworkCore;

namespace FleetManager.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }
        public DbSet<Model.Driver> Drivers { get; set; }
        public DbSet<Model.Vehicle> Vehicles { get; set; }
        public DbSet<Model.Trip> Trips { get; set; }
    }
}
