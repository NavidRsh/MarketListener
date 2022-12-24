namespace MarketListener.Application.Gateways.AuthManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RegisterRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
public class RegisterResponse
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
