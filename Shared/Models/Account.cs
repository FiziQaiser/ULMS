using System;
using System.Collections.Generic;

namespace ULMS.Shared.Models;

public partial class Account
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Name { get; set; }
}
