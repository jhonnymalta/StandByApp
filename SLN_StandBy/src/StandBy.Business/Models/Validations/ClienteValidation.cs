using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(p => p.CpfCnpj)
                    .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                    .Length(11, 14).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracters.");
            RuleFor(p => p.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                    .Length(2,100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracters.");
        }
    }
}
