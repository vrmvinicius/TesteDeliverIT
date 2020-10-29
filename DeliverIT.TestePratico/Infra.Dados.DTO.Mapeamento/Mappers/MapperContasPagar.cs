using AutoMapper;
using AutoMapper.Mappers;
using Dominio.Principal.Entidades;
using Infra.CrossCutting.DTO.ContasPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Dados.DTO.Mapeamento.Mappers
{
    public class MapperContasPagar : Profile
    {
        public MapperContasPagar()
        {
            CreateMap<ContasPagar, ContasPagarDTO>();
            CreateMap<ContasPagarDTO, ContasPagar>();

            var entidadeParaListagemDto = CreateMap<ContasPagar, ContasPagarListagemDTO>();
            entidadeParaListagemDto.ForMember(x => x.QuantidadeDiasAtraso, mc => mc.MapFrom(ent => ent.ContasPagarBaixa.Sum(s => s.QtdeDiasAtraso)));
            entidadeParaListagemDto.ForMember(x => x.ValorCorrigido, mc => mc.MapFrom(ent => ent.ContasPagarBaixa.Sum(s => s.ValorPago)));
        }
    }
}
