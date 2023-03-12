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
    public Word()
    {
        Tags = new List<Tag>();
        Text = ""; 
    }

    public string Text { get; private set; }
    
    public WordType WordType { get; private set; }

    public List<Tag> Tags { get; private set; }

    public bool IsActive { get; private set; }
}
