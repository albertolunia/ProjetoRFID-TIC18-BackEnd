using TCC.ProjetoCaprino.Shared.Requests.Product;
using TCC.ProjetoCaprino.Shared.Responses.Product;
using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Services;

namespace TCC.ProjetoCaprino.Domain.Handlers.Product
{
	public class GetProductImageUrlRequestHandler
		: IRequestHandler<GetProductImageUrlRequest, Result<GetProductImageUrlResponse>>
	{
		private readonly IMinioService _minioService;

		public GetProductImageUrlRequestHandler(IMinioService minioService) 
			=> _minioService = minioService;

		public async Task<Result<GetProductImageUrlResponse>> Handle(GetProductImageUrlRequest request, CancellationToken cancellationToken)
		{
			var url = await _minioService.GetObjectUrlAsync("rfid-product-images", request.ObjectName);

			var response = new GetProductImageUrlResponse(url);

			return Result.Success(response);
		}
	}
}
