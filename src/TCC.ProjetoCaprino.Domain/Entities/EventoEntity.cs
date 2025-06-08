namespace TCC.ProjetoCaprino.Domain.Entities;

public class EventoEntity
{
    public Guid Id { get; set; }
    public string TipoDeEvento { get; set; }

    internal void Update(string tipoDeEvento)
    {
        TipoDeEvento = tipoDeEvento;
    }
}
