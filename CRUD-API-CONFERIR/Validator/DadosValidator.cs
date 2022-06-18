using CRUD_API_CONFERIR.Model;
using FluentValidation;

namespace CRUD_API_CONFERIR.Validator
{
    public class DadosValidator : AbstractValidator<Dados>
    {
        public DadosValidator()
        {
            RuleFor(x => x.Cpf).NotEmpty().NotNull()
                .WithMessage("O Cpf está vazio ou incomepleto")
             .MaximumLength(11)
                .WithMessage("Digite um cpf com 11 caractéres")
             .Matches("[0-9]{11}")
                .WithMessage("O cpf não pode ter caractéres especiais");

            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("O nome está vazio ou nulo.")
            .MinimumLength(2)
                .WithMessage("O nome deve ter mais de 2 caracteres")
            .Must(NomeValido)
                .WithMessage("O nome não é valido");

            RuleFor(x => x.Email).NotEmpty().NotNull()
                .WithMessage("O email ele está vazio ou nulo.")
            .EmailAddress()
                .WithMessage("O email não é valido");
            
            RuleFor(x => x.Telefone).NotEmpty().NotNull()
                .WithMessage("O número telefonico não pode estar vazio");
        }

        protected bool NomeValido(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
