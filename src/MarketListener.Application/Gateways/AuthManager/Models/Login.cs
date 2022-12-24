namespace MarketListener.Application.Gateways.AuthManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class LoginResponse
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Token { get; set; }
}
