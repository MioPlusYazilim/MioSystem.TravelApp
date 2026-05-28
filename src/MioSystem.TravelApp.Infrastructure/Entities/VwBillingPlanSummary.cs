using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwBillingPlanSummary
{
    public long Id { get; set; }

    public string? PlanNo { get; set; }

    public long TransactionId { get; set; }

    public string? TransactionNo { get; set; }

    public long CustomerId { get; set; }

    public string CustomerTitle { get; set; } = null!;

    public int StatusId { get; set; }

    public string StatusCode { get; set; } = null!;

    public int DistributionMethodId { get; set; }

    public string DistributionMethodCode { get; set; } = null!;

    public int CurrencyId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal TotalPlanAmount { get; set; }

    public int? LineCount { get; set; }

    public decimal? DetailAmount { get; set; }
}
