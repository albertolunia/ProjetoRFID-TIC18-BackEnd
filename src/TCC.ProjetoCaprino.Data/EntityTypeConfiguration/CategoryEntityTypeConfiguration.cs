using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<CaprinoEntity>
{
    public void Configure(EntityTypeBuilder<CaprinoEntity> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Origin).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Color).IsRequired().HasMaxLength(100);

        builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);

    }
}
