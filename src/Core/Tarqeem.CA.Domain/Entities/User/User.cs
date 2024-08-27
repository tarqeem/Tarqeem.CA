using Microsoft.AspNetCore.Identity;
using Tarqeem.CA.Domain.Common;

namespace Tarqeem.CA.Domain.Entities.User;

public class User:IdentityUser<int>,IEntity
{
    public User()
    {
        this.GeneratedCode = Guid.NewGuid().ToString().Substring(0, 8);
    }

    public string Name { get; set; }
    public string FamilyName { get; set; }
    public string GeneratedCode { get; set; }
       
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<UserLogin> Logins { get; set; }
    public ICollection<UserClaim> Claims { get; set; }
    public ICollection<UserToken> Tokens { get; set; }
    public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }

    #region Navigation Properties

    public IList<Order.Order> Orders { get; set; }

    #endregion

}