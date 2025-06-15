using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.ProjetoCaprino.Shared.Responses.Caprino;

public class GenerateCaprinoReportResponse
{
    public Guid ReportId { get; set; }
    public string FilePath { get; set; }
    public string Message { get; set; } = "Relatório gerado com sucesso.";

    public GenerateCaprinoReportResponse(Guid reportId, string filePath)
    {
        ReportId = reportId;
        FilePath = filePath;
    }
}
