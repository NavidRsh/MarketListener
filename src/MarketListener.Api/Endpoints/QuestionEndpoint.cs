namespace MarketListener.Api.Endpoints;

using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

public class QuestionEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("question");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new { Message = "Hello World" }, cancellation: ct);
    }
}
