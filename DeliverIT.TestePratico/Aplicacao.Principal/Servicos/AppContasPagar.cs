using Aplicacao.Principal.Interfaces;
using AutoMapper;
using Dominio.Principal.Entidades;
using Dominio.Principal.Interfaces.Servicos;
using Infra.CrossCutting.DTO.ContasPagar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Principal.Servicos
{
    public class AppContasPagar : IAppContasPagar
    {
        private readonly IServicoContasPagar _servico;
        private readonly IMapper _mapper;

        public AppContasPagar(IServicoContasPagar servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }

        public async Task<ContasPagarDTO> GetByIdAsync(int id)
        {
            try
            {
                var contaPagar = await _servico.GetByIdAsync(id);
                var contaPagarDto = _mapper.Map<ContasPagarDTO>(contaPagar);

                return contaPagarDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContasPagarDTO> IncluirContaPagar(ContasPagarInclusaoDTO contasPagarInclusaoDTO)
        {
            try
            {
                var retornoDto = await _servico.IncluirLancamento(contasPagarInclusaoDTO);
                return retornoDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<List<ContasPagarListagemDTO>> ListarContas()
        {
            try
            {
                var retornoDto = await _servico.ListarContas();
                return retornoDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
