using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class BillingPlanLine
{
    public long Id { get; set; }

    public long BillingPlanId { get; set; }

    public long BillToCustomerId { get; set; }

    public long? BillToCustomerContactEmploymentId { get; set; }

    public decimal? DistributionPercent { get; set; }

    public decimal? DistributionAmount { get; set; }

    public int CurrencyId { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Department { get; set; }

    public string? CostCenter { get; set; }

    public string? Note { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer BillToCustomer { get; set; } = null!;

    public virtual CustomerContactEmployment? BillToCustomerContactEmployment { get; set; }

    public virtual BillingPlan BillingPlan { get; set; } = null!;

    public virtual ICollection<BillingPlanLineDetail> BillingPlanLineDetails { get; set; } = new List<BillingPlanLineDetail>();

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
