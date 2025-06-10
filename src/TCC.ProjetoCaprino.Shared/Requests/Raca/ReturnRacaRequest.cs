using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Raca;

namespace TCC.ProjetoCaprino.Shared.Requests.Raca
{
    public class ReturnRacaRequest : IRequest<Result<ReturnRacaResponse>>
    {
        public Guid Id { get; set; }
    }
}
