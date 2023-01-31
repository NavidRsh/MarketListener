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
    public static Tag Create(int? id, string name, string persianName, string code, string category, int? parentId)
    {
        var tag = new Tag()
        {
            Code = code,
            Name = name,
            PersianName = persianName,
            Category = category,
            ParentId = parentId
        };

        if (id != null)
            tag.Id = id.Value;

        return tag;
    }
    public string Name { get; private set; }
    public string PersianName { get; private set; }
    public string Code { get; private set; }
    public string Category { get; private set; }
    public int? ParentId { get; private set; }
    public Tag? Parent { get; private set; }

}
