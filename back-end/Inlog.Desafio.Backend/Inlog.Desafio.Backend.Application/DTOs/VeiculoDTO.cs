using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.DTOs
{
    public class VeiculoDTO : Veiculo
    {        
        public string? DescricaoTipoVeiculo { get; set; }
    }
}
