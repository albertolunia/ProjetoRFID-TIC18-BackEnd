using Microsoft.ML.Data;

namespace TCC.ProjetoCaprino.Application.MLModels;

public class CaprinoPesoData
{
    [LoadColumn(0)]
    public float Peso;

    [LoadColumn(1)]
    public float IdadeEmDias;

    [LoadColumn(2)]
    public string Raca;

    [LoadColumn(3)]
    public string TipoDeAlimento;

    [LoadColumn(4)]
    public float QuantidadeDeAlimento;
}