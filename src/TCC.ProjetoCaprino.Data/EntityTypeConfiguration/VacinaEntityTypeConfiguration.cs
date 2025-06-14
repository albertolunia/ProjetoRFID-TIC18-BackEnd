using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class VacinaEntityTypeConfiguration : IEntityTypeConfiguration<VacinaEntity>
{
    public void Configure(EntityTypeBuilder<VacinaEntity> builder)
    {
        builder.ToTable("Vacina");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.TipoDeVacina).IsRequired().HasMaxLength(100);
    }
}
