using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class DegreeProficiency
{
    public int Id { get; set; }

    public string? Degree { get; set; }

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
}
