namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Meaning : Entity<int>
{
    public string Description { get; set; } = default!; 
    public int WordId { get; set; }
    public Word? Word { get; set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; } = default!; 
}
