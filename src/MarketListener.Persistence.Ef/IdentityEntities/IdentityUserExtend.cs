namespace MarketListener.Persistence.Ef.IdentityEntities;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IdentityUserExtend : IdentityUser<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
