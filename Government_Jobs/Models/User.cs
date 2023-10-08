using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public string? Lastname { get; set; }

    public string? Familyname { get; set; }

    public string? NumNationalId { get; set; }

    public string? Mothername { get; set; }

    public string? Password { get; set; }

    public int? AddressId { get; set; }

    public int? GenderId { get; set; }

    public int? GovernateId { get; set; }

    public string? Email { get; set; }

    public int? DisabilityTypeId { get; set; }

    public int? UserTypeId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<CopNationalId> CopNationalIds { get; set; } = new List<CopNationalId>();

    public virtual ICollection<CriminalRecord> CriminalRecords { get; set; } = new List<CriminalRecord>();

    public virtual DisabilitiesType? DisabilityType { get; set; }

    public virtual ICollection<EmploymentApplication> EmploymentApplications { get; set; } = new List<EmploymentApplication>();

    public virtual Gender? Gender { get; set; }

    public virtual Government? Governate { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<MobileNum> MobileNums { get; set; } = new List<MobileNum>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual UserType? UserType { get; set; }
}
