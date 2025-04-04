using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Contracts.Requests;

public class UserLoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
