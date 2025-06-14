﻿namespace TCC.ProjetoCaprino.Shared.Responses.Caprino;

public record ReturnHistoricoDoCaprinoResponse(
        Guid Id,
        Guid CaprinoId,
        decimal Peso,
        decimal QuantidadeDeLeite,
        Guid TipoDeAlimentoId,
        decimal QuantidadeDeAlimento,
        Guid EventoId,
        Guid? VacinaId,
        string? Observacoes,
        DateTime CreatedAt
    );
