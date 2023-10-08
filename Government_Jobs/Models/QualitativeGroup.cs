using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class QualitativeGroup
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? JobGroupId { get; set; }

    public virtual JobGroup? JobGroup { get; set; }
}
