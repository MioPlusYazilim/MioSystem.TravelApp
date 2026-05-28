using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class ServiceChargeLine
{
    public long Id { get; set; }

    public long ServiceLineId { get; set; }

    public long? TransactionLineId { get; set; }

    public int ChargeTypeId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitAmount { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public int CurrencyId { get; set; }

    public bool IsBillable { get; set; }

    public bool IsInvoiced { get; set; }

    public string? SourceReferenceNo { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillingPlanLineDetail> BillingPlanLineDetails { get; set; } = new List<BillingPlanLineDetail>();

    public virtual SysLookupItem ChargeType { get; set; } = null!;

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

    public virtual ServiceLine ServiceLine { get; set; } = null!;

    public virtual TransactionLine? TransactionLine { get; set; }
}
