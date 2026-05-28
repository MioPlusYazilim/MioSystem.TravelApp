using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class CustomerContactEmployment
{
    public long Id { get; set; }

    public long CustomerContactId { get; set; }

    public long CustomerId { get; set; }

    public long? CompanyId { get; set; }

    public string? Department { get; set; }

    public string? CostCenter { get; set; }

    public string? JobTitle { get; set; }

    public string? WorkEmail { get; set; }

    public string? WorkPhone { get; set; }

    public DateOnly EmploymentStartDate { get; set; }

    public DateOnly? EmploymentEndDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillingPlanLine> BillingPlanLines { get; set; } = new List<BillingPlanLine>();

    public virtual Company? Company { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerContact CustomerContact { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();
}
