using FluentValidation;
using TCC.ProjetoCaprino.Shared.Requests.RfidTag;

namespace TCC.ProjetoCaprino.Shared.Validators.RfidTag;

public class CreateRfidTagRequestValidator : AbstractValidator<CreateRfidTagRequest>
{
    public CreateRfidTagRequestValidator()
    {
        RuleFor(x => x.RfidTag)
            .NotEmpty()
            .WithMessage("RfidTag is required");
    }
}
