using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO; // Adicione esta importação para Path e Directory
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Domain.Handlers.Relatorios; // Ajuste o namespace

public class GenerateCaprinoReportRequestHandler
    : IRequestHandler<GenerateCaprinoReportRequest, Result<GenerateCaprinoReportResponse>>
{
    private readonly ILogger<GenerateCaprinoReportRequestHandler> _logger;
    private readonly ICaprinoRepository _caprinoRepository;
    // Opcional: injetar um serviço para geração de gráficos, se for complexo
    // private readonly IChartGeneratorService _chartGeneratorService;

    public GenerateCaprinoReportRequestHandler(
        ICaprinoRepository caprinoRepository,
        ILogger<GenerateCaprinoReportRequestHandler> logger
    /*, IChartGeneratorService chartGeneratorService*/
    )
    {
        _caprinoRepository = caprinoRepository;
        _logger = logger;
        // _chartGeneratorService = chartGeneratorService;
    }

    public async Task<Result<GenerateCaprinoReportResponse>> Handle(GenerateCaprinoReportRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando a geração de relatório de caprinos com filtros.");

        try
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // 1. Coleta dos Dados Filtrados
            List<CaprinoEntity> caprinosFiltrados = await _caprinoRepository.GetCaprinosFilteredAsync(
                request.IsIndividualReport,
                request.Brinco,
                request.RacaId,
                request.TipoDeCriacaoId,
                request.Sexo,
                request.TipoDeAlimentacaoId
            );

            List<HistoricoDoCaprinoEntity> historicosFiltrados = new();
            if (request.DataInicio.HasValue && request.DataFim.HasValue && caprinosFiltrados.Any())
            {
                // Se for relatório individual, pega o ID do primeiro caprino filtrado.
                // Se for geral, passa null para buscar histórico de todos os caprinos no período.
                Guid? caprinoIdParaHistorico = request.IsIndividualReport && caprinosFiltrados.Any()
                                               ? caprinosFiltrados.First().Id
                                               : (Guid?)null;

                historicosFiltrados = await _caprinoRepository.GetHistoricoFilteredAsync(
                    caprinoIdParaHistorico,
                    request.DataInicio,
                    request.DataFim,
                    request.TipoDeEvento,
                    request.TipoDeVacina
                );
            }
            // TODO: Buscar outros dados auxiliares, como nomes de raças/tipos de criação se não vierem no Include
            // Ou garantir que as entidades Raca e TipoDeCriacao estão sendo eager-loaded (Include)
            // no GetCaprinosFilteredAsync e GetHistoricoFilteredAsync.

            var dadosRelatorio = new
            {
                Request = request,
                Caprinos = caprinosFiltrados,
                Historicos = historicosFiltrados,
            };
            // var chartBytes = _chartGeneratorService.GeneratePieChart(dataForChart);
            // Isso retornaria um byte[] de uma imagem PNG do gráfico.

            var pdfFileName = $"RelatorioCaprinos_{DateTime.UtcNow:yyyyMMddHHmmss}.pdf";
            var pdfFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", pdfFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(pdfFilePath)!);

            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header()
                        .Text("Relatório de Análise de Desempenho do Rebanho Caprino")
                        .FontSize(18).Bold().AlignCenter();

                    page.Content()
                        .PaddingVertical(1, QuestPDF.Infrastructure.Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(5); // Espaçamento entre os itens da coluna

                            column.Item().Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm}");
                            column.Item().Text($"Período: {request.DataInicio?.ToString("dd/MM/yyyy") ?? "Início"} a {request.DataFim?.ToString("dd/MM/yyyy") ?? "Fim"}");

                            column.Item().Text("Filtros Aplicados:").Bold();
                            if (request.IsIndividualReport && !string.IsNullOrWhiteSpace(request.Brinco))
                                column.Item().Text($"- Brinco: {request.Brinco}");
                            if (!string.IsNullOrWhiteSpace(request.Sexo))
                                column.Item().Text($"- Sexo: {request.Sexo}");
                            if (request.RacaId.HasValue)
                            {
                                // Acessa o nome da raça se o Include foi usado no repositório
                                column.Item().Text($"- Raça: {dadosRelatorio.Caprinos.FirstOrDefault(c => c.RacaId == request.RacaId)?.Raca?.Raca ?? request.RacaId.ToString()}");
                            }
                            if (request.TipoDeCriacaoId.HasValue)
                            {
                                // Acessa o nome do tipo de criação se o Include foi usado no repositório
                                column.Item().Text($"- Tipo de Criação: {dadosRelatorio.Caprinos.FirstOrDefault(c => c.TipoDeCricaoId == request.TipoDeCriacaoId)?.TipoDeCricao?.TipoDeCriacao ?? request.TipoDeCriacaoId.ToString()}");
                            }
                            if (request.TipoDeAlimentacaoId.HasValue)
                            {
                                // Você precisaria buscar o nome do Tipo de Alimentacao se houver uma entidade para isso.
                                column.Item().Text($"- Tipo de Alimentação: {request.TipoDeAlimentacaoId.ToString()}");
                            }
                            if (!string.IsNullOrWhiteSpace(request.TipoDeEvento))
                            {
                                column.Item().Text($"- Tipo de Evento: {request.TipoDeEvento}");
                                if (!string.IsNullOrWhiteSpace(request.TipoDeVacina))
                                {
                                    column.Item().Text($"- Tipo de Vacina: {request.TipoDeVacina}");
                                }
                            }


                            column.Item().LineHorizontal(1); // Linha separadora

                            column.Item().Text("1. Resumo").FontSize(14).Bold();
                            if (request.IsIndividualReport && caprinosFiltrados.Any())
                            {
                                var caprino = caprinosFiltrados.First();
                                column.Item().Text($"Detalhes do Caprino: {caprino.Brinco}");
                                column.Item().Text($"Sexo: {(caprino.Sexo ? "Macho" : "Fêmea")}");
                                column.Item().Text($"Nascimento: {caprino.DataNascimento:dd/MM/yyyy} (Idade: {CalculateAge(caprino.DataNascimento)})");
                                column.Item().Text($"Raça: {caprino.Raca?.Raca ?? "N/A"}");
                                column.Item().Text($"Tipo de Criação: {caprino.TipoDeCricao?.TipoDeCriacao ?? "N/A"}");
                                column.Item().Text($"Peso Atual: {caprino.PesoAtual} kg");
                                column.Item().Text($"Observações: {caprino.Observacoes ?? "Nenhuma."}");
                            }
                            else
                            {
                                column.Item().Text($"Total de Caprinos Ativos: {caprinosFiltrados.Count}");
                                // Exemplo de gráfico de pizza simples (simulando dados)
                                column.Item().Text("Distribuição por Sexo (Gráfico de Pizza - Mock):");
                                // **CORREÇÃO CS0103 AQUI:** Passa o byte[] diretamente.
                                column.Item().Image(CreateSimplePieChartImage());
                            }

                            column.Item().LineHorizontal(1);

                            column.Item().Text("2. Análise de Ganhos de Peso").FontSize(14).Bold();
                            // Filtra apenas históricos de "Pesagem" para esta seção
                            var historicosPesagem = historicosFiltrados.Where(h => h.Evento?.TipoDeEvento == "Pesagem" && h.Peso > 0).ToList();

                            if (historicosPesagem.Any())
                            {
                                column.Item().Text("Histórico de Pesagens:");
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3); // Brinco
                                        columns.RelativeColumn(2); // Data
                                        columns.RelativeColumn(2); // Peso
                                        columns.RelativeColumn(3); // Tipo Evento (opcional, já sabemos que é Pesagem)
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Brinco").Bold();
                                        header.Cell().Text("Data").Bold();
                                        header.Cell().Text("Peso").Bold();
                                        header.Cell().Text("Tipo Evento").Bold();
                                    });

                                    foreach (var hist in historicosPesagem.OrderBy(h => h.Caprino?.Brinco).ThenBy(h => h.CreatedAt))
                                    {
                                        table.Cell().Text(hist.Caprino?.Brinco ?? "N/A");
                                        table.Cell().Text(hist.CreatedAt.ToString("dd/MM/yyyy"));
                                        table.Cell().Text($"{hist.Peso:F2} kg");
                                        table.Cell().Text(hist.Evento?.TipoDeEvento ?? "N/A");
                                    }
                                });

                                column.Item().Text("Gráfico de Peso ao Longo do Tempo (Mock):");
                                // **CORREÇÃO CS0103 AQUI:** Passa o byte[] diretamente.
                                column.Item().Image(CreateSimpleLineChartImage());
                            }
                            else
                            {
                                column.Item().Text("Nenhum histórico de peso encontrado para o período/filtros.");
                            }

                            column.Item().LineHorizontal(1);

                            column.Item().Text("3. Eventos de Saúde e Manejo").FontSize(14).Bold();
                            // Filtra históricos que não são pesagens para esta seção
                            var historicosNaoPesagem = historicosFiltrados.Where(h => h.Evento?.TipoDeEvento != "Pesagem").ToList();

                            if (historicosNaoPesagem.Any())
                            {
                                // Agrupar eventos por tipo e exibir contagem
                                var eventosPorTipo = historicosNaoPesagem
                                    .GroupBy(h => h.Evento)
                                    .Select(g => new { Tipo = g.Key, Count = g.Count() })
                                    .ToList();

                                column.Item().Text("Eventos Registrados por Tipo:");
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });
                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Tipo de Evento").Bold();
                                        header.Cell().Text("Quantidade").Bold();
                                    });
                                    foreach (var evento in eventosPorTipo)
                                    {
                                        table.Cell().Text(evento.Tipo?.TipoDeEvento ?? "N/A");
                                        table.Cell().Text(evento.Count.ToString());
                                    }
                                });

                                column.Item().Text("Detalhes dos Últimos Eventos (Não Pesagem):");
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(2); // Brinco
                                        columns.RelativeColumn(2); // Data
                                        columns.RelativeColumn(3); // Tipo Evento
                                        columns.RelativeColumn(3); // Observações/Detalhes
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Brinco").Bold();
                                        header.Cell().Text("Data").Bold();
                                        header.Cell().Text("Tipo Evento").Bold();
                                        header.Cell().Text("Detalhes").Bold();
                                    });

                                    foreach (var hist in historicosNaoPesagem.OrderByDescending(h => h.CreatedAt).Take(10))
                                    {
                                        table.Cell().Text(hist.Caprino?.Brinco ?? "N/A");
                                        table.Cell().Text(hist.CreatedAt.ToString("dd/MM/yyyy"));
                                        table.Cell().Text(hist.Evento?.TipoDeEvento ?? "N/A");
                                        table.Cell().Text(hist.Observacoes ?? "N/A");
                                    }
                                });

                            }
                            else
                            {
                                column.Item().Text("Nenhum evento de saúde/manejo encontrado para o período/filtros.");
                            }
                        });

                    page.Footer()
                        .AlignRight()
                        .Text(x =>
                        {
                            x.Span("Página ").FontSize(8);
                            x.CurrentPageNumber().FontSize(8);
                            x.Span(" de ").FontSize(8);
                            x.TotalPages().FontSize(8);
                        });
                });
            }).GeneratePdf(pdfFilePath);

            _logger.LogInformation("Relatório PDF gerado com sucesso em: {FilePath}", pdfFilePath);
            return Result.Success(new GenerateCaprinoReportResponse(Guid.NewGuid(), pdfFilePath));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao gerar o relatório PDF de caprinos.");
            return Result.Error<GenerateCaprinoReportResponse>(ex);
        }
    }

    private byte[] CreateSimplePieChartImage()
    {
        using var surface = SKSurface.Create(new SKImageInfo(300, 200));
        var canvas = surface.Canvas;
        canvas.Clear(SKColors.White);

        // Exemplo: 60% Machos, 40% Fêmeas (ajuste com dados reais se quiser)
        float startAngle = 0;
        float sweepAngleMale = 0.6f * 360;
        float sweepAngleFemale = 0.4f * 360;

        using (var paintMale = new SKPaint { Color = SKColors.Blue, IsAntialias = true })
        using (var paintFemale = new SKPaint { Color = SKColors.DeepPink, IsAntialias = true })
        {
            SKRect rect = new SKRect(50, 20, 250, 180); // Posição do gráfico
            canvas.DrawArc(rect, startAngle, sweepAngleMale, true, paintMale);
            canvas.DrawArc(rect, startAngle + sweepAngleMale, sweepAngleFemale, true, paintFemale);
        }

        // Adicionar legenda
        canvas.DrawText("60% Machos", 10, 10, new SKPaint { Color = SKColors.Blue, TextSize = 12 });
        canvas.DrawText("40% Fêmeas", 10, 25, new SKPaint { Color = SKColors.DeepPink, TextSize = 12 }); // Corrigido a cor da legenda

        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        return data.ToArray();
    }

    private byte[] CreateSimpleLineChartImage()
    {
        using var surface = SKSurface.Create(new SKImageInfo(400, 200));
        var canvas = surface.Canvas;
        canvas.Clear(SKColors.White);

        // Eixos (muito simplificado)
        using var paintAxis = new SKPaint { Color = SKColors.Gray, StrokeWidth = 2 };
        canvas.DrawLine(50, 180, 380, 180, paintAxis); // X-axis
        canvas.DrawLine(50, 20, 50, 180, paintAxis);   // Y-axis

        // Dados de exemplo para linha (ajuste com dados reais se quiser)
        float[] weights = { 20, 22, 25, 24, 27, 28, 30 };
        float[] dates = { 0, 1, 2, 3, 4, 5, 6 }; // Representa pontos no tempo (ex: semanas)

        using var paintLine = new SKPaint { Color = SKColors.ForestGreen, StrokeWidth = 3, IsAntialias = true, Style = SKPaintStyle.Stroke }; // Cor mais visível

        SKPoint[] points = new SKPoint[weights.Length];
        float minWeight = weights.Min();
        float maxWeight = weights.Max();
        float weightRange = maxWeight - minWeight;

        for (int i = 0; i < weights.Length; i++)
        {
            // Mapeia dados para coordenadas do canvas (exemplo simplificado e escalado)
            float x = 50 + (i * (330f / (weights.Length - 1))); // Escala X para preencher o gráfico (50 a 380)
            float y = 180 - ((weights[i] - minWeight) / weightRange) * 150; // Escala Y (de 20 a 180)
            points[i] = new SKPoint(x, y);
        }

        if (points.Length > 1)
        {
            canvas.DrawPoints(SKPointMode.Polygon, points, paintLine);
        }
        else if (points.Length == 1)
        {
            canvas.DrawCircle(points[0].X, points[0].Y, 3, paintLine); // Desenha um ponto se houver apenas um dado
        }

        // Labels (muito simplificado)
        canvas.DrawText("Peso (kg)", 10, 100, new SKPaint { Color = SKColors.Black, TextSize = 10 });
        canvas.DrawText("Tempo", 200, 195, new SKPaint { Color = SKColors.Black, TextSize = 10 });

        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        return data.ToArray();
    }

    // Método auxiliar para calcular idade formatada
    private string CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;

        if (age >= 1) return $"{age} anos";

        var months = today.Month - birthDate.Month;
        if (today.Day < birthDate.Day) months--;

        if (months > 0) return $"{months} meses";

        var days = (today - birthDate).Days;
        return $"{days} dias";
    }
}
