using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_2_0.Models;

namespace MVC_2_0.Data.Config
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.Property(t => t.ImageUrl).HasMaxLength(200);
            builder.Property(t => t.Address).HasMaxLength(200);
            builder.Property(t => t.Grade).HasMaxLength(10);

            builder.HasOne(t => t.Department)
                   .WithMany(d => d.Trainees)
                   .HasForeignKey(t => t.DeptId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
