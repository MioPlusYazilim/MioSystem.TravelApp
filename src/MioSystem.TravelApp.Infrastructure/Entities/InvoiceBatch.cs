using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class InvoiceBatch
{
    public long Id { get; set; }

    public long BatchNoSequence { get; set; }

    public string? BatchNo { get; set; }

    public long? BillingPlanId { get; set; }

    public int StatusId { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BillingPlan? BillingPlan { get; set; }

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual SysLookupItem Status { get; set; } = null!;
}
