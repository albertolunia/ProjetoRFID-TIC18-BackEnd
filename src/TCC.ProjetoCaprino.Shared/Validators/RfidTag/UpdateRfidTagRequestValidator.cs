using FluentValidation;
using TCC.ProjetoCaprino.Shared.Requests.RfidTag;

namespace TCC.ProjetoCaprino.Shared.Validators.RfidTag;

public class UpdateRfidTagRequestValidator : AbstractValidator<UpdateRfidTagRequest>
{
    public UpdateRfidTagRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.RfidTag)
            .NotEmpty()
            .WithMessage("RfidTag is required");
    }
}
