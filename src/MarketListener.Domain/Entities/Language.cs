using MarketListener.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MarketListener.Domain.Entities
{
    public class Language : Entity<int>
    {

        private Language(int id) : base(id)
        { }

        private Language() : base()
        { }
        public static Language Create(int? id, string name, string code)
        {
            if (id != null)
            {
                return new Language(id.Value) { Name = name, Code = code };
            }
            else
            {
                return new Language() { Name = name, Code = code };
            }            
        }

        public string Name { get; private set; } = String.Empty;

        public string Code { get; private set; } = String.Empty;
    }
}
