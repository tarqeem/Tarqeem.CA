using Tarqeem.CA.Domain.Entities.User;
using Tarqeem.CA.Application.Profiles;

namespace Tarqeem.CA.Application.Features.Users.Queries.GetUsers;

public record GetUsersQueryResponse : ICreateMapper<User>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }
}