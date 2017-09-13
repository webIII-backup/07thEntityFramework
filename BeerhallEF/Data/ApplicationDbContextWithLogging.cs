using BeerhallEF.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BeerhallEF.Data
{
    public class ApplicationDbContextWithLogging : ApplicationDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring =
                             @"Server=.\SQLEXPRESS;Database=Beerhall;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);

            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new MyQueryLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
