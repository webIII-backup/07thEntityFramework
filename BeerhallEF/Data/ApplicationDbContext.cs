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
        }

        public DbSet<Brewer> Brewers { get; set; }
    }
}
