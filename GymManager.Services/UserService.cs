using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GymManager.Entities;
using GymManager.Entities.Auth;
using GymManager.Entities.Common;
using GymManager.Entities.Config;
using GymManager.Entities.Dtos;
using GymManager.Entities.Enums;
using GymManager.Entities.Interfaces.Services;
using GymManager.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GymManager.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;
        private readonly GymManagerDbContext _context;
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public UserService(UserManager<IdentityUser> userManager, GymManagerDbContext context, IOptions<JwtConfig> jwtConfig,
                                        TokenValidationParameters tokenValidationParameters)
        {
            _jwtConfig = jwtConfig.Value;
            _userManager = userManager;
            _context = context;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<AuthResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(userLogin.Email);
                if (existingUser is null)
                {
                    return (new AuthResult
                    {
                        Errors = new List<string> { "Invalid payload" },
                        IsSuccessful = false
                    });
                }

                var checkUserAndPass = await _userManager.CheckPasswordAsync(existingUser, userLogin.Password);
                if (!checkUserAndPass)
                {
                    return (new AuthResult
                    {
                        Errors = new List<string> { "Credenciales invalidas." },
                        IsSuccessful = false
                    });
                }

                var token = GenerateTokenAsync(existingUser);

                return token.Result;
            }
            catch (Exception ex)
            {
                return (new AuthResult()
                {
                    IsSuccessful = false,
                    Errors = new List<string>() { "El usuario no ha podido iniciar sesión." }
                });
            }

        }

        public Task<AuthResult> RefreshToken()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult> Register(UserRegistrationDto userRegistration)
        {
            try
            {
                //Verify if Email exists
                var existingEmail = await _userManager.FindByEmailAsync(userRegistration.EmailAddress);
                if (existingEmail is not null)
                {
                    return (new AuthResult()
                    {
                        IsSuccessful = false,
                        Errors = new List<string>()
                    {
                        "El correo ingresado ya existe."
                    }
                    });
                }

                //create user
                var user = new IdentityUser()
                {
                    Email = userRegistration.EmailAddress,
                    UserName = userRegistration.EmailAddress,
                    EmailConfirmed = false // si no queremos confirmacion por corrreo, quitar esta prop.
                };

                var isCreated = await _userManager.CreateAsync(user, userRegistration.Password);
                if (isCreated.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, EnumRoles.Employee.ToString());

                    //var token = GenerateToken(user);
                    return (new AuthResult()
                    {
                        IsSuccessful = true,
                    });
                }
                else
                {
                    var errors = new List<string>();
                    foreach (var err in isCreated.Errors)
                    {
                        errors.Add(err.Description);
                    }
                    return (new AuthResult()
                    {
                        IsSuccessful = false,
                        Errors = errors
                    });
                }
            }
            catch (Exception ex)
            {
                return (new AuthResult()
                {
                    IsSuccessful = false,
                    Errors = new List<string>() { "El usuario no pudo ser creado." }
                });
            }
        }

        private async Task<AuthResult> GenerateTokenAsync(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                })),
                Expires = DateTime.UtcNow.Add(_jwtConfig.ExpiryTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                Token = RandomGenerator.GenerateRandomString(23),
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(1),
                IsRevoked = false,
                IsUsed = false,
                UserId = user.Id
            };
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResult
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token,
                IsSuccessful = true
            };
        }

        public async Task<AuthResult> VerifyAndGenerateTokenAsync(TokenRequestDto tokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                _tokenValidationParameters.ValidateLifetime = false;

                var tokenBeingVerified = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                        StringComparison.InvariantCultureIgnoreCase);

                    if (!result || tokenBeingVerified == null)
                        throw new Exception("Invalid Token");
                }

                var utcExpiryDate = long.Parse(tokenBeingVerified.Claims.
                                        FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = DateTimeOffset.FromUnixTimeSeconds(utcExpiryDate).UtcDateTime;
                if (expiryDate < DateTime.UtcNow)
                    throw new Exception("Token Expired");

                var storedToken = await _context.RefreshTokens.
                        FirstOrDefaultAsync(t => t.Token == tokenRequest.RefreshToken);
                if (storedToken == null)
                    throw new Exception("Invalid Token");

                if (storedToken.IsUsed || storedToken.IsRevoked)
                    throw new Exception("Invalid Token");

                var jti = tokenBeingVerified.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value;

                if (jti != storedToken.JwtId)
                    throw new Exception("Invalid Token");

                if (storedToken.ExpiryDate < DateTime.UtcNow)
                    throw new Exception("Token Expired");

                storedToken.IsUsed = true;
                _context.RefreshTokens.Update(storedToken);
                await _context.SaveChangesAsync();

                var dbUser = await _userManager.FindByIdAsync(storedToken.UserId);

                return await GenerateTokenAsync(dbUser);
            }
            catch (Exception e)
            {
                var message = e.Message == "Invalid Token" || e.Message == "Token Expired"
                    ? e.Message
                    : "Internal Server Error";
                return new AuthResult() { IsSuccessful = false, Errors = new List<string> { message } };
            }
        }

    }
}

