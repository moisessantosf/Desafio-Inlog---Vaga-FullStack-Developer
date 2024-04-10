using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Application.Interfaces;
using Inlog.Desafio.Backend.Application.Mappers;
using Inlog.Desafio.Backend.Domain.Common;
using Inlog.Desafio.Backend.Domain.Interfaces;
using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.Services
{
    public class RastreamentoService : IRastreamentoService
    {
        private readonly IRastreamentoRepository _rastreamentoRepository;

        public RastreamentoService(IRastreamentoRepository rastreamentoRepository)
        {
            _rastreamentoRepository = rastreamentoRepository;           
        }

        public async Task<Result<RastreamentoDTO>> CreateAsync(Rastreamento rastreamento)
        {
            Rastreamento newRastreamento = new Rastreamento()
            {
                Veiculo = rastreamento.Veiculo,
                DataCriacao = DateTime.Now,
                Latitude = rastreamento.Latitude,
                Longitude = rastreamento.Longitude
            };

            var response = await _rastreamentoRepository.CreateAsync(newRastreamento);

            return new Result<RastreamentoDTO>()
            {
                Codigo = 201,
                Sucesso = true,
                Data = RastreamentoMapper.RastreamentoToRastreamentoDTO(response)
            };

        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var response = await _rastreamentoRepository.DeleteAsync(id);
            return new Result<bool>()
            {
                Codigo = response ? 204 : 404,
                Sucesso = response,
                MsgErro = response ? "" : "Não foi possível excluir o rastreamento.",
                Data = response
            };
        }

        public async Task<Result<IList<RastreamentoDTO>>> GetAll()
        {
            var response = await _rastreamentoRepository.GetAll();

            return new Result<IList<RastreamentoDTO>>
            {
                Codigo = 200,
                Sucesso = true,
                Data = RastreamentoMapper.RastreamentoToRastreamentoDTO(response)
            };
        }

        public async Task<Result<RastreamentoDTO>> GetRastreamentoAsync(int id)
        {
            var response = await _rastreamentoRepository.GetRastreamentoAsync(id);

            return new Result<RastreamentoDTO>
            {
                Codigo = 200,
                Sucesso = true,
                Data = RastreamentoMapper.RastreamentoToRastreamentoDTO(response)
            };
        }

        public async Task<Result<RastreamentoDTO>> UpdateAsync(Rastreamento rastreamento)
        {
            var response = await _rastreamentoRepository.UpdateAsync(rastreamento);
            
            return new Result<RastreamentoDTO>
            {
                Codigo = 200,
                Sucesso = true,
                Data = RastreamentoMapper.RastreamentoToRastreamentoDTO(response)
            };
        }
    }
}
