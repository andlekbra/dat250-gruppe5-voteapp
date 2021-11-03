using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteApp.DataAccess;
using VoteApp.DataAccess.Entities;
using VoteApp.Shared;

namespace VoteApp.Server.Service
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_db.Database.GetPendingMigrations().Any())
            {
                _db.Database.Migrate();
            }

            if (_db.Roles.Any(x => x.Name == SD.Role_Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Voter)).GetAwaiter().GetResult();

            _userManager.CreateAsync(
                new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "andlekbra@outlook.com",
                    EmailConfirmed = true,
                }, "Admin123!").GetAwaiter().GetResult();

            ApplicationUser user = _userManager.Users.FirstOrDefault(u => u.UserName == "admin");
            _userManager.AddToRoleAsync(user, SD.Role_Admin);
        }
    }
}
