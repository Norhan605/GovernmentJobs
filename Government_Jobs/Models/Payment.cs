using System;
using System.Collections.Generic;

namespace Government_Jobs.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? PaymentMoney { get; set; }

    public string? ReferenceNum { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
