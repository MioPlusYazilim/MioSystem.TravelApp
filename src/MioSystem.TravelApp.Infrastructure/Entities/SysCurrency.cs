using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class SysCurrency
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Symbol { get; set; }

    public int SortOrder { get; set; }

    public bool IsDefault { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<BillingPlanLineDetail> BillingPlanLineDetails { get; set; } = new List<BillingPlanLineDetail>();

    public virtual ICollection<BillingPlanLine> BillingPlanLines { get; set; } = new List<BillingPlanLine>();

    public virtual ICollection<BillingPlan> BillingPlans { get; set; } = new List<BillingPlan>();

    public virtual ICollection<CurrentAccountTransaction> CurrentAccountTransactions { get; set; } = new List<CurrentAccountTransaction>();

    public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; } = new List<CurrentAccount>();

    public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<RequestOfferItem> RequestOfferItems { get; set; } = new List<RequestOfferItem>();

    public virtual ICollection<RequestOffer> RequestOffers { get; set; } = new List<RequestOffer>();

    public virtual ICollection<ServiceChargeLine> ServiceChargeLines { get; set; } = new List<ServiceChargeLine>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();
}
