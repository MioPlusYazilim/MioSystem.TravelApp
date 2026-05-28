using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class RequestOfferItem
{
    public long Id { get; set; }

    public long RequestOfferId { get; set; }

    public int ServiceTypeId { get; set; }

    public long? ProductId { get; set; }

    public long? ProviderCompanyId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public int CurrencyId { get; set; }

    public string? OptionGroupCode { get; set; }

    public int OptionOrder { get; set; }

    public bool IsSelected { get; set; }

    public string? ExternalReferenceNo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual Company? ProviderCompany { get; set; }

    public virtual RequestOffer RequestOffer { get; set; } = null!;

    public virtual SysLookupItem ServiceType { get; set; } = null!;

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();
}
