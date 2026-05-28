using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class TransactionVisaDocument
{
    public long Id { get; set; }

    public long TransactionVisaId { get; set; }

    public int LineNumber { get; set; }

    public int DocumentTypeId { get; set; }

    public long? VisaDocumentRuleId { get; set; }

    public int RequirementStatusId { get; set; }

    public long? DocumentId { get; set; }

    public long? DocumentVersionId { get; set; }

    public DateOnly? RequiredByDate { get; set; }

    public DateTime? RequestedAt { get; set; }

    public DateTime? ReceivedAt { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public DateTime? RejectedAt { get; set; }

    public long? ApprovedByEmployeeId { get; set; }

    public long? RejectedByEmployeeId { get; set; }

    public string? RejectReason { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employee? ApprovedByEmployee { get; set; }

    public virtual Document? Document { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual DocumentVersion? DocumentVersion { get; set; }

    public virtual Employee? RejectedByEmployee { get; set; }

    public virtual SysLookupItem RequirementStatus { get; set; } = null!;

    public virtual TransactionVisa TransactionVisa { get; set; } = null!;

    public virtual VisaDocumentRule? VisaDocumentRule { get; set; }
}
