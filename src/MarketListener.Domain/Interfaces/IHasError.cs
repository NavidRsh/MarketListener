namespace MarketListener.Domain.Interfaces;

using System.Collections.Generic;
using System.Text.Json.Serialization;
using MarketListener.Domain.Common;

public interface IHasError
{
    public List<Error> Errors { get; set; }
}
