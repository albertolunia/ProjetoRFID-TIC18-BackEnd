namespace TCC.ProjetoCaprino.Domain.Entities;

public class HistoricoDoCaprinoEntity
{
    public Guid Id { get; set; }
    public CaprinoEntity Caprino { get; set; }
    public Guid CaprinoId { get; set; }
    public decimal Peso { get; set; }
    public decimal QuantidadeDeLeite { get; set; }
    public TipoDeAlimentoEntity TipoDeAlimento { get; set; }
    public Guid TipoDeAlimentoId { get; set; }
    public decimal QuantidadeDeAlimento { get; set; }
    public EventoEntity? Evento { get; set; }
    public Guid EventoId { get; set; }
    public VacinaEntity? Vacina { get; set; }
    public Guid? VacinaId { get; set; }
    public string? Observacoes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
