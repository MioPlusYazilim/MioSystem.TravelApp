using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Invoice
{
    public long Id { get; set; }

    public long InvoiceNoSequence { get; set; }

    public string? InvoiceNo { get; set; }

    public long? InvoiceBatchId { get; set; }

    public long? BillingPlanId { get; set; }

    public long? BillingPlanLineId { get; set; }

    public long CustomerId { get; set; }

    public int InvoiceTypeId { get; set; }

    public int StatusId { get; set; }

    public int CurrencyId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? ScenarioCode { get; set; }

    public Guid? EinvoiceUuid { get; set; }

    public decimal SubTotalAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual BillingPlan? BillingPlan { get; set; }

    public virtual BillingPlanLine? BillingPlanLine { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual ICollection<CurrentAccountTransaction> CurrentAccountTransactions { get; set; } = new List<CurrentAccountTransaction>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual InvoiceBatch? InvoiceBatch { get; set; }

    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

    public virtual SysLookupItem InvoiceType { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual SysLookupItem Status { get; set; } = null!;
}
