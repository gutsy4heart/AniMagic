﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Contracts.Requests;

public class UserRegisterRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    
}
