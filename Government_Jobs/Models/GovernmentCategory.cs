using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class GovernmentCategory
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Ad> Ads { get; set; } = new List<Ad>();

    public virtual ICollection<CategoryReqAd> CategoryReqAds { get; set; } = new List<CategoryReqAd>();

    public virtual ICollection<LastExperience> LastExperiences { get; set; } = new List<LastExperience>();
}
