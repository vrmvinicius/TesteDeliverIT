using Aplicacao.Principal.Interfaces;
using Infra.CrossCutting.DTO.ContasPagar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuicao.WebAPI.Controllers
{
    [Route("contaspagar")]
    [ApiController]
    public class ContasPagarController : ControllerBase
    {
        private readonly IAppContasPagar _servicoApp;
        
        public ContasPagarController(IAppContasPagar servicoApp)
        {
            _servicoApp = servicoApp;            
        }
                
        [HttpPost]
        public async Task<ActionResult> AdicionarDesenvolvedor([FromBody] ContasPagarInclusaoDTO contaPagarInclusaoDto)
        {
            try
            {
                var resultado = await _servicoApp.IncluirContaPagar(contaPagarInclusaoDto);
                return CreatedAtRoute("GetContaPagar", new { id = resultado.Id }, resultado);
            }
            catch(ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ContasPagarListagemDTO>>> GetTodos()
        {
            try
            {
                return await _servicoApp.ListarContas();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpGet("{id}", Name = "GetContaPagar")]
        public async Task<ActionResult<ContasPagarDTO>> Get(int id)
        {
            try
            {
                return await _servicoApp.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }
    }
}
