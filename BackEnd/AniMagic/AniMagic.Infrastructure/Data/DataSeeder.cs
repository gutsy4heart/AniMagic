using AniMagic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Infrastructure.Data;

public static class DataSeeder
{
    public static void SeedData(AniMagicDbContext context)
    {
        // Ensure the roles exist in the database
        if (!context.Roles.Any())
        {
            var adminRole = new Roles("Admin");
            var userRole = new Roles("User");

            context.Roles.AddRange(adminRole, userRole);
            context.SaveChanges();
        }

        // Fetch roles from the database
        var adminRoleFromDb = context.Roles.FirstOrDefault(r => r.Name == "Admin");
        var userRoleFromDb = context.Roles.FirstOrDefault(r => r.Name == "User");

        // Ensure an admin user exists
        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "hashedpassword", // Replace with hashed password
                RoleId = adminRoleFromDb!.Id  // Assigning RoleId instead of Role.Name
            });

            context.SaveChanges();
        }
    }

}
