namespace MarketListener.Api.Endpoints;

using MarketListener.Application.Common.Models;
using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Enums.Error;
using MarketListener.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

public static class EndpointBase
{
    public static IResult CreateResult<T>(T dto) where T : ApplicationDto
    {
        var status = GetStatus(dto.Status);

        var response = new GeneralApiResponse<T>(dto.Message) { Data = dto };

        if (dto is IHasError dtoHasError) response.Errors = GetErrors(dtoHasError);

        return Results.StatusCode(status);
    }

    private static List<GeneralError> GetErrors(IHasError dto)
    {
        return dto.Errors.Select(dtoError => new GeneralError
        {
            Title = "Fail",
            Cause = new Cause(CauseType.GRID, new List<string> { dtoError.Field }, dtoError.Data),
            Details = new List<string> { dtoError.Reason }
        }).ToList();
    }

    private static int GetStatus(Status status)
    {
        return status switch
        {
            Status.Ok => (int)ApiStatus.Ok,
            Status.BadRequest => (int)ApiStatus.BadRequest,
            Status.NotFound => (int)ApiStatus.NotFound,
            Status.InternalServerError => (int)ApiStatus.InternalServerError,
            Status.NotImplemented => (int)ApiStatus.NotImplemented,
            Status.Forbidden => (int)ApiStatus.Forbidden,
            Status.ExternalServerError => (int)ApiStatus.InternalServerError,
            Status.Unauthorized => (int)ApiStatus.Unauthorized,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
