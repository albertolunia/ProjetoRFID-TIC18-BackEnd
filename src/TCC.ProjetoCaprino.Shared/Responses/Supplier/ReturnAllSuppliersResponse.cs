namespace TCC.ProjetoCaprino.Shared.Responses.Supplier;

public record ReturnAllSuppliersResponse(Guid Id, string Name, string Description, string PhoneNumber, bool IsDeleted);

