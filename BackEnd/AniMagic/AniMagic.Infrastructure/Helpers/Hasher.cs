using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Infrastructure.Helpers;

public static class Hasher
{
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }

    public static bool VerifyPassword(string inputPassword, string storedHash)
    {
        string hashedInput = HashPassword(inputPassword);
        return hashedInput == storedHash;
    }
}
