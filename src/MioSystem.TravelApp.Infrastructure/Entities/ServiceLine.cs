using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class ServiceLine
{
    public long Id { get; set; }

    public long ServiceLineNumberSequence { get; set; }

    public string? ServiceLineNumber { get; set; }

    public long TransactionId { get; set; }

    public long? TransactionLineId { get; set; }

    public int ServiceTypeId { get; set; }

    public long CustomerId { get; set; }

    public long? CustomerContactId { get; set; }

    public long? CustomerContactEmploymentId { get; set; }

    public long? ProviderCompanyId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? ServiceStartAt { get; set; }

    public DateTime? ServiceEndAt { get; set; }

    public decimal Quantity { get; set; }

    public int CurrencyId { get; set; }

    public decimal SaleAmount { get; set; }

    public decimal CostAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public bool IsBillable { get; set; }

    public bool IsInvoiced { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerContact? CustomerContact { get; set; }

    public virtual CustomerContactEmployment? CustomerContactEmployment { get; set; }

    public virtual Company? ProviderCompany { get; set; }

    public virtual ICollection<ServiceChargeLine> ServiceChargeLines { get; set; } = new List<ServiceChargeLine>();

    public virtual SysLookupItem ServiceType { get; set; } = null!;

    public virtual TransactionMaster Transaction { get; set; } = null!;

    public virtual TransactionLine? TransactionLine { get; set; }
}
