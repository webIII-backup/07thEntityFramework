using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallEF.Data.Mapping
{
    class OnlineCourseConfiguration : IEntityTypeConfiguration<OnlineCourse>
    {
        public void Configure(EntityTypeBuilder<OnlineCourse> builder)
        {
            //Properties
            builder.Property(t => t.Url).HasMaxLength(100);
        }     
    }
}