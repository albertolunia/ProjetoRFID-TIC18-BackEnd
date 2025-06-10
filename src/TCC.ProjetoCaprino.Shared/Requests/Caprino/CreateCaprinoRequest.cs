using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Shared.Requests.Caprino;

public class CreateCaprinoRequest : IRequest<Result<CreateCaprinoResponse>>, IValida
{
    public required string Brinco { get; set; }
    public required decimal PesoAtual { get; set; }
    public required bool Sexo { get; set; }
    public required DateTime DataNascimento { get; set; }
    public required Guid RacaId { get; set; }
    public required Guid TipoDeCriacaoId { get; set; }
    public string? Observacoes { get; set; }
}
