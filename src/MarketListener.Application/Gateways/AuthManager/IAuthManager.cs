namespace MarketListener.Application.Gateways.AuthManager;

using MarketListener.Application.Gateways.AuthManager.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAuthManager
{
    Task<LoginResponse?> Login(LoginRequest loginRequest);

    Task<IEnumerable<IdentityError>?> Register(RegisterRequest registerRequest); 
}
