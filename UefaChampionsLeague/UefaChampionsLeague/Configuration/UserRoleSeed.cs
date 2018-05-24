using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UefaChampionsLeague.Models;

namespace UefaChampionsLeague.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleSeed(RoleManager<IdentityRole>roleManager)
        {
            _roleManager = roleManager;
        }
        public async void UserRoles()
        {
            if (await _roleManager.FindByNameAsync("Admin")==null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if (await _roleManager.FindByNameAsync("UefaUser")==null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "UefaUser" });
            }
        }
    }
}
