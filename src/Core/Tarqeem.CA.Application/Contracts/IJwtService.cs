using System.Security.Claims;
using Tarqeem.CA.Domain.Entities.User;
using Tarqeem.CA.Application.Models.Jwt;

namespace Tarqeem.CA.Application.Contracts;

public interface IJwtService
{
    Task<AccessToken> GenerateAsync(User user);
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    Task<AccessToken> RefreshToken(Guid refreshTokenId);
}