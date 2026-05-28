using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Document
{
    public long Id { get; set; }

    public long DocumentNoSequence { get; set; }

    public string? DocumentNo { get; set; }

    public int DocumentTypeId { get; set; }

    public long? OwnerCustomerId { get; set; }

    public long? OwnerCustomerContactId { get; set; }

    public long? OwnerCompanyId { get; set; }

    public string Title { get; set; } = null!;

    public string? ExternalDocumentNo { get; set; }

    public string? IssuingCountryCode { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public int StatusId { get; set; }

    public int? VerificationStatusId { get; set; }

    public bool IsReusable { get; set; }

    public bool IsConfidential { get; set; }

    public string? Tags { get; set; }

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public long? VerifiedByEmployeeId { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual ICollection<DocumentAccessLog> DocumentAccessLogs { get; set; } = new List<DocumentAccessLog>();

    public virtual ICollection<DocumentEntityLink> DocumentEntityLinks { get; set; } = new List<DocumentEntityLink>();

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual DocumentVersion? DocumentVersion { get; set; }

    public virtual Company? OwnerCompany { get; set; }

    public virtual Customer? OwnerCustomer { get; set; }

    public virtual CustomerContact? OwnerCustomerContact { get; set; }

    public virtual SysLookupItem Status { get; set; } = null!;

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocuments { get; set; } = new List<TransactionVisaDocument>();

    public virtual SysLookupItem? VerificationStatus { get; set; }

    public virtual Employee? VerifiedByEmployee { get; set; }
}
