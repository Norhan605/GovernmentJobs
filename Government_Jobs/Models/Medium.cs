using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Medium
{
    public int Id { get; set; }

    public string? Media { get; set; }

    public int? NewsId { get; set; }

    public virtual News? News { get; set; }
}
