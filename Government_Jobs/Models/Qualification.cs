using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Qualification
{
    public int Id { get; set; }

    public string? Qualification1 { get; set; }

    public int? QualificationLevelId { get; set; }

    public int? GraduationYear { get; set; }

    public int? GradeId { get; set; }

    public decimal? Persentage { get; set; }

    public virtual Grade? Grade { get; set; }

    public virtual QualificationLevel? QualificationLevel { get; set; }

    public virtual ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();
}
