using Dominio.Principal.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Dominio.Principal.Entidades
{
    public class ContasPagarBaixa
    {
        private ContasPagarBaixaValidator _validator;

        [Key]
        public int Id { get; set; }                
        public int ContasPagarId { get; set; }
        public virtual ContasPagar ContasPagar { get; private set; }                
        public int QtdeDiasAtraso { get; private set; }
        [Column(TypeName="decimal(10,4)")]
        public decimal PercentualJurosDia { get; private set; }
        [Column(TypeName="decimal(10,4)")]
        public decimal PercentualMulta { get; private set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal ValorPago { get; private set; }

        public ContasPagarBaixa()
        {
        }

        public ContasPagarBaixa(ContasPagar contasPagar)
        {
            ContasPagar = contasPagar;            
            Calcular();
        }

        private void Calcular()
        {
            if (!ContasPagar.Validar().IsValid)
                return;

            //Calcula o úmero de dias de atraso (se realmente estiver atrasado).
            QtdeDiasAtraso = (ContasPagar.DataPagamento - ContasPagar.DataVencimento).Value.Days;

            //Título não foi pago em atraso.
            if (QtdeDiasAtraso <= 0)
            {
                QtdeDiasAtraso = 0;
                ValorPago = ContasPagar.ValorOriginal;
                return;
            }

            //Calcula os percentuais e o valor corrigido considerando multa e juros.            
            PercentualJurosDia = GetPercentualJurosDia(QtdeDiasAtraso);
            PercentualMulta = GetPercentualMulta(QtdeDiasAtraso);

            ValorPago = ContasPagar.ValorOriginal;
            ValorPago += CalcularValorMulta(ContasPagar.ValorOriginal, PercentualMulta);
            ValorPago += CalcularJurosDiario(ContasPagar.ValorOriginal, PercentualJurosDia, QtdeDiasAtraso);
        }

        private decimal GetPercentualMulta(int numDiasAtraso)
        {
            if (numDiasAtraso == 0)
                return 0;

            if (numDiasAtraso <= 3)
                return 2;
            
            if (numDiasAtraso > 3 && numDiasAtraso <= 5)
                return 3;

            return 5;
        }

        private decimal GetPercentualJurosDia(int numDiasAtraso)
        {
            if (numDiasAtraso == 0)
                return 0;

            if (numDiasAtraso <= 3)
                return Convert.ToDecimal(0.1);

            if (numDiasAtraso > 3 && numDiasAtraso <= 5)
                return Convert.ToDecimal(0.2);

            return Convert.ToDecimal(0.3);
        }

        private decimal CalcularValorMulta(decimal valorTitulo, decimal percentualMulta)
        {
            return valorTitulo * percentualMulta / 100;
        }

        private decimal CalcularJurosDiario(decimal valorTitulo, decimal percentualJuros, int numDiasAtraso)
        {
            return valorTitulo * (numDiasAtraso * GetPercentualJurosDia(numDiasAtraso) / 100);
        }

        public ValidationResult Validar()
        {
            if (_validator == null)
                _validator = new ContasPagarBaixaValidator();

            return _validator.Validate(this);
        }
    }
}
