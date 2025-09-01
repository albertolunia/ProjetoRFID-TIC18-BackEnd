using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class CaprinoEntityTypeConfiguration : IEntityTypeConfiguration<CaprinoEntity>
{
    public void Configure(EntityTypeBuilder<CaprinoEntity> builder)
    {
        builder.ToTable("Caprino");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Brinco)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(e => e.Brinco)
            .IsUnique();

        builder.Property(e => e.PesoAtual)
            .IsRequired();

        builder.Property(e => e.Sexo)
            .IsRequired();

        builder.Property(e => e.DataNascimento)
            .IsRequired();

        builder.Property(e => e.Observacoes)
            .HasMaxLength(500);

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(e => e.Raca)
            .WithMany()
            .HasForeignKey(e => e.RacaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TipoDeCricao)
            .WithMany()
            .HasForeignKey(e => e.TipoDeCricaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
