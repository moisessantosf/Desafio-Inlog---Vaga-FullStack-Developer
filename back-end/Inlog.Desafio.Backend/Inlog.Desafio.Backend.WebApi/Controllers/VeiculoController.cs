using Inlog.Desafio.Backend.Application.DTOs;
using Inlog.Desafio.Backend.Application.Interfaces;
using Inlog.Desafio.Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Inlog.Desafio.Backend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly ILogger<VeiculoController> _logger;
    private readonly IVeiculoService _veiculoService;

    public VeiculoController(ILogger<VeiculoController> logger, IVeiculoService veiculoService)
    {
        _logger = logger;
        _veiculoService = veiculoService;
    }

    [HttpPost("Cadastrar")]
    public async Task<ActionResult<Result<VeiculoDTO>>> Cadastrar([FromBody] VeiculoCreateRequestDTO dadosDoVeiculo)
    {
        if (dadosDoVeiculo is null)
            return BadRequest();

        var response = await _veiculoService.CreateAsync(dadosDoVeiculo);
        
        return Ok(response);
    }

    [HttpGet("Listar")]
    public async Task<IActionResult> ListarVeiculosAsync()
    {
        // TODO: retornar todos veiculos 
        var response = await _veiculoService.GetAll();

        return Ok(response);
    }
}

