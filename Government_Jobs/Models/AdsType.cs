using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class AdsType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Ad> Ads { get; set; } = new List<Ad>();
}
