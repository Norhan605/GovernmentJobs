using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Message
{
    public int Id { get; set; }

    public string? Message1 { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
