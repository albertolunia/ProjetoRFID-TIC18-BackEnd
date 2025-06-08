using FluentValidation;
using TCC.ProjetoCaprino.Shared.Requests.Readout;
namespace TCC.ProjetoCaprino.Shared.Validators.Readout;

public class CreateReadoutRequestValidator : AbstractValidator<CreateReadoutRequest>
{
    public CreateReadoutRequestValidator()
    {
        RuleFor(Readout => Readout.ReadoutDate)
        .NotNull().WithMessage("A data de realização da leitura deve ser informada")
        .Must(dataHora => dataHora != default).WithMessage("Data deve ser valida");

        RuleFor(Readout => Readout.Tags)
        .NotNull().WithMessage("As Tags RFID devem ser informadas");
    }
}
