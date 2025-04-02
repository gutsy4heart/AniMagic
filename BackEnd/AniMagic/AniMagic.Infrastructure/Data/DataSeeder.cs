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
        // Проверяем, если в базе данных еще нет ролей, добавляем их
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Roles("Admin"),
                new Roles("User")
            );
            context.SaveChanges();
        }

        // Проверяем, если в базе данных нет пользователей, добавляем администратора
        if (!context.Users.Any())
        {
            var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");

            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "hashedpassword",  // Это должно быть хэшированное значение пароля
                RoleId = adminRole.Id
            });

            context.SaveChanges();
        }

    }
}
