using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Shared.Requests.Caprino;

public class ReturnHistoricoDoCaprinoRequest : IRequest<Result<ReturnHistoricoDoCaprinoResponse>>, IValida
{
    public Guid Id { get; set; }
}
