using Dominio.Principal.Validators;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Dominio.Principal.Entidades
{
    public class ContasPagar
    {
        private ContasPagarValidator _validator;
        
        [Key]
        public int Id { get; set; }        
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime? DataVencimento { get; set; }
        [Required]
        public DateTime? DataPagamento { get; set; }
        [Required]
        [Column(TypeName="decimal(18,2)")]
        public decimal ValorOriginal { get; set; }        
        public virtual ContasPagarBaixa ContasPagarBaixa { get; private set; }

        public ContasPagar()
        {
            ContasPagarBaixa = new ContasPagarBaixa(this);
        }

        public ContasPagar(string nome, DateTime? dataVencimento, DateTime? dataPagamento, decimal valorOriginal)
        {
            Nome = nome;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            ValorOriginal = valorOriginal;
            ContasPagarBaixa = new ContasPagarBaixa(this);
        }

        public ValidationResult Validar()
        {
            if (_validator == null)
                _validator = new ContasPagarValidator();

            //Valida o processo da baixa (pagamento).
            if(ContasPagarBaixa != null)
            {                            
                var validatorContasPagarBaixa = ContasPagarBaixa.Validar();
                if (!validatorContasPagarBaixa.IsValid)
                    return validatorContasPagarBaixa;
            }
            //Valida a 'capa'.
            return _validator.Validate(this);
        }
    }
}
