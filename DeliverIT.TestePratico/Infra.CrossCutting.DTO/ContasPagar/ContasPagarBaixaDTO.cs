using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CrossCutting.DTO.ContasPagar
{
    public class ContasPagarBaixaDTO
    {
        public int Id { get; set; }
        
        public int IdContasPagar { get; set; }
        public string NomeContasPagar { get; set; }
                
        public int QtdeDiasAtraso { get; set; }
        public decimal PercentualJurosDia { get; set; }
        public decimal PercentualMulta { get; set; }
        public decimal ValorPago { get; set; }

        public ContasPagarBaixaDTO()
        {
        }
    }
}
