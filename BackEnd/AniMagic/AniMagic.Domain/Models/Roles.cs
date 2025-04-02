using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniMagic.Domain.Models;

public class Roles
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    // Конструктор для удобства создания ролей
    public Roles(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
