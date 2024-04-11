using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.Mappers
{
    public static class VeiculoMapper
    {
        public static IList<VeiculoDTO>? VeiculoToVeiculoDTO(IList<Veiculo> lstVeiculos)
        {
            if (lstVeiculos is null) return null;    

            IList<VeiculoDTO> lstVeiculoDTOs = new List<VeiculoDTO>();
            foreach (var item in lstVeiculos)
            {
                lstVeiculoDTOs.Add(VeiculoToVeiculoDTO(item));
            }

            return lstVeiculoDTOs;
        }

        public static VeiculoDTO? VeiculoToVeiculoDTO(Veiculo veiculo)
        {
            if(veiculo is null) return null;

            return new VeiculoDTO()
            {
                Id = veiculo.Id,
                Placa = veiculo.Placa,
                Chassi = veiculo.Chassi,
                TipoVeiculo = veiculo.TipoVeiculo,
                DescricaoTipoVeiculo = veiculo.TipoVeiculo.ToString(),
                Cor = veiculo.Cor,
                Latitude = veiculo.Latitude,
                Longitude = veiculo.Longitude
            };
        }
    }
}
