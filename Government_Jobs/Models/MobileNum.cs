using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class MobileNum
{
    public int Id { get; set; }

    public string? Mobile1 { get; set; }

    public string? Mobile2 { get; set; }

    public string? Mobile3 { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
