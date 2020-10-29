using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CrossCutting.DTO.ContasPagar
{
    public class ContasPagarListagemDTO
    {
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorCorrigido { get; set; }
        public int QuantidadeDiasAtraso { get; set; }
        public DateTime DataPagamento { get; set; }
        public ContasPagarListagemDTO()
        {

        }
    }
}
