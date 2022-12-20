namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using MarketListener.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Word : Entity<int>
{
    public string Text { get; set; }
    
    public WordType WordType { get; set; }

    public List<Tag> Tags { get; set; }
}
