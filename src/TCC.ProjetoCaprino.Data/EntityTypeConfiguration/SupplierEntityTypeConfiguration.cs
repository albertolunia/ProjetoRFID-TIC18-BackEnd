using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<SupplierEntity>
{
    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.ToTable("Supplier");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
        builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(11);

        builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
    }
}
