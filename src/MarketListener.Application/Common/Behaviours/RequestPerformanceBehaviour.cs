namespace MarketListener.Application.Common.Behaviours;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<RequestPerformanceBehaviour<TRequest, TResponse>> _logger;

    public RequestPerformanceBehaviour(ILogger<RequestPerformanceBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var response = await next();

        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 5000)
        {
            // This method has taken a long time, So we log that to check it later.
            _logger.LogWarning("{request} has taken {elapsedMilliseconds}ms to run completely !", request, stopwatch.ElapsedMilliseconds);
        }

        return response;
    }
}