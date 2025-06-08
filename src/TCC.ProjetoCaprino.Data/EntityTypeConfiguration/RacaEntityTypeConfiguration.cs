using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration
{
    public class RacaEntityTypeConfiguration : IEntityTypeConfiguration<RacaEntity>
    {
        public void Configure(EntityTypeBuilder<RacaEntity> builder)
        {
            builder.ToTable("Packaging");
            builder.HasKey(raca => raca.Id);
            builder.Property(raca => raca.Raca).IsRequired().HasMaxLength(100);
            builder.Property(raca => raca.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
