using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Shared.Requests.Caprino
{
    public class CreateHistoricoDoCaprinoRequest : IRequest<Result<CreateHistoricoDoCaprinoResponse>>, IValida
    {
        public required Guid CaprinoId { get; set; }
        public required decimal Peso { get; set; }
        public decimal? QuantidadeDeLeite { get; set; }
        public required Guid TipoDeAlimentoId { get; set; }
        public required decimal QuantidadeDeAlimento { get; set; }
        public required Guid? EventoId { get; set; }
        public Guid? VacinaId { get; set; }
        public string? Observacoes { get; set; }
        public required DateTime Data { get; set; }
    }
}
