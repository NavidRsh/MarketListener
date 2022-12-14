namespace MarketListener.Domain.Common;

using Enums.Error;
using System.Text.Json.Serialization;

public abstract class ApplicationDto
{
    [JsonIgnore]
    public Status Status { get; }

    [JsonIgnore]
    public string? Message { get; }

    protected ApplicationDto(Status status, string? message = null)
    {
        Status = status;
        Message = message;
    }
}