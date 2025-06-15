namespace TCC.ProjetoCaprino.Domain.Entities;

public class CaprinoEntity
{
    public Guid Id { get; set; }
    public string Brinco { get; set; }
    public decimal PesoAtual { get; set; }
    public bool Sexo { get; set; }
    public DateTime DataNascimento { get; set; }
    public RacaEntity Raca { get; set; }
    public Guid RacaId { get; set; }
    public TipoDeCriacaoEntity TipoDeCricao { get; set; }
    public Guid TipoDeCricaoId { get; set; }
    public string? Observacoes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<HistoricoDoCaprinoEntity> Historico { get; set; } = new List<HistoricoDoCaprinoEntity>();
    public bool IsDeleted { get; set; } = false;

    internal void Delete()
    {
        IsDeleted = true;
    }
}

