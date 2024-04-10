using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Domain.Common;
using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.Interfaces
{
    public interface IRastreamentoService
    {
        Task<Result<IList<RastreamentoDTO>>> GetAll();
        Task<Result<RastreamentoDTO>> GetRastreamentoAsync(int id);
        Task<Result<RastreamentoDTO>> CreateAsync(Rastreamento rastreamento);
        Task<Result<RastreamentoDTO>> UpdateAsync(Rastreamento rastreamento);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
