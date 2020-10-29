using AutoMapper;
using Dominio.Principal.Entidades;
using Infra.CrossCutting.DTO.ContasPagar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Dados.DTO.Mapeamento.Mappers
{
    public class MapperContasPagarBaixa : Profile
    {
        public MapperContasPagarBaixa()
        {
            var entidadeParaDTO = CreateMap<ContasPagarBaixa, ContasPagarBaixaDTO>();
            entidadeParaDTO.ForMember(x => x.IdContasPagar, mc => mc.MapFrom(ent => ent.ContasPagar.Id));
            entidadeParaDTO.ForMember(x => x.NomeContasPagar, mc => mc.MapFrom(ent => ent.ContasPagar.Nome));

            var dtoParaEntidade = CreateMap<ContasPagarBaixaDTO, ContasPagarBaixa>();            
        }
    }
}
