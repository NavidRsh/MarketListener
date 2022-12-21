namespace MarketListener.Application.Common.Models;

using MarketListener.Domain.Enums.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cause
{
    public string Type { get; }

    public List<string> Field { get; }

    public List<object> Rows { get; }

    public Cause(string key)
    {
        Rows = new List<object>();
        Field = new List<string>();
        if (key.StartsWith("["))
        {
            string[] array = key.Split(".");
            string s = array[0].Replace("[", "").Replace("]", "");
            //Field.Add(array[1].ToCamelCase());
            Field.Add(array[1]);
            Rows.Add(int.Parse(s));
            Type = CauseType.GRID.ToString();
        }
        else
        {
            //Field.Add(key.ToCamelCase());
            Field.Add(key);
            Type = CauseType.FORM.ToString();
        }
    }

    public Cause(CauseType type, List<string> fields)
    {
        Type = type.ToString();
        Field = fields;
    }

    public Cause(CauseType type, List<string> fields, List<object> rows)
    {
        Type = type.ToString();
        Field = fields;
        Rows = rows;
    }
}
