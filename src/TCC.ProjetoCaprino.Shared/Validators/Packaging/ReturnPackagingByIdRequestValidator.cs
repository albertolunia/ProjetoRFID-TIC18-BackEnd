using FluentValidation;
using TCC.ProjetoCaprino.Shared.Requests.Packaging;

namespace TCC.ProjetoCaprino.Shared.Validators.Packaging
{
    public class ReturnPackagingByIdRequestValidator : AbstractValidator<ReturnPackagingByIdRequest>
    {
        public ReturnPackagingByIdRequestValidator()
        {
            RuleFor(packaging => packaging.PackagingId)
                .NotEmpty().WithMessage("O id do tipo de embalagem deve ser informado");
        }
    }
}
