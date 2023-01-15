namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tag : Entity<int>
{
    private Tag(int id) : base(id)
    { }
    private Tag() : base() { }
    public static Tag Create(int? id, string name, string persianName, string category, int? parentId)
    {
        if (id != null)
        {
            return new Tag(id.Value)
            {
                Name = name,
                PersianName = persianName,
                Category = category,
                ParentId = parentId
            };
        }

        return new Tag()
        {
            Name = name,
            PersianName = persianName,
            Category = category,
            ParentId = parentId
        };

    }
    public string Name { get; private set; }
    public string PersianName { get; private set; }
    public string Category { get; private set; }
    public int? ParentId { get; private set; }
    public Tag? Parent { get; private set; }

}
