using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Company
{
    public long Id { get; set; }

    public string CompanyCode { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? ShortTitle { get; set; }

    public string? TaxOffice { get; set; }

    public string? TaxNumber { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? AddressLine { get; set; }

    public string? City { get; set; }

    public string? CountryCode { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; } = new List<CurrentAccount>();

    public virtual ICollection<CustomerContactEmployment> CustomerContactEmployments { get; set; } = new List<CustomerContactEmployment>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<RequestOfferItem> RequestOfferItems { get; set; } = new List<RequestOfferItem>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();
}
