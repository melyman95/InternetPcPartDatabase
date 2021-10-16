﻿using Microsoft.AspNetCore.Identity;

namespace InternetPcPartDatabase.Models
{
#nullable disable
    public static class IdentityHelper
    {
        public const string Administrator = "Administrator";
        public const string User = "User";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach(string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
