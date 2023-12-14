using GymManager.Entities.Auth;
using GymManager.Entities.Dtos;

namespace GymManager.Entities.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthResult> Register(UserRegistrationDto registrationDto);

        Task<AuthResult> Login(UserLoginDto userLoginDto);

        Task<AuthResult> RefreshToken();

        Task<AuthResult> VerifyAndGenerateTokenAsync(TokenRequestDto tokenRequest);
    }
}