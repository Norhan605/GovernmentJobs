using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class JobInfo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Year { get; set; }

    public string? Description { get; set; }

    public int? Order { get; set; }

    public bool? Isarchived { get; set; }

    public bool? Isdeleted { get; set; }

    public string? Createdby { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool? IsSaved { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
