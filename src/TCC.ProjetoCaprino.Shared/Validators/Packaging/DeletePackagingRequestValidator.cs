using FluentValidation;
using TCC.ProjetoCaprino.Shared.Requests.Packaging;

namespace TCC.ProjetoCaprino.Shared.Validators.Packaging
{
    public class DeletePackagingRequestValidator : AbstractValidator<DeletePackagingRequest>
    {
        public DeletePackagingRequestValidator()
        {
            RuleFor(packaging => packaging.PackagingId)
                .NotEmpty().WithMessage("O id do tipo de embalagem deve ser informado");
        }
    }
}
