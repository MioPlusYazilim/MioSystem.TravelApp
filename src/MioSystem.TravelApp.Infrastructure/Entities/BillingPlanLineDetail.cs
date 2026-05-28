using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class BillingPlanLineDetail
{
    public long Id { get; set; }

    public long BillingPlanLineId { get; set; }

    public long ServiceChargeLineId { get; set; }

    public decimal? DistributionPercent { get; set; }

    public decimal DistributionAmount { get; set; }

    public int CurrencyId { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual BillingPlanLine BillingPlanLine { get; set; } = null!;

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

    public virtual ServiceChargeLine ServiceChargeLine { get; set; } = null!;
}
