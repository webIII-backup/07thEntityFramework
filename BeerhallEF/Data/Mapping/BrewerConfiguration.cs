using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallEF.Data.Mapping
{
    class BrewerConfiguration : IEntityTypeConfiguration<Brewer>
    {
        public void Configure(EntityTypeBuilder<Brewer> builder)
        {
            builder.ToTable("Brewer");

            //Mappen primary key
            builder.HasKey(t => t.BrewerId);

            //properties
            builder.Property(t => t.Name)
                .HasColumnName("BrewerName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.ContactEmail)
                .HasMaxLength(100);

            builder.Property(t => t.Street)
                .HasMaxLength(100);

            builder.Property(t => t.BrewerId)
                .ValueGeneratedOnAdd();

            //Mapping Associations
            builder.HasMany(t => t.Beers)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Location)
              .WithMany()
             .IsRequired(false)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}