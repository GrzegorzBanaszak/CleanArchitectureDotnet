using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastucture.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _datetimeprovider;
    private readonly JwtSettings _jwtsettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _datetimeprovider = dateTimeProvider;
        _jwtsettings = jwtSettings.Value;
    }
    public string GenerateToken(User user)
    {
        var singingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtsettings.Issuer,
            audience: _jwtsettings.Audience,
            expires: _datetimeprovider.UtcNow.AddMinutes(_jwtsettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: singingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
