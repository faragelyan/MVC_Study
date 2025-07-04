using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_2_0.Models;

namespace MVC_2_0.Data.Config
{
    public class CrsResultConfiguration : IEntityTypeConfiguration<CrsResult>
    {
        public void Configure(EntityTypeBuilder<CrsResult> builder)
        {
            builder.HasKey(cr => new { cr.CrsId, cr.TraineeId });

            builder.Property(cr => cr.Degree).IsRequired();

            builder.HasOne(cr => cr.Course)
                   .WithMany(c => c.CrsResult)
                   .HasForeignKey(cr => cr.CrsId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cr => cr.Trainee)
                   .WithMany(t => t.CrsResult)
                   .HasForeignKey(cr => cr.TraineeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
