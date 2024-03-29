﻿using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallEF.Data.Mapping
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            //Properties
            builder.Property(t => t.Title).HasMaxLength(100).IsRequired();

            //Inheritance : TPH, and renaming the discriminator
            builder.HasDiscriminator<string>("Type")
                .HasValue<OnlineCourse>("Online")
               .HasValue<OnsiteCourse>("Onsite");
        }

     
    }
}