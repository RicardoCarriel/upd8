using FluentValidation;

namespace upd8.Business.Models.Validations;

public class ClienteValidation : AbstractValidator<Cliente>
{
    public ClienteValidation()
    {
        RuleFor(c => c.Cpf)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(11, 11).WithMessage("O campo {PropertyName} precisa ter entre {MaxLength} caracteres. Escreva sem pontos de dígito");
    
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.DataNascimento)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        RuleFor(c => c.Sexo)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        RuleFor(c => c.Endereco)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Cidade)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        RuleFor(c => c.Estado)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

    }
}
