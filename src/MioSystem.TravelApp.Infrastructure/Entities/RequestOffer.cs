using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class RequestOffer
{
    public long Id { get; set; }

    public long OfferNoSequence { get; set; }

    public string? OfferNo { get; set; }

    public long RequestId { get; set; }

    public int StatusId { get; set; }

    public int CurrencyId { get; set; }

    public long? PreparedByEmployeeId { get; set; }

    public DateTime OfferDate { get; set; }

    public DateTime? ValidUntil { get; set; }

    public string? CustomerNote { get; set; }

    public string? InternalNote { get; set; }

    public decimal SubTotalAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal ServiceFeeAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? AcceptedAt { get; set; }

    public DateTime? RejectedAt { get; set; }

    public DateTime? ConvertedToSaleAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual SysCurrency Currency { get; set; } = null!;

    public virtual Employee? PreparedByEmployee { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual Request Request { get; set; } = null!;

    public virtual ICollection<RequestOfferItem> RequestOfferItems { get; set; } = new List<RequestOfferItem>();

    public virtual ICollection<RequestOfferStatusHistory> RequestOfferStatusHistories { get; set; } = new List<RequestOfferStatusHistory>();

    public virtual SysLookupItem Status { get; set; } = null!;

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();
}
