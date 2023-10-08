using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class CategoryReqAd
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? GovernmentCategoryId { get; set; }

    public virtual GovernmentCategory? GovernmentCategory { get; set; }
}
