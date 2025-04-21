using AutoMapper;
using CleanArchitecture.Application.Abstraction;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace CleanArchitecture.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IJwtProvider _jwtProvider;
    public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
    }

    public async Task Register(RegisterCommand command)
    {
        User user = _mapper.Map<User>(command);

        IdentityResult result = await _userManager.CreateAsync(user, command.Password);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);

        await _mailService.SendRegistrationEmail(command.Email, command.NameSurname);
        await SendConfirmEmail(user.Id);
    }
    public async Task SendConfirmEmail(string id)
    {
        User user = await _userManager.FindByIdAsync(id);
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        token = HttpUtility.UrlEncode(token);

        await _mailService.SendConfirmationEmail(user.Email, user.NameSurname, id, token);
    }

    public async Task ConfirmEmail(string userId, string token)
    {
        User user = await _userManager.FindByIdAsync(userId);
        bool verifiedUserToken = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.EmailConfirmationTokenProvider, "EmailConfirmation", token);
        IdentityResult confirmEmailResult = await _userManager.ConfirmEmailAsync(user, token);

        if(confirmEmailResult.Succeeded && verifiedUserToken)
        {
            IdentityResult updateSecurityStampResult = await _userManager.UpdateSecurityStampAsync(user);
            if(updateSecurityStampResult.Succeeded)
                return;

            throw new Exception(updateSecurityStampResult.Errors.First().Description);
        }

        if (verifiedUserToken)
            throw new Exception(confirmEmailResult.Errors.First().Description);
        else
            throw new Exception("Provided token is not correct!");
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User user = await _userManager.Users.Where(u => u.Email == request.UsernameOrEmail || u.UserName == request.UsernameOrEmail)
               .FirstOrDefaultAsync();

        if (user == null) throw new Exception("User could not found!");

        bool result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (result)
        {
            return await _jwtProvider.CreateToken(user);
        }

        throw new Exception("Username or password incorrect!");
    }

    public async Task<LoginCommandResponse> CreateNewTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) throw new Exception("User could not found!");

        if(user.RefreshToken == request.RefreshToken)
        {
            if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("Refresh token expired!");

            return await _jwtProvider.CreateToken(user);
        }

        throw new Exception("Invalid refresh token!");
    }
}