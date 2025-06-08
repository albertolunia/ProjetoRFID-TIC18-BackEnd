﻿namespace TCC.ProjetoCaprino.Shared.Responses.Product;

public record DeleteProductResponse(Guid Id, Guid IdCategory, Guid IdSupplier, Guid IdPackaging, string Name, string RfidTag, string Description, decimal Weight,
DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string BatchNumber, int Quantity,
decimal Price, decimal Height, decimal Width, decimal Length, decimal Volume, string ImageObjectName);
