namespace MarketListener.Domain.Entities;

using MarketListener.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User : Entity<int>
{
    private User(int id, string firstName, string lastName, string? userName, string? normalizedUserName, string? email, string? normalizedEmail, bool emailConfirmed, string? passwordHash, string? securityStamp, string? concurrencyStamp, string? phoneNumber, bool phoneNumberConfirmed, bool twoFactorEnabled, DateTimeOffset? lockoutEnd, bool lockoutEnabled, int accessFailedCount)
    {
        Id = id; 
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        NormalizedUserName = normalizedUserName;
        Email = email;
        NormalizedEmail = normalizedEmail;
        EmailConfirmed = emailConfirmed;
        PasswordHash = passwordHash;
        SecurityStamp = securityStamp;
        ConcurrencyStamp = concurrencyStamp;
        PhoneNumber = phoneNumber;
        PhoneNumberConfirmed = phoneNumberConfirmed;
        TwoFactorEnabled = twoFactorEnabled;
        LockoutEnd = lockoutEnd;
        LockoutEnabled = lockoutEnabled;
        AccessFailedCount = accessFailedCount;
    }

    public static User Create(int id, string firstName, string lastName, string? userName, string? normalizedUserName, string? email, string? normalizedEmail, bool emailConfirmed, string? passwordHash, string? securityStamp, string? concurrencyStamp, string? phoneNumber, bool phoneNumberConfirmed, bool twoFactorEnabled, DateTimeOffset? lockoutEnd, bool lockoutEnabled, int accessFailedCount)
    {
        return new User(id, firstName, lastName, userName, normalizedUserName, email, normalizedEmail, emailConfirmed, passwordHash, securityStamp, concurrencyStamp, phoneNumber, phoneNumberConfirmed, twoFactorEnabled, lockoutEnd, lockoutEnabled, accessFailedCount); 
    }

    public string FirstName { get; set; } = default!;
    
    public string LastName { get; set; } = default!;

    public virtual string? UserName { get; set; }

    public virtual string? NormalizedUserName { get; set; }

    public virtual string? Email { get; set; }

    public virtual string? NormalizedEmail { get; set; }

    public virtual bool EmailConfirmed { get; set; }

    public virtual string? PasswordHash { get; set; }

    public virtual string? SecurityStamp { get; set; }

    public virtual string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

    public virtual string? PhoneNumber { get; set; }

    public virtual bool PhoneNumberConfirmed { get; set; }

    public virtual bool TwoFactorEnabled { get; set; }

    public virtual DateTimeOffset? LockoutEnd { get; set; }

    public virtual bool LockoutEnabled { get; set; }

    public virtual int AccessFailedCount { get; set; }
}
