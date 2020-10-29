using Infra.CrossCutting.DTO.ContasPagar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Principal.Interfaces
{
    public interface IAppContasPagar
    {
        Task<ContasPagarDTO> GetByIdAsync(int id);
        Task<ContasPagarDTO> IncluirContaPagar(ContasPagarInclusaoDTO contasPagarInclusaoDTO);
        Task<List<ContasPagarListagemDTO>> ListarContas();
    }
}
