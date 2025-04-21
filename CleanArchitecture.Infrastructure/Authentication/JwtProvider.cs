using CleanArchitecture.Application.Abstraction;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<User> _userManager;
    public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> CreateToken(User user)
    {
        Claim[] claims =
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.NameSurname),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        };

        DateTime expires = DateTime.Now.AddHours(1);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256)
        );

        string securityToken = new JwtSecurityTokenHandler().WriteToken(token);

        user.RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        user.RefreshTokenExpires = expires.AddMinutes(15);

        await _userManager.UpdateAsync(user);

        return new LoginCommandResponse(user.Id,
            securityToken,
            user.RefreshToken,
            user.RefreshTokenExpires);
    }
}
