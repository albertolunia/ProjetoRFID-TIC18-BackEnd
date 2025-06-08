namespace TCC.ProjetoCaprino.Shared.Responses.Product
{
    public class CombinedProductResponse
    {
        public List<GetProductsByRfidsResponse> Products { get; set; }
        public List<RfidTagsNotFoundResponse> NotFoundResponses { get; set; }
    }
}
