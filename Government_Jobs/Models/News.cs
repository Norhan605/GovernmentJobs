using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class News
{
    public int Id { get; set; }

    public string? LatestNews { get; set; }

    public string? InstructionsApplicants { get; set; }

    public string? Video { get; set; }

    public int? AdsId { get; set; }

    public virtual Ad? Ads { get; set; }

    public virtual ICollection<Medium> Media { get; set; } = new List<Medium>();
}
