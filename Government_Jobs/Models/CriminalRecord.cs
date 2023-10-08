using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class CriminalRecord
{
    public int Id { get; set; }

    public string? CriminalRecord1 { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<JobDocument> JobDocuments { get; set; } = new List<JobDocument>();

    public virtual User? User { get; set; }
}
