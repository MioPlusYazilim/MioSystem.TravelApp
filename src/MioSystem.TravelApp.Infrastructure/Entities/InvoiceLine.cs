using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class InvoiceLine
{
    public long Id { get; set; }

    public long InvoiceId { get; set; }

    public long? ServiceChargeLineId { get; set; }

    public long? BillingPlanLineDetailId { get; set; }

    public int LineNumber { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal LineTotal { get; set; }

    public int CurrencyId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BillingPlanLineDetail? BillingPlanLineDetail { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual ServiceChargeLine? ServiceChargeLine { get; set; }
}
