using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwTransactionList
{
    public long Id { get; set; }

    public string? TransactionNo { get; set; }

    public DateTime TransactionDate { get; set; }

    public long CustomerId { get; set; }

    public string CustomerTitle { get; set; } = null!;

    public int StatusId { get; set; }

    public string StatusCode { get; set; } = null!;

    public string StatusResourceKey { get; set; } = null!;

    public int TransactionTypeId { get; set; }

    public string TransactionTypeCode { get; set; } = null!;

    public string TransactionTypeResourceKey { get; set; } = null!;

    public int? MainServiceTypeId { get; set; }

    public string? MainServiceTypeCode { get; set; }

    public int CurrencyId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal TotalSaleAmount { get; set; }

    public decimal TotalCostAmount { get; set; }

    public decimal? ProfitAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public long? SourceRequestId { get; set; }

    public long? SourceOfferId { get; set; }
}
