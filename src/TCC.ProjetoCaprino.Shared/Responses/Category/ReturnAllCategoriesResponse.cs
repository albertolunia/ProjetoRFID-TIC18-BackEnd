namespace TCC.ProjetoCaprino.Shared.Responses.Category;

public record ReturnAllCategoriesResponse(Guid Id, string Name, string Origin, string Color, bool IsDeleted);
