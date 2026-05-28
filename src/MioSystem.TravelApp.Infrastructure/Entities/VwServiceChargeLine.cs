using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwServiceChargeLine
{
    public long Id { get; set; }

    public string? ServiceLineNumber { get; set; }

    public long TransactionId { get; set; }

    public string? TransactionNo { get; set; }

    public long CustomerId { get; set; }

    public string CustomerTitle { get; set; } = null!;

    public int ServiceTypeId { get; set; }

    public string ServiceTypeCode { get; set; } = null!;

    public int ChargeTypeId { get; set; }

    public string ChargeTypeCode { get; set; } = null!;

    public string ChargeTypeResourceKey { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitAmount { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public int CurrencyId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public bool IsBillable { get; set; }

    public bool IsInvoiced { get; set; }
}
