﻿using Tarqeem.CA.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Tarqeem.CA.Infrastructure.Identity.Identity.Manager;

namespace Tarqeem.CA.Infrastructure.Identity.Identity.SeedDatabaseService;

public interface ISeedDataBase
{
    Task Seed();
}

public class SeedDataBase : ISeedDataBase
{
    private readonly AppUserManager _userManager;
    private readonly AppRoleManager _roleManager;

    public SeedDataBase(AppUserManager userManager, AppRoleManager roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task Seed()
    {
        if (!_roleManager.Roles.AsNoTracking().Any(r => r.Name.Equals("admin")))
        {
            var role=new Role
            {
                Name = "admin",
            };
            await _roleManager.CreateAsync(role);
        }

        if (!_userManager.Users.AsNoTracking().Any(u => u.UserName.Equals("admin")))
        {
            var user = new User
            {
                UserName = "admin",
                Email = "admin@site.com",
            };

            await  _userManager.CreateAsync(user, "qw123321");
            await _userManager.AddToRoleAsync(user,"admin");
        }
    }
}
