using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Domain.Interfaces
{
    public interface IRastreamentoRepository
    {
        Task<IList<Rastreamento>> GetAll();
        Task<Rastreamento> GetRastreamentoAsync(int id);
        Task<Rastreamento> CreateAsync(Rastreamento rastreamento);
        Task<Rastreamento> UpdateAsync(Rastreamento rastreamento);
        Task<bool> DeleteAsync(int id);
    }
}
