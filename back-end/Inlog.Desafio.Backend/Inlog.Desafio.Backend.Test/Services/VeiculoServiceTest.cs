using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Application.Services;
using Inlog.Desafio.Backend.Domain.Interfaces;
using Inlog.Desafio.Backend.Domain.Models;
using Moq;
using Xunit;

namespace Inlog.Desafio.Backend.Test.Services
{
    public class VeiculoServiceTest
    {
        [Fact]
        public async Task CreateAsync_ValidInput_ReturnsSuccessResult()
        {
            // Arrange
            var veiculoRepositoryMock = new Mock<IVeiculoRepository>();
            veiculoRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Veiculo>())).ReturnsAsync(new Veiculo());
            var veiculoService = new VeiculoService(veiculoRepositoryMock.Object);
            var veiculoCreateRequestDTO = new VeiculoCreateRequestDTO()
            {
                Placa = "TES0001",
                Chassi = "ABC1234567891",
                TipoVeiculo = "1",
                Cor = "Azul",
                Latitude = -26,
                Longitude = -46
            };

            // Act
            var result = await veiculoService.CreateAsync(veiculoCreateRequestDTO);

            // Assert
            Assert.True(result.Sucesso);
            Assert.Equal(201, result.Codigo);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task GetAll_WithCoordinates_ReturnsSuccessResultWithVeiculos()
        {
            // Arrange
            var veiculoRepositoryMock = new Mock<IVeiculoRepository>();
            var veiculoService = new VeiculoService(veiculoRepositoryMock.Object);
            var veiculoList = new List<Veiculo>() { new Veiculo(), new Veiculo() };
            veiculoRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<double?>(), It.IsAny<double?>())).ReturnsAsync(veiculoList);

            // Act
            var result = await veiculoService.GetAll(0, 0);

            // Assert
            Assert.True(result.Sucesso);
            Assert.Equal(200, result.Codigo);
            Assert.Equal(2, result.Data.Count);
        }

    }
}
