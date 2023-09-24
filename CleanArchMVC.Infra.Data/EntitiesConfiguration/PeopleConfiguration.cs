using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Infra.Data.EntitiesConfiguration
{
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.KindPerson).IsRequired();
            builder.Property(p => p.Document).HasMaxLength(14).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Nickname).HasMaxLength(100);
            builder.Property(p => p.Address).HasMaxLength(500).IsRequired();
            builder.Property(p => p.ProfileType).IsRequired();
            builder.Property(p => p.Created).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Updated).ValueGeneratedOnUpdate().HasDefaultValue(DateTime.Now);
            builder.Ignore(r => r.Departments);

            builder.HasIndex(p => p.Document).IsUnique();

            builder.HasData(
                new People(1, KindPerson.PhysicalPerson, "1234567890", "Danilo Serpa Martins", "Danilo", "Rua Diamante", ProfileType.Collaborator)
            );
        }
    }
}