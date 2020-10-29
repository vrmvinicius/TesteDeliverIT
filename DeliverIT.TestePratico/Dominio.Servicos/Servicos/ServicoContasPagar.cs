using AutoMapper;
using Dominio.Principal.Entidades;
using Dominio.Principal.Interfaces.Repositorios;
using Dominio.Principal.Interfaces.Servicos;
using Dominio.Servicos.Base;
using Infra.CrossCutting.DTO.ContasPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos.Servicos
{
    public class ServicoContasPagar : ServicoBase<ContasPagar>, IServicoContasPagar
    {
        private readonly IRepositorioContasPagar _repositorio;
        private readonly IMapper _mapper;
        
        public ServicoContasPagar(IRepositorioContasPagar repositorio, IMapper mapper) : base(repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<ContasPagarListagemDTO>> ListarContas()
        {
            try
            {
                var contas = await _repositorio.GetAllAsync();
                var contasDTO = _mapper.Map<List<ContasPagarListagemDTO>>(contas);
                return contasDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContasPagarDTO> IncluirLancamento(ContasPagarInclusaoDTO obj)
        {
            try
            {
                //Cria o objeto de domínio.
                ContasPagar contasPagar = new ContasPagar
                {
                    Nome = obj.Nome,
                    DataVencimento = obj.DataVencimento,
                    DataPagamento = obj.DataPagamento,
                    ValorOriginal = obj.ValorOriginal
                };
                //Inclui a baixa.
                contasPagar.AdicionarBaixa();
                //Valida a entidade novamente.
                var validation = contasPagar.Validar();
                if(!validation.IsValid)
                    throw new ArgumentException("Um ou mais problemas ocorreram na tentativa de lançar a baixa. Verifique. \n" +
                                                string.Join("\n", validation.Errors.ToList()));
                //Salva.
                await _repositorio.AddAsync(contasPagar);
                //Converte para DTO e retorna.
                var contasPagarDTO = _mapper.Map<ContasPagarDTO>(contasPagar);                
                //Tudo ok.
                return contasPagarDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
