using Microsoft.AspNetCore.Identity;

namespace MedicalAppAPI.Repos.Token
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
