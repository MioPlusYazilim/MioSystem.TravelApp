using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwTransactionVisaDocumentStatus
{
    public long Id { get; set; }

    public long TransactionVisaId { get; set; }

    public long TransactionId { get; set; }

    public string? TransactionNo { get; set; }

    public string ApplicantName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string? VisaType { get; set; }

    public int LineNumber { get; set; }

    public int DocumentTypeId { get; set; }

    public string DocumentTypeCode { get; set; } = null!;

    public string DocumentTypeResourceKey { get; set; } = null!;

    public int RequirementStatusId { get; set; }

    public string RequirementStatusCode { get; set; } = null!;

    public string RequirementStatusResourceKey { get; set; } = null!;

    public long? DocumentId { get; set; }

    public string? DocumentNo { get; set; }

    public long? DocumentVersionId { get; set; }

    public int? VersionNo { get; set; }

    public string? OriginalFileName { get; set; }

    public string? FileExtension { get; set; }

    public long? FileSizeBytes { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public DateOnly? RequiredByDate { get; set; }

    public DateTime? RequestedAt { get; set; }

    public DateTime? ReceivedAt { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public DateTime? RejectedAt { get; set; }

    public string? RejectReason { get; set; }

    public string? Note { get; set; }
}
