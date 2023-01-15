namespace MarketListener.Filters;

using Azure;
using FluentValidation;
using MarketListener.Endpoints;
using MarketListener.Application.Common.Models;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums.Error;
using MarketListener.Domain.Interfaces;
using System.Threading.Tasks;

public class ValidationFilter<TRequest, TResponse> : IEndpointFilter 
    where TRequest : class
    where TResponse : ApplicationDto
{
    private readonly IValidator<TRequest> _validator;
    public ValidationFilter(IValidator<TRequest> validator)
    {
        _validator = validator;
    }
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var objectToValidate = context.GetArgument<TRequest>(0);

        if (objectToValidate != null)
        {
            var validationResult = await _validator.ValidateAsync(objectToValidate);
            if (!validationResult.IsValid)
            {
                //Results.BadRequest(validationResult.ToDictionary());
                var validationErrors = validationResult.Errors.Select(a => a.ErrorMessage).Aggregate((a, b) => a + "," + b);
                return EndpointBase.CreateResult((TResponse)Activator.CreateInstance(typeof(TResponse), Status.BadRequest, validationErrors));
            }
        }

        var result = await next(context);

        return result;

    }

    
}
