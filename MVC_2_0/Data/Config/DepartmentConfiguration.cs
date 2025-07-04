using Microsoft.EntityFrameworkCore;
using MVC_2_0.Models;

namespace MVC_2_0.Data.Config
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Manager).HasMaxLength(100);

        }
    }
}
