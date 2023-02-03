using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketListener.Domain.ValueObjects
{
    public class TagLabel
    {
        private TagLabel(string code)
        {
           Code = code;
        }

        public static TagLabel Create(string code)
        {
            return new TagLabel(code); 
        }
        public string Code { get; private set; }
    }
}
