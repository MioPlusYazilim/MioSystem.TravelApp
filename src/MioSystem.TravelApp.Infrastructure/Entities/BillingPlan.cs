using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class BillingPlan
{
    public long Id { get; set; }

    public long PlanNoSequence { get; set; }

    public string? PlanNo { get; set; }

    public long TransactionId { get; set; }

    public long? ProjectId { get; set; }

    public long CustomerId { get; set; }

    public int StatusId { get; set; }

    public int DistributionMethodId { get; set; }

    public int CurrencyId { get; set; }

    public string? BillingNote { get; set; }

    public decimal TotalPlanAmount { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public long? ApprovedByEmployeeId { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? ApprovedByEmployee { get; set; }

    public virtual ICollection<BillingPlanLine> BillingPlanLines { get; set; } = new List<BillingPlanLine>();

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual SysLookupItem DistributionMethod { get; set; } = null!;

    public virtual ICollection<InvoiceBatch> InvoiceBatches { get; set; } = new List<InvoiceBatch>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Project? Project { get; set; }

    public virtual SysLookupItem Status { get; set; } = null!;

    public virtual TransactionMaster Transaction { get; set; } = null!;
}
