using Refit;

namespace TCC.ProjetoCaprino.Domain.Services;
public interface IService
{
    [Post("api/v1/Send")]
    Task<ApiResponse<HttpResponseMessage>> SendNotification([Body] object notification);
}