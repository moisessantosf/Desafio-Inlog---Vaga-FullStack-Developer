using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Domain.Common;
using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<Result<IList<VeiculoDTO>>> GetAll(double? latitude, double? longitude);
        Task<Result<VeiculoDTO>> GetVeiculoAsync(int id);
        Task<Result<VeiculoDTO>> CreateAsync(VeiculoCreateRequestDTO veiculo);
        Task<Result<VeiculoDTO>> UpdateAsync(Veiculo veiculo);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
