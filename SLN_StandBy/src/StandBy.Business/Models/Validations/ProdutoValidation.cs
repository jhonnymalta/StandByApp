using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Descricao)
                    .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                    .Length(2, 100).WithMessage("O campo {PropertyName} deve conter entre {MinLength} e {MaxLength} caracters.");
            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que {ComparisonValue}");
        }
    }
}
