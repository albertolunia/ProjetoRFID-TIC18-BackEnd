using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TCC.ProjetoCaprino.Data.EntityTypeConfiguration
{
    public class PackagingEntityTypeConfiguration : IEntityTypeConfiguration<PackagingEntity>
    {
        public void Configure(EntityTypeBuilder<PackagingEntity> builder)
        {
            builder.ToTable("Packaging");
            builder.HasKey(packaging => packaging.Id);
            builder.Property(packaging => packaging.Name).IsRequired().HasMaxLength(100);
            
            builder.Property(packaging => packaging.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
