using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Models;

public static class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";

    public static bool IsValidRole(string role)
    {
        return role == Admin || role == User;
    }
}
