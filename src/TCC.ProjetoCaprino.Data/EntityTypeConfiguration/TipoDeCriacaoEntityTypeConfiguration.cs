using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class TipoDeCriacaoEntityTypeConfiguration : IEntityTypeConfiguration<TipoDeCriacaoEntity>
{
    public void Configure(EntityTypeBuilder<TipoDeCriacaoEntity> builder)
    {
        builder.ToTable("TipoDeCriacao");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.TipoDeCriacao)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
    }
}
