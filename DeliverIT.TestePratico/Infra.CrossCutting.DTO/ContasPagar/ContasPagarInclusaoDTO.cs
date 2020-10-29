using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CrossCutting.DTO.ContasPagar
{
    public class ContasPagarInclusaoDTO
    {
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public ContasPagarInclusaoDTO()
        {

        }
    }
}
