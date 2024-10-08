﻿using Tarqeem.CA.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Tarqeem.CA.Application.Contracts.Identity;

public interface IAppUserManager
{
    Task<IdentityResult> CreateUser(User user);
    Task<bool> IsExistUser(string userName);
    Task<IdentityResult> VerifyUserCode(User user, string code);
    Task<string> GenerateOtpCode(User user);
    Task<SignInResult> AdminLogin(User user, string password);
    Task<User> GetByUserName(string userName);
    Task<User> GetUserByIdAsync(int userId);
    Task<List<User>> GetAllUsersAsync();
    Task<IdentityResult> CreateUserWithPasswordAsync(User user, string password);
    Task<IdentityResult> AddUserToRoleAsync(User user, Role role);
    Task<IdentityResult> IncrementAccessFailedCountAsync(User user);
    Task<bool> IsUserLockedOutAsync(User user);
    Task ResetUserLockoutAsync(User user);
    Task UpdateUserAsync(User user);
    Task UpdateSecurityStampAsync(User user);
}