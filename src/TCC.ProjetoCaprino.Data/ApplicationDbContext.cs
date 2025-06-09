using System.Diagnostics.CodeAnalysis;
using TCC.ProjetoCaprino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Domain;

namespace TCC.ProjetoCaprino.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<CaprinoEntity> Caprino { get; set; } = default!;
    public DbSet<TipoDeCriacaoEntity> TipoDeCriacao { get; set; } = default!;
    public DbSet<VacinaEntity> Vacina { get; set; } = default!;
    public DbSet<EventoEntity> Evento { get; set; } = default!;
    public DbSet<TipoDeAlimentoEntity> TipoDeAlimento { get; set; } = default!;
    public DbSet<RacaEntity> Raca { get; set; } = default!;
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
