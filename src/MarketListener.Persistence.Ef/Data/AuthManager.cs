namespace MarketListener.Persistence.Ef.Data;

using MarketListener.Application.Gateways.AuthManager;
using MarketListener.Application.Gateways.AuthManager.Models;
using MarketListener.Domain.Common;
using MarketListener.Domain.Entities;
using MarketListener.Persistence.Ef.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class AuthManager : IAuthManager
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private ApplicationUser _identityUser;
    public AuthManager(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<LoginResponse?> Login(LoginRequest loginRequest)
    {
        _identityUser = await _userManager.FindByNameAsync(loginRequest.UserName);
        if (_identityUser == null)
        {
            return default;
        }

        bool isValidCredentials = await _userManager.CheckPasswordAsync(_identityUser, loginRequest.Password);
        if (!isValidCredentials)
        {
            return default;
        }

        var token = await GenerateTokenAsync();

        return new LoginResponse()
        {
            Token = token,
            FirstName = _identityUser.FirstName,
            LastName = _identityUser.LastName,
            UserId  = _identityUser.Id,
            UserName = _identityUser.UserName
        }; 

    }

    public async Task<IEnumerable<IdentityError>?> Register(RegisterRequest registerRequest)
    {
        _identityUser = new ApplicationUser() { 
            UserName = registerRequest.UserName,
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName            
        };

        var result = await _userManager.CreateAsync(_identityUser, registerRequest.Password); 

        if(result.Succeeded)
        {
            await _userManager.AddToRoleAsync(_identityUser, "User"); 
        }

        return result.Errors;
    }

    private async Task<string> GenerateTokenAsync()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var roles = await _userManager.GetRolesAsync(_identityUser);
        var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        var userClaims = await _userManager.GetClaimsAsync(_identityUser);

        var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Sub, _identityUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, _identityUser.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, _identityUser.UserName),
            new Claim(JwtRegisteredClaimNames.FamilyName, _identityUser.LastName),
            new Claim(JwtRegisteredClaimNames.Name, _identityUser.FirstName),
            new Claim(JwtRegisteredClaimNames.NameId, _identityUser.Id.ToString())
        }.Union(userClaims).Union(roleClaims);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires : DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
            signingCredentials : credentials
            ); 

        return new JwtSecurityTokenHandler().WriteToken(token); 
    }
}
