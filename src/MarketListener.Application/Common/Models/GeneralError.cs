namespace MarketListener.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GeneralError
{
    public string Title { get; set; }

    public Cause Cause { get; set; }

    public long? Code { get; set; }

    public List<string> Details { get; set; }

    public GeneralError()
    {
        Details = new List<string>();
    }
}
