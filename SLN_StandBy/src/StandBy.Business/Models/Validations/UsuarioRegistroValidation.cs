using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Models.Validations
{
    internal class UsuarioRegistroValidation : AbstractValidator<UsuarioRegistro>
    {
        public UsuarioRegistroValidation()
        {
            RuleFor(p => p.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                    .Length(11, 14).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracters.");
            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                    .Length(2, 100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracters.");
            RuleFor(p => p.ConfirmPassword)
              .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                   .Length(2, 100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracters.");
        }
    }
}
