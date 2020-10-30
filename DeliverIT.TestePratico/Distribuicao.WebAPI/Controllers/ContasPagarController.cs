using Aplicacao.Principal.Interfaces;
using Infra.CrossCutting.DTO.ContasPagar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuicao.WebAPI.Controllers
{
    [Route("api/contaspagar")]
    [ApiController]
    public class ContasPagarController : ControllerBase
    {
        private readonly IAppContasPagar _servicoApp;
        private readonly ILogger<ContasPagarController> _logger;

        public ContasPagarController(IAppContasPagar servicoApp, ILogger<ContasPagarController> logger)
        {
            _servicoApp = servicoApp;
            _logger = logger;
        }
                
        [HttpPost]
        public async Task<ActionResult> IncluirContaPagar([FromBody] List<ContasPagarInclusaoDTO> contasPagarInclusaoDto)
        {
            try
            {
                var rotas = new List<CreatedAtRouteResult>();
                foreach(var conta in contasPagarInclusaoDto)
                {
                    var resultado = await _servicoApp.IncluirContaPagar(conta);
                    rotas.Add(CreatedAtRoute("GetContaPagar", new { id = resultado.Id }, resultado));
                }
                return Ok(rotas);
            }
            catch(ArgumentException ex)
            {
                _logger.LogWarning(ex.ToString());
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, $"Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ContasPagarListagemDTO>>> GetTodos()
        {
            try
            {
                var contas = await _servicoApp.ListarContas();
                return Ok(contas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, $"Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpGet("{id}", Name = "GetContaPagar")]
        public async Task<ActionResult<ContasPagarDTO>> Get(int id)
        {
            try
            {
                var conta = await _servicoApp.GetByIdAsync(id);
                return Ok(conta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, $"Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }
    }
}
