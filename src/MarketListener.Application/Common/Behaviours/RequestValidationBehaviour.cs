namespace MarketListener.Application.Common.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarketListener.Domain.Enums.Error;
using FluentValidation;
using MediatR;

internal class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator;
    public RequestValidationBehaviour(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request,
                                  CancellationToken cancellationToken,
                                  RequestHandlerDelegate<TResponse> next)
    {
        if (_validator == null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }

        var validationErrors = validationResult.Errors.Select(a => a.ErrorMessage).Aggregate((a, b) => a + "," + b);
        var response = (TResponse)Activator.CreateInstance(typeof(TResponse), Status.BadRequest, validationErrors, null);
        
        return response; 
    }
}
