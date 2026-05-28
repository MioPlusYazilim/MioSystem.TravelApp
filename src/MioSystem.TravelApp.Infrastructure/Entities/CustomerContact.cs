using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class CustomerContact
{
    public long Id { get; set; }

    public string? ContactCode { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PersonalEmail { get; set; }

    public string? PersonalPhone { get; set; }

    public string? MobilePhone { get; set; }

    public string? IdentityNo { get; set; }

    public string? PassportNo { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Note { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual CustomerContactEmployment? CustomerContactEmployment { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();
}
