using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class AdsStatus
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Ad> Ads { get; set; } = new List<Ad>();
}
