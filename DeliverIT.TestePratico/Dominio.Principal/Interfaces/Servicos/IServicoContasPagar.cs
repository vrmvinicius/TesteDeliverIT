using Dominio.Principal.Entidades;
using FluentValidation.Results;
using Infra.CrossCutting.DTO.ContasPagar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Principal.Interfaces.Servicos
{
    public interface IServicoContasPagar : IServicoBase<ContasPagar>
    {
        Task<ContasPagarDTO> IncluirLancamento(ContasPagarInclusaoDTO obj);
        Task<List<ContasPagarListagemDTO>> ListarContas();
    }
}
