using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Government
{
    public int Id { get; set; }

    public string? Government1 { get; set; }

    public virtual ICollection<GrievancesDetail> GrievancesDetails { get; set; } = new List<GrievancesDetail>();

    public virtual ICollection<JobDetailsOffer> JobDetailsOffers { get; set; } = new List<JobDetailsOffer>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
