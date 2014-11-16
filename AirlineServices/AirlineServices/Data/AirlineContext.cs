using AirlineServices.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace AirlineServices.Data
{
    public class AirlineContext : DbContext
    {
        public AirlineContext() : base("AirlineContext")
        {

        }

        public DbSet<Flight> flights { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Ticket> tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}