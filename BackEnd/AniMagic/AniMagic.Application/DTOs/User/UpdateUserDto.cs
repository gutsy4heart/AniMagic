using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Application.DTOs.User;

public class UpdateUserDto
{

    public required string Username { get; set; }


    [EmailAddress]
    public required string Email { get; set; }

    [MinLength(8)]
    public string? NewPassword { get; set; }
}
