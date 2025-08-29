using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration
{
    public class HistoricoCaprinoEntityTypeConfiguration : IEntityTypeConfiguration<HistoricoDoCaprinoEntity>
    {
        public void Configure(EntityTypeBuilder<HistoricoDoCaprinoEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Peso);
            builder.Property(h => h.QuantidadeDeLeite);
            builder.Property(h => h.QuantidadeDeAlimento);

            builder.Property(h => h.Observacoes).HasMaxLength(500);

            builder.Property(h => h.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(h => h.Caprino)
                   .WithMany(c => c.Historico)
                   .HasForeignKey(h => h.CaprinoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.TipoDeAlimento)
                   .WithMany()
                   .HasForeignKey(h => h.TipoDeAlimentoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Evento)
                   .WithMany()
                   .HasForeignKey(h => h.EventoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Vacina)
                   .WithMany()
                   .HasForeignKey(h => h.VacinaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
