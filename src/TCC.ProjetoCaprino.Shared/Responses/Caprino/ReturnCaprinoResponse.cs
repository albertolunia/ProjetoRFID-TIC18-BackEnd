namespace TCC.ProjetoCaprino.Shared.Responses.Category;

public record ReturnCaprinoResponse(
    Guid Id,
    string Brinco,
    decimal PesoAtual,
    bool Sexo,
    DateTime DataNascimento,
    Guid RacaId,
    string RacaNome,
    Guid TipoDeCriacaoId,
    string TipoDeCriacaoNome,
    string? Observacoes,
    DateTime CreatedAt,
    bool IsDeleted
);
