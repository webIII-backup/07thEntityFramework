using BeerhallEF.Data.Mapping;
using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerhallEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           var connectionstring =
                            @"Server=.\SQLEXPRESS;Database=Beerhall;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BrewerConfiguration());
            modelBuilder.ApplyConfiguration(new BeerConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }

        public DbSet<Brewer> Brewers { get; set; }
        //public DbSet<Beer> Beers { get; set; }  type discovery
        public DbSet<Location> Location { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
