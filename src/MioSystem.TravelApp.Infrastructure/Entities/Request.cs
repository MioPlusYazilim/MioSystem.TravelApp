using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Request
{
    public long Id { get; set; }

    public long RequestNoSequence { get; set; }

    public string? RequestNo { get; set; }

    public long? CompanyId { get; set; }

    public long CustomerId { get; set; }

    public long? CustomerContactId { get; set; }

    public long? CustomerContactEmploymentId { get; set; }

    public int ChannelId { get; set; }

    public int RequestTypeId { get; set; }

    public int StatusId { get; set; }

    public long? AssignedEmployeeId { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public string Subject { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? RequestedStartDate { get; set; }

    public DateTime? RequestedEndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Employee? AssignedEmployee { get; set; }

    public virtual SysLookupItem Channel { get; set; } = null!;

    public virtual Company? Company { get; set; }

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerContact? CustomerContact { get; set; }

    public virtual CustomerContactEmployment? CustomerContactEmployment { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual RequestAssignment? RequestAssignment { get; set; }

    public virtual ICollection<RequestNote> RequestNotes { get; set; } = new List<RequestNote>();

    public virtual ICollection<RequestOffer> RequestOffers { get; set; } = new List<RequestOffer>();

    public virtual ICollection<RequestStatusHistory> RequestStatusHistories { get; set; } = new List<RequestStatusHistory>();

    public virtual SysLookupItem RequestType { get; set; } = null!;

    public virtual SysLookupItem Status { get; set; } = null!;

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();
}
