using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class EventoEntityTypeConfiguration : IEntityTypeConfiguration<EventoEntity>
{
    public void Configure(EntityTypeBuilder<EventoEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.TipoDeEvento).IsRequired();
    }
}
