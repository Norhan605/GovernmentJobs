using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Ad
{
    public int Id { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime? StartDate { get; set; }

    public string? LinkDetails { get; set; }

    public DateTime? ExtendAdsPeriod { get; set; }

    public string? ImportantNotes { get; set; }

    public int? AdsStatusId { get; set; }

    public string? LogoImg { get; set; }

    public string? AdsMinisttry { get; set; }

    public bool? Isopend { get; set; }

    public string? CaoaHelp { get; set; }

    public string? RefuseNote { get; set; }

    public string? UpdateNote { get; set; }

    public string? Notes { get; set; }

    public bool? IsCentralAdd { get; set; }

    public int? AdsTypeId { get; set; }

    public int? AdsDocumentsId { get; set; }

    public int? ContactId { get; set; }

    public int? GovernmentCategoryId { get; set; }

    public virtual AdsDocument? AdsDocuments { get; set; }

    public virtual AdsStatus? AdsStatus { get; set; }

    public virtual AdsType? AdsType { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual GovernmentCategory? GovernmentCategory { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
