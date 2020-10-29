using Dominio.Principal.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Principal.Validators
{
    public class ContasPagarValidator: AbstractValidator<ContasPagar>
    {
        public ContasPagarValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome da conta a pagar deve ser preenchido.");            
            RuleFor(x => x.DataVencimento).NotEmpty().WithMessage("A data de vencimento deve ser preenchida.");
            RuleFor(x => x.DataPagamento).NotEmpty().WithMessage("A data de pagamento deve ser preenchida.");                                                     
            RuleFor(x => x.ValorOriginal).GreaterThan(0).WithMessage("O valor da conta a pagar deve ser maior que 0,00.");
        }
    }
}
