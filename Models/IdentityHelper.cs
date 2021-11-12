using Microsoft.AspNetCore.Identity;

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
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            // if no users are present, make default user
            int numberOfUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            if (numberOfUsers == 0)
            {
                var defaultUser = new IdentityUser()
                {
                    Email = "admin@admin.com",
                    UserName = "Admin"
                };
                await userManager.CreateAsync(defaultUser, "Iamanadmin");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }
    }
}
