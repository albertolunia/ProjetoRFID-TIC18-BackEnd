using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Vacina;

namespace TCC.ProjetoCaprino.Shared.Requests.Vacina;


public class ReturnVacinaRequest : IRequest<Result<ReturnVacinaResponse>>, IValida
{
    public Guid Id { get; set; }
}
