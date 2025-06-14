﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Enums;
using TCC.ProjetoCaprino.Shared.Exceptions;

namespace TCC.ProjetoCaprino.Api.Controllers;
public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<ActionResult> SendCommand(IRequest<Result> request, int statusCode = 200)
        => await _mediator.Send(request) switch
        {
            (true, _) => StatusCode(statusCode),
            var (_, error) => HandleError(error!)
        };

    protected async Task<ActionResult<T>> SendCommand<T>(IRequest<Result<T>> request, int statusCode = 200)
        => await _mediator.Send(request).ConfigureAwait(false) switch
        {
            (true, var result, _) => StatusCode(statusCode, result),
            var (_, res, error) => HandleError(error!)
        };

   

    protected ActionResult HandleError(Exception error) => error switch
    {
        NoResultException e => NoContent(),
        InvalidRequestExeption e => BadRequest(FormatErrorMessage(e.ErrorResult, e.Errors)),
        ExceptionApplication e => BadRequest(FormatErrorMessage(e.ErrorResult)),
        _ => BadRequest(FormatErrorMessage(RegisteredErrors.Generic))
    };

    private ErrorResult FormatErrorMessage(ErrorResult responseError, IEnumerable<string>? errors = null)
    {
        if (errors != null)
        {
            responseError.ErrorDescription = $"{responseError.ErrorDescription}: {string.Join("; ", errors!)}";
        }

        return responseError;
    }
}