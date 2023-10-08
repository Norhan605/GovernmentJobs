using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class AdsDocument
{
    public int Id { get; set; }

    public string? Documents { get; set; }

    public virtual ICollection<Ad> Ads { get; set; } = new List<Ad>();
}
