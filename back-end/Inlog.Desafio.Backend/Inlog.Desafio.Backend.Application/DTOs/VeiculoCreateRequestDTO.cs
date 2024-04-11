using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.DTOs
{
    public class VeiculoCreateRequestDTO
    {
        public string? Placa { get; set; }
        public string? Chassi { get; set; }
        public string? TipoVeiculo { get; set; }
        public string? Cor { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
