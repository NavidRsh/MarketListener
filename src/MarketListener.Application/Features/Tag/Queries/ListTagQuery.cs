namespace MarketListener.Application.Features.Tag.Queries;

using MarketListener.Domain.Common;
using MarketListener.Domain.Entities;
using MarketListener.Domain.Enums;
using MarketListener.Domain.Enums.Error;
using MediatR;
using Sieve.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public sealed class ListTagQuery : IRequest<ListTagQueryDto>
{
    public SieveModel? SieveModel { get; init; }
}

public sealed class ListTagQueryDto : ApplicationDto
{
    public List<ListTagQueryDtoItem>? List { get; set; }
    public long Count { get; init; }
    public ListTagQueryDto(Status status, string message = "") : base(status, message)
    {
        
    }
}

public class ListTagQueryDtoItem
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string PersianName { get; set; }
    public string Code { get; set; }
    public string Category { get; set; }
    public int? ParentId { get; set; }
    public String? ParentName { get; set; }
}