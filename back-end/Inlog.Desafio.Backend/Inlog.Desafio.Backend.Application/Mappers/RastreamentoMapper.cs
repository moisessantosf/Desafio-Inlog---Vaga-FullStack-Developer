using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.Mappers
{
    public static class RastreamentoMapper
    {
        public static IList<RastreamentoDTO>? RastreamentoToRastreamentoDTO(IList<Rastreamento> lstRastreamentos)
        {
            if (lstRastreamentos is null) return null;

            IList<RastreamentoDTO> lstVeiculoDTOs = new List<RastreamentoDTO>();
            foreach (var item in lstRastreamentos)
            {
                lstRastreamentos.Add(RastreamentoToRastreamentoDTO(item));
            }

            return lstVeiculoDTOs;
        }

        public static RastreamentoDTO? RastreamentoToRastreamentoDTO(Rastreamento rastreamento)
        {
            if (rastreamento is null) return null;

            return new RastreamentoDTO()
            {
              Veiculo = rastreamento.Veiculo,
              DataCriacao = rastreamento.DataCriacao,
              Latitude = rastreamento.Latitude,
              Longitude = rastreamento.Longitude
            };
        }
    }
}
