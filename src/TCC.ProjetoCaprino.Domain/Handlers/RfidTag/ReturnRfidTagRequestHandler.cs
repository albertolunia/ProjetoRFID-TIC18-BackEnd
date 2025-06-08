//using TCC.ProjetoCaprino.Shared.Requests.RfidTag;
//using TCC.ProjetoCaprino.Shared.Responses.RfidTag;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.RfidTag;

//public class ReturnRfidTagRequestHandler : IRequestHandler<ReturnRfidTagRequest, Result<ReturnRfidTagResponse>>
//{
//    private readonly ILogger<ReturnRfidTagRequestHandler> _logger;

//    private readonly IRfidTagRepository _rfidTagRepository;

//    public ReturnRfidTagRequestHandler(IRfidTagRepository rfidTagRepository, ILogger<ReturnRfidTagRequestHandler> logger)
//    {
//        _rfidTagRepository = rfidTagRepository;
//        _logger = logger;
//    }

//    public async Task<Result<ReturnRfidTagResponse>> Handle(ReturnRfidTagRequest request, CancellationToken cancellationToken)
//    {
//        var rfidTag = await _rfidTagRepository.ReturnRfidTagAsync(request.Id);
//        if (rfidTag == null)
//        {
//            //return Result.Error<ReturnRfidTagResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
//        }

//        await _rfidTagRepository.ReturnRfidTagAsync(rfidTag.Id);

//        var response = new ReturnRfidTagResponse(rfidTag.Id, rfidTag.RfidTag);

//        return Result.Success(response);
//    }
//}
