using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.CrossCutting.DTO.ContasPagar
{
    public class ContasPagarDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorOriginal { get; set; }
        public ContasPagarBaixaDTO ContasPagarBaixa { get; set; }

        public ContasPagarDTO()
        {
            ContasPagarBaixa = new ContasPagarBaixaDTO();
        }
    }
}
