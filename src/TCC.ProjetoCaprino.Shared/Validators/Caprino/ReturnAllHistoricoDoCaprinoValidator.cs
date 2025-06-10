using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;

namespace TCC.ProjetoCaprino.Shared.Validators.Caprino
{
    public class ReturnAllHistoricoDoCaprinoValidator : AbstractValidator<ReturnAllHistoricoDoCaprinoRequest>
    {
        public ReturnAllHistoricoDoCaprinoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O brinco deve ser informado");
        }
    }
}
