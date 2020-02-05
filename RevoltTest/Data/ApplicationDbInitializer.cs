using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoltTest.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            AddUser("mandao@obchod.cz", "mandao", "RevoltCityTest1234_", userManager);
            AddUser("morgrimesg@gmail.com", "gmail", "RevoltCityTest1234_", userManager);
        }

        public static void AddUser(string email, string userName, string password, UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync(email).Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = userName,
                    Email = email
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
