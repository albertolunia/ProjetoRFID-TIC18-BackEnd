namespace TCC.ProjetoCaprino.Domain.Entities;

public class TipoDeCriacaoEntity
{
    public Guid Id { get; set; }
    
    public string TipoDeCriacao { get; set; }

    public bool IsDeleted { get; set; } = false;

    internal void Update(string tipoDeCriacao)
    {
        TipoDeCriacao = tipoDeCriacao;
    }

    internal void Delete()
    {
        IsDeleted = true;
    }
}

