using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Customer
{
    public long Id { get; set; }

    public string CustomerCode { get; set; } = null!;

    public long? CompanyId { get; set; }

    public string Title { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? TaxOffice { get; set; }

    public string? TaxNumber { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? MobilePhone { get; set; }

    public string? AddressLine { get; set; }

    public string? City { get; set; }

    public string? CountryCode { get; set; }

    public bool IsCorporate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillingPlanLine> BillingPlanLines { get; set; } = new List<BillingPlanLine>();

    public virtual ICollection<BillingPlan> BillingPlans { get; set; } = new List<BillingPlan>();

    public virtual Company? Company { get; set; }

    public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; } = new List<CurrentAccount>();

    public virtual ICollection<CustomerContactEmployment> CustomerContactEmployments { get; set; } = new List<CustomerContactEmployment>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();
}
