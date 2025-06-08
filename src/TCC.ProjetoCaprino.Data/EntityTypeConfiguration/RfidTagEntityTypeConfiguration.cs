using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class RfidTagEntityTypeConfiguration : IEntityTypeConfiguration<RfidTagEntity>
{
    public void Configure(EntityTypeBuilder<RfidTagEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.RfidTag).IsRequired();
    }

}
