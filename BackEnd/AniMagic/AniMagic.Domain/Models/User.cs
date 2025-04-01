using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AniMagic.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = Roles.User; // "User" or "Admin"

    //public List<Favorite> Favorites { get; set; } = new();
    //public List<Rating> Ratings { get; set; } = new();
    //public List<Comment> Comments { get; set; } = new();

}
