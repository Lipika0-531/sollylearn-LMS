using Microsoft.AspNetCore.Identity;

namespace SollyLearn.API.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
