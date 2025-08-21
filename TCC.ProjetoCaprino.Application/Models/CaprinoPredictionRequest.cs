namespace TCC.ProjetoCaprino.Api.Models;

public class CaprinoPredictionRequest
{
    public float IdadeEmDias { get; set; }
    public string Raca { get; set; }
    public string TipoDeAlimento { get; set; }
    public float QuantidadeDeAlimento { get; set; }
}