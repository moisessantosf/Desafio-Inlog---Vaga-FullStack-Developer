using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<IList<Veiculo>> GetAll(double? latitude, double? longitude);
        Task<Veiculo> GetVeiculoAsync(int id);
        Task<Veiculo> CreateAsync(Veiculo veiculo);
        Task<Veiculo> UpdateAsync(Veiculo veiculo);
        Task<bool> DeleteAsync(int id);
    }
}
