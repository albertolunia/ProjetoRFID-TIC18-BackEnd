using Microsoft.ML.Data;

namespace TCC.ProjetoCaprino.Application.MLModels;

public class CaprinoPesoPrediction
{
    [ColumnName("Score")]
    public float PredictedPeso;
}
