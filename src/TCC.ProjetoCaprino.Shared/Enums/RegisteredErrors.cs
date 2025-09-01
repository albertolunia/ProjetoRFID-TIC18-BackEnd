using TCC.ProjetoCaprino.Shared.Exceptions;

namespace TCC.ProjetoCaprino.Shared.Enums;
public class RegisteredErrors
{
    public static readonly ErrorResult Generic = new()
    {
        ErrorTitle = "Ops ocorreu um erro no nosso sistema",
        ErrorDescription = "No momento, nosso sistema está indisponível. Por Favor tente novamente",
        Tipo = TypeError.Error
    };

    public static readonly ErrorResult NoResults = new()
    {
        ErrorTitle = "Sua busca não obteve resultados",
        ErrorDescription = "Tente buscar novamente",
        Tipo = TypeError.Alert
    };

    public static ErrorResult InvalidData = new()
    {
        ErrorTitle = "Dados inválidos",
        ErrorDescription = "Os dados enviados na requisição são inválidos",
        Tipo = TypeError.Error
    };

    public static ErrorResult ErrorSavingProduct = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação de Produto. Por favor tente novamente",
        Tipo = TypeError.Error
    };
    public static ErrorResult ErrorSavingCategory = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação de Categoria. Por favor tente novamente",
        Tipo = TypeError.Error
    };
    public static ErrorResult ErrorSavingSupplier = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação de Fornecedor. Por favor tente novamente",
        Tipo = TypeError.Error
    };
    public static ErrorResult ErrorSavingReadout = new()
    {
        ErrorTitle = "Ocorreu um erro na gravação",
        ErrorDescription = "Ocorreu um erro na gravação de Leitura. Por favor tente novamente",
        Tipo = TypeError.Error
    };
    public static ErrorResult IdProductInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID do produto especificado não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdCategoryInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID da categoria especificada não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdSupplierInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID do fornecedor especificado não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdReadoutInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID da leitura especificada não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdPackagingInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID da embalagem especificada não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult ProductAlreadyExist = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "Esse produto ja existe",
        Tipo = TypeError.Alert
    };

    public static ErrorResult CategoryAlreadyExist = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "Essa categoria ja existe",
        Tipo = TypeError.Alert
    };

    public static ErrorResult SupplierAlreadyExist = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "Esse fornecedor ja existe",
        Tipo = TypeError.Alert
    };
    public static ErrorResult ReadoutAlreadyExist = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "Essa leitura ja existe",
        Tipo = TypeError.Alert
    };
    public static ErrorResult ProductListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de produtos retornada está vazia",
        Tipo = TypeError.Alert
    };

    public static ErrorResult CategoryListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de categorias retornada está vazia",
        Tipo = TypeError.Alert
    };

    public static ErrorResult SupplierListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de fornecedores retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult ReadoutListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de leituras retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult PackagingListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de embalagens retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult PackageNameAlreadyExists = new()
    {
        ErrorTitle = "Nome inválido",
        ErrorDescription = "Já existe uma embalagem com esse nome",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdCaprinoInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID do caprino especificado não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult CaprinoListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de caprinos retornada está vazia",
        Tipo = TypeError.Alert
    };

    public static ErrorResult HistoricoCaprinoListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de históricos de caprinos retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult RacaListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de raças retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult TipoDeAlimentoListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de tipos de alimento retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdTipoDeAlimentoInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID do tipo de alimento especificado não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult TipoDeCriacaoListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de tipos de criação retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdTipoDeCriacaoInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID do tipo de criação especificado não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult VacinaListEmpty = new()
    {
        ErrorTitle = "Lista vazia",
        ErrorDescription = "A lista de vacinas retornada está vazia",
        Tipo = TypeError.Alert
    };
    public static ErrorResult IdVacinaInvalid = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "O ID da vacina especificada não é válido",
        Tipo = TypeError.Alert
    };
    public static ErrorResult CaprinoAlreadyExist = new()
    {
        ErrorTitle = "Dado inválido",
        ErrorDescription = "Já existe um caprino com esse brinco",
        Tipo = TypeError.Alert
    };
}