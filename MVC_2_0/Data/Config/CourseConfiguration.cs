using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_2_0.Models;

namespace MVC_2_0.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Degree).IsRequired();
            builder.Property(c => c.MinDegree).IsRequired();

            builder.HasOne(c => c.Department)
                   .WithMany(d => d.Courses)
                   .HasForeignKey(c => c.DeptId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
