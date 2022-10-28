using Triapp.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace Triapp.Server
{
    public class IntitializeDb
    {
        public static void SeedData
    (UserManager<IdentityUser> userManager,
    RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }



        public static void SeedUsers
    (UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync
                   ("teacher@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "teacher@gmail.com";
                user.Email = "teacher@gmail.com";
                user.EmailConfirmed = true;
                user.Role = "Teacher";
                IdentityResult result = userManager.CreateAsync
                (user, "Teacher12!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Teacher").Wait();
                }
            }

            if (userManager.FindByNameAsync
                  ("esther@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "esther@gmail.com";
                user.Email = "esther@gmail.com";
                user.EmailConfirmed = true;
                user.Role = "Admin";
                IdentityResult result = userManager.CreateAsync
                (user, "Osakweesther12!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }


            if (userManager.FindByNameAsync
                   ("solomon").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "olafire03@gmail.com";
                user.Email = "olafire03@gmail.com";
                user.EmailConfirmed = true;
                user.Role = "Admin";
                IdentityResult result = userManager.CreateAsync
                (user, "Solomon12!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }



        public static void SeedRoles
    (RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync
               ("User").Result)
            {
                Role role = new Role();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
                ("Admin").Result)
            {
                Role role = new Role();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync
               ("Teacher").Result)
            {
                Role role = new Role();
                role.Name = "Teacher";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

    }
}
