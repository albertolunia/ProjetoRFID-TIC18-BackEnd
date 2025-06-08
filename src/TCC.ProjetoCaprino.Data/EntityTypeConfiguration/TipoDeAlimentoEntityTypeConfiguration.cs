using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class TipoDeAlimentoEntityTypeConfiguration : IEntityTypeConfiguration<TipoDeAlimentoEntity>
{
    public void Configure(EntityTypeBuilder<TipoDeAlimentoEntity> builder)
    {
        builder.ToTable("TipoDeAlimento");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.TipoDeAlimento).IsRequired();
    }
}