using System.Diagnostics.CodeAnalysis;
using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Domain;

namespace TCC.ProjetoCaprino.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<CaprinoEntity> Category { get; set; } = default!;
    public DbSet<TipoDeCriacaoEntity> Product { get; set; } = default!;
    public DbSet<VacinaEntity> Supplier { get; set; } = default!;
    public DbSet<EventoEntity> RfidTag { get; set; } = default!;
    public DbSet<TipoDeAlimentoEntity> Readout { get; set; } = default!;
    public DbSet<RacaEntity> Packaging { get; set; } = default!;
    public DbSet<HistoricoDoCaprinoEntity> HistoricoDoCaprino { get; set; } = default!;

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
