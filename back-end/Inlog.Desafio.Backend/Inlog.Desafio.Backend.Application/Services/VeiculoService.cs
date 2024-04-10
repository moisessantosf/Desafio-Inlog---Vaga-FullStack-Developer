using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Application.Interfaces;
using Inlog.Desafio.Backend.Application.Mappers;
using Inlog.Desafio.Backend.Domain.Common;
using Inlog.Desafio.Backend.Domain.Interfaces;
using Inlog.Desafio.Backend.Domain.Models;

namespace Inlog.Desafio.Backend.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        public readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Result<VeiculoDTO>> CreateAsync(VeiculoCreateRequestDTO veiculo)
        {
            Veiculo newVeiculo = new Veiculo()
            {
                Chassi = veiculo.Chassi,
                TipoVeiculo = veiculo.TipoVeiculo,
                Cor = veiculo.Cor
            };

            var response = await _veiculoRepository.CreateAsync(newVeiculo);
            return new Result<VeiculoDTO>
            {
                Codigo = 201,
                Sucesso = true,
                Data = VeiculoMapper.VeiculoToVeiculoDTO(response)
            };
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var response = await _veiculoRepository.DeleteAsync(id);
            return new Result<bool> 
            { 
                Codigo = response ? 204 : 404,
                Sucesso = response,
                MsgErro = response ? "" : "Não foi possível excluir o veículo.",
                Data = response
            };
        }

        public async Task<Result<IList<VeiculoDTO>>> GetAll()
        {
            var response = await _veiculoRepository.GetAll();

            return new Result<IList<VeiculoDTO>>
            {
                Codigo = 200,
                Sucesso = true,
                Data = VeiculoMapper.VeiculoToVeiculoDTO(response)
            };
        }

        public async Task<Result<VeiculoDTO>> GetVeiculoAsync(int id)
        {
            var response = await _veiculoRepository.GetVeiculoAsync(id);

            return new Result<VeiculoDTO>
            {
                Codigo = 200,
                Sucesso = true,
                Data = VeiculoMapper.VeiculoToVeiculoDTO(response)
            };
        }

        public async Task<Result<VeiculoDTO>> UpdateAsync(Veiculo veiculo)
        {
            var response = await _veiculoRepository.UpdateAsync(veiculo);
            
            return new Result<VeiculoDTO>
            {
                Codigo = 200,
                Sucesso = true,
                Data = VeiculoMapper.VeiculoToVeiculoDTO(response)
            };
        }
    }
}
