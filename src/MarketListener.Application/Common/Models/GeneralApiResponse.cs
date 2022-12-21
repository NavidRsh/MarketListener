namespace MarketListener.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class GeneralApiResponse<T>
{
    public GeneralApiResponse(string title)
    {
        if (!string.IsNullOrEmpty(title))
        {
            Message = new GeneralMessage
            {
                Title = title
            };
        }
    }

    public string Type => "SabaTamin";

    public GeneralMessage? Message { get; }

    public List<GeneralError>? Errors { get; set; }

    public T? Data { get; set; }

    public string? Stack { get; set; }
}
