using Dominio.Principal.Validators;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Dominio.Principal.Entidades
{
    public class ContasPagar
    {
        private ContasPagarValidator _validator;
        
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorOriginal { get; set; }
        public virtual List<ContasPagarBaixa> ContasPagarBaixa { get; set; }

        public ContasPagar()
        {            
            ContasPagarBaixa = new List<ContasPagarBaixa>();
        }

        public virtual void AdicionarBaixa()
        {
            var validationResult = this.Validar();
            if (!validationResult.IsValid)
                throw new ArgumentException("Um ou mais problemas ocorreram na tentativa de lançar a baixa. Verifique. \n" +
                                             string.Join("\n", validationResult.Errors.ToList()));

            ContasPagarBaixa cpb = new ContasPagarBaixa(this);

            validationResult = cpb.Validar();
            if (!validationResult.IsValid)
                throw new ArgumentException("Um ou mais problemas ocorreram na tentativa de lançar a baixa. Verifique. \n" +
                                             string.Join("\n", validationResult.Errors.ToList()));
                    
            ContasPagarBaixa.Add(cpb);                  
        }

        public virtual void RemoverBaixa(ContasPagarBaixa contasPagarBaixa)
        {
            ContasPagarBaixa.Remove(contasPagarBaixa);
        }

        public ValidationResult Validar()
        {
            if (_validator == null)
                _validator = new ContasPagarValidator();

            return _validator.Validate(this);
        }
    }
}
