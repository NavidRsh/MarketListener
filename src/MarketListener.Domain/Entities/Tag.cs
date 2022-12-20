namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tag : Entity<int>
{
    public string Name { get; set; }
    public string PersianName { get; set; }
    public string Category { get; set; }
    public int ParentId { get; set; }
    public Tag Parent { get; set; }

}
