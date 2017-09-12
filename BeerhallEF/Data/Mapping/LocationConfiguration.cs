using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallEF.Data.Mapping
{
    class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");

            //Primary Key
           builder.HasKey(t => t.PostalCode);

            //Properties

            //Properties
            builder.Property(t => t.PostalCode)
                .HasMaxLength(5);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

     
    }
}