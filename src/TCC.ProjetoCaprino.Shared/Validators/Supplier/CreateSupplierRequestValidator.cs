﻿using FluentValidation;
using TCC.ProjetoCaprino.Shared.Requests.Supplier;

namespace TCC.ProjetoCaprino.Shared.Validators.Supplier;

public class CreateSupplierRequestValidator : AbstractValidator<CreateSupplierRequest>
{
    public CreateSupplierRequestValidator()
    {
        RuleFor(Supplier => Supplier.Name)
            .NotEmpty().WithMessage("O nome do fornecedor deve ser informado")
            .MinimumLength(3).WithMessage("Nome do fornecedor deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Nome do fornecedor deve ter no máximo 100 caracteres");

        RuleFor(Supplier => Supplier.Description)
            .NotEmpty().WithMessage("A descricao do fornecedor deve ser informado")
            .MinimumLength(3).WithMessage("Descricao do fornecedor deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Descricao do fornecedor deve ter no máximo 100 caracteres");

        RuleFor(Supplier => Supplier.PhoneNumber)
            .NotEmpty().WithMessage("O número de contato do fornecedor deve ser informado")
            .Matches("^[0-9]{11}$").WithMessage("O número de contato do fornecedor deve conter 11 digitos.");
    }
}
