using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_2_0.Models;

namespace MVC_2_0.Data.Config
{
    public class InstructorConfiguration:IEntityTypeConfiguration<Instructor>
    {
        

        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
            builder.Property(i => i.ImageUrl).HasMaxLength(200);
            builder.Property(i => i.Salary).HasColumnType("decimal(10,2)");
            builder.Property(i => i.Address).HasMaxLength(200);

            builder.HasOne(i => i.Department)
                   .WithMany(d => d.Instructors)
                   .HasForeignKey(i => i.DeptId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(i => i.Course)
                   .WithMany(c => c.Instructors)
                   .HasForeignKey(i => i.CrsId)
                   .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
