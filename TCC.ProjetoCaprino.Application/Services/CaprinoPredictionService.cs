using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.ProjetoCaprino.Application.MLModels;

namespace TCC.ProjetoCaprino.Application.Services;

public class CaprinoPredictionService
{
    private readonly MLContext _mlContext;
    private readonly CaprinoDataService _caprinoDataService;

    public CaprinoPredictionService(CaprinoDataService caprinoDataService)
    {
        _mlContext = new MLContext();
        _caprinoDataService = caprinoDataService;
    }

    public async Task TrainAndSaveModelAsync()
    {
        // 1. Obter os dados históricos do banco de dados
        Console.WriteLine("Buscando dados históricos...");
        var trainingData = await _caprinoDataService.GetHistoricDataForTrainingAsync();
        var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

        Console.WriteLine($"Dados carregados. Total de registros: {trainingData.Count()}");

        // 2. Definir o Pipeline do ML.NET
        var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "RacaEncoded", inputColumnName: "Raca")
            .Append(_mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "TipoDeAlimentoEncoded", inputColumnName: "TipoDeAlimento"))
            .Append(_mlContext.Transforms.Concatenate("Features", "RacaEncoded", "IdadeEmDias", "TipoDeAlimentoEncoded", "QuantidadeDeAlimento"))
            .Append(_mlContext.Regression.Trainers.FastForest(labelColumnName: "Peso"));

        // 3. Treinar o modelo
        Console.WriteLine("Iniciando o treinamento do modelo...");
        var model = pipeline.Fit(dataView);
        Console.WriteLine("Treinamento concluído!");

        // 4. Salvar o modelo treinado em um arquivo
        var modelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "modelo_previsao_peso.zip");
        _mlContext.Model.Save(model, dataView.Schema, modelPath);

        Console.WriteLine($"Modelo salvo em: {modelPath}");
    }

    public ITransformer LoadModel()
    {
        var modelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "modelo_previsao_peso.zip");
        if (!File.Exists(modelPath))
        {
            throw new FileNotFoundException("O modelo não foi encontrado. Por favor, treine o modelo primeiro.");
        }

        // Carregar o modelo a partir do arquivo
        var model = _mlContext.Model.Load(modelPath, out var modelSchema);
        return model;
    }

    public float PredictPeso(CaprinoPesoData input)
    {
        var model = LoadModel();
        var predictionEngine = _mlContext.Model.CreatePredictionEngine<CaprinoPesoData, CaprinoPesoPrediction>(model);
        var prediction = predictionEngine.Predict(input);
        return prediction.PredictedPeso;
    }
}
