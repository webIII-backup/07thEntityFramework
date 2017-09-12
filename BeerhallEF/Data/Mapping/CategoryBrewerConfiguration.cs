using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallEF.Data.Mapping
{
    class  CategoryBrewerConfiguration : IEntityTypeConfiguration<CategoryBrewer>
    {
        public void Configure(EntityTypeBuilder<CategoryBrewer> builder)
        {
            builder.ToTable("CategoryBrewer");

            //Primary Key
            builder.HasKey(t => new { t.CategoryId, t.BrewerId });

            //Relations
            builder.HasOne(t => t.Category)
                .WithMany(t => t.CategoryBrewers)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Brewer)
                .WithMany()
                .HasForeignKey(pt => pt.BrewerId)
                 .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}