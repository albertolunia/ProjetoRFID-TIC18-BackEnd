using System.Diagnostics.CodeAnalysis;
using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Domain;

namespace TCC.ProjetoCaprino.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<CaprinoEntity> Category { get; set; } = default!;
    public DbSet<ProductEntity> Product { get; set; } = default!;
    public DbSet<SupplierEntity> Supplier { get; set; } = default!;
    public DbSet<RfidTagEntity> RfidTag { get; set; } = default!;
    public DbSet<ReadoutEntity> Readout { get; set; } = default!;
    public DbSet<PackagingEntity> Packaging { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
