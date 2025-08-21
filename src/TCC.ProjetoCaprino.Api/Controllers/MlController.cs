using Microsoft.AspNetCore.Mvc;
using TCC.ProjetoCaprino.Api.Models;
using TCC.ProjetoCaprino.Application.MLModels;
using TCC.ProjetoCaprino.Application.Services;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MlController : ControllerBase
{
    private readonly CaprinoPredictionService _predictionService;

    public MlController(CaprinoPredictionService predictionService)
    {
        _predictionService = predictionService;
    }

    [HttpPost("train")]
    public async Task<IActionResult> TrainModel()
    {
        try
        {
            await _predictionService.TrainAndSaveModelAsync();
            return Ok("Modelo de previsão de peso treinado e salvo com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao treinar o modelo: {ex.Message}");
        }
    }

    [HttpPost("predict")]
    public IActionResult PredictPeso([FromBody] CaprinoPredictionRequest request)
    {
        try
        {
            var input = new CaprinoPesoData
            {
                Peso = 0,
                IdadeEmDias = request.IdadeEmDias,
                Raca = request.Raca,
                TipoDeAlimento = request.TipoDeAlimento,
                QuantidadeDeAlimento = request.QuantidadeDeAlimento
            };

            var predictedPeso = _predictionService.PredictPeso(input);

            // Adicionar esta verificação
            if (float.IsNaN(predictedPeso) || float.IsInfinity(predictedPeso))
            {
                return BadRequest("Não foi possível gerar uma previsão válida para os dados fornecidos.");
            }

            return Ok(new { PredictedPeso = predictedPeso });
        }
        catch (FileNotFoundException)
        {
            return NotFound("Modelo de previsão não encontrado. Por favor, treine o modelo primeiro.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao fazer a previsão: {ex.Message}");
        }
    }
}