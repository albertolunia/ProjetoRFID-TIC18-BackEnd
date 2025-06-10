using FluentValidation;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;

namespace TCC.ProjetoCaprino.Shared.Validators.Caprino;

public class CreateCaprinoRequestValidator : AbstractValidator<CreateCaprinoRequest>
{
    public CreateCaprinoRequestValidator()
    {
        RuleFor(x => x.Brinco)
            .NotEmpty().WithMessage("O brinco deve ser informado")
            .MinimumLength(3).WithMessage("O brinco deve ter no mínimo 3 caracteres")
            .MaximumLength(50).WithMessage("O brinco deve ter no máximo 50 caracteres");

        RuleFor(x => x.PesoAtual)
            .GreaterThan(0).WithMessage("O peso atual deve ser maior que zero");

        RuleFor(x => x.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento deve ser informada")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de nascimento não pode ser no futuro");

        RuleFor(x => x.RacaId)
            .NotEmpty().WithMessage("A raça deve ser informada");

        RuleFor(x => x.TipoDeCriacaoId)
            .NotEmpty().WithMessage("O tipo de criação deve ser informado");

        RuleFor(x => x.Observacoes)
            .MaximumLength(500).WithMessage("As observações devem ter no máximo 500 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Observacoes));
    }
}
