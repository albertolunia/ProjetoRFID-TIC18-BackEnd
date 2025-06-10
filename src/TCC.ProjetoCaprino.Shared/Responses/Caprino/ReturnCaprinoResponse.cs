namespace TCC.ProjetoCaprino.Shared.Responses.Caprino;

public record ReturnCaprinoResponse(
    Guid Id,
    string Brinco,
    decimal PesoAtual,
    bool Sexo,
    DateTime DataNascimento,
    Guid RacaId,
    Guid TipoDeCriacaoId,
    string? Observacoes,
    DateTime CreatedAt,
    bool IsDeleted
);
