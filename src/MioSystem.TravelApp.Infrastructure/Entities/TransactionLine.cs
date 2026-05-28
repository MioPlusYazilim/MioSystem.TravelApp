using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class TransactionLine
{
    public long Id { get; set; }

    public long TransactionId { get; set; }

    public long? SourceRequestOfferItemId { get; set; }

    public int ServiceTypeId { get; set; }

    public long? ProviderCompanyId { get; set; }

    public long? CustomerContactId { get; set; }

    public long? CustomerContactEmploymentId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitSalePrice { get; set; }

    public decimal UnitCostPrice { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public decimal TotalSaleAmount { get; set; }

    public decimal TotalCostAmount { get; set; }

    public int CurrencyId { get; set; }

    public string? ExternalReferenceNo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual CustomerContact? CustomerContact { get; set; }

    public virtual CustomerContactEmployment? CustomerContactEmployment { get; set; }

    public virtual Company? ProviderCompany { get; set; }

    public virtual ICollection<ServiceChargeLine> ServiceChargeLines { get; set; } = new List<ServiceChargeLine>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual SysLookupItem ServiceType { get; set; } = null!;

    public virtual RequestOfferItem? SourceRequestOfferItem { get; set; }

    public virtual TransactionMaster Transaction { get; set; } = null!;

    public virtual ICollection<TransactionFlightTicket> TransactionFlightTickets { get; set; } = new List<TransactionFlightTicket>();

    public virtual ICollection<TransactionHotel> TransactionHotels { get; set; } = new List<TransactionHotel>();

    public virtual ICollection<TransactionRentAcar> TransactionRentAcars { get; set; } = new List<TransactionRentAcar>();

    public virtual ICollection<TransactionTransfer> TransactionTransfers { get; set; } = new List<TransactionTransfer>();

    public virtual ICollection<TransactionVisa> TransactionVisas { get; set; } = new List<TransactionVisa>();
}
