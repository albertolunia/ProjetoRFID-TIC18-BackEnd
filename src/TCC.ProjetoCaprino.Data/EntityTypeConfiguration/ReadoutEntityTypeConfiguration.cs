using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration;

public class ReadoutEntityTypeConfiguration : IEntityTypeConfiguration<ReadoutEntity>
{
    public void Configure(EntityTypeBuilder<ReadoutEntity> builder)
    {
        builder.ToTable("Readout");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.ReadoutDate).IsRequired();
        builder.Property(e => e.Tags).IsRequired();

        //builder.HasOne(e => e.Product).WithMany();
    }
}