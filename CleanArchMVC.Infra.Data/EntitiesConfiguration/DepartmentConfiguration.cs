using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Infra.Data.EntitiesConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.HasOne(r => r.People).WithMany(r => r.Departments).HasForeignKey(f => f.PeopleId);
            builder.Property(p => p.Created).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Updated).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.Now);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}