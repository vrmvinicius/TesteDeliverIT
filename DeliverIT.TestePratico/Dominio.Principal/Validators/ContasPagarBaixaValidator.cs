using Dominio.Principal.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Principal.Validators
{
    public class ContasPagarBaixaValidator : AbstractValidator<ContasPagarBaixa>
    {
        public ContasPagarBaixaValidator()
        {
            RuleFor(x => x.ContasPagar)
                .NotNull().WithMessage("Uma conta a pagar válida deve estar vinculada a baixa.");

            RuleFor(x => x.ValorPago).GreaterThan(0).WithMessage("O valor pago da conta a pagar deve ser maior que 0,00.");
        }
    }
}
