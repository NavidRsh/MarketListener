namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MeaningExample : Entity<int>
{
    public string Text { get; set; }

    public int MeaningId { get; set; }

    public Meaning Meaning { get; set; }
}
