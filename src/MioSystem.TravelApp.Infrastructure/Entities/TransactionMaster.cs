using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class TransactionMaster
{
    public long Id { get; set; }

    public long TransactionNoSequence { get; set; }

    public string? TransactionNo { get; set; }

    public long? CompanyId { get; set; }

    public long CustomerId { get; set; }

    public long? CustomerContactId { get; set; }

    public long? CustomerContactEmploymentId { get; set; }

    public long? SourceRequestId { get; set; }

    public long? SourceOfferId { get; set; }

    public int TransactionTypeId { get; set; }

    public int StatusId { get; set; }

    public int? MainServiceTypeId { get; set; }

    public int CurrencyId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string? Description { get; set; }

    public decimal TotalSaleAmount { get; set; }

    public decimal TotalCostAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<BillingPlan> BillingPlans { get; set; } = new List<BillingPlan>();

    public virtual Company? Company { get; set; }

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerContact? CustomerContact { get; set; }

    public virtual CustomerContactEmployment? CustomerContactEmployment { get; set; }

    public virtual SysLookupItem? MainServiceType { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual RequestOffer? SourceOffer { get; set; }

    public virtual Request? SourceRequest { get; set; }

    public virtual SysLookupItem Status { get; set; } = null!;

    public virtual ICollection<TransactionFlightTicket> TransactionFlightTickets { get; set; } = new List<TransactionFlightTicket>();

    public virtual ICollection<TransactionHotel> TransactionHotels { get; set; } = new List<TransactionHotel>();

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public virtual ICollection<TransactionRentAcar> TransactionRentAcars { get; set; } = new List<TransactionRentAcar>();

    public virtual ICollection<TransactionTransfer> TransactionTransfers { get; set; } = new List<TransactionTransfer>();

    public virtual SysLookupItem TransactionType { get; set; } = null!;

    public virtual ICollection<TransactionVisa> TransactionVisas { get; set; } = new List<TransactionVisa>();
}
