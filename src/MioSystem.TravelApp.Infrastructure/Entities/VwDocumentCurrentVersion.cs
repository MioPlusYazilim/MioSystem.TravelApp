using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class VwDocumentCurrentVersion
{
    public long Id { get; set; }

    public string? DocumentNo { get; set; }

    public int DocumentTypeId { get; set; }

    public string DocumentTypeCode { get; set; } = null!;

    public string DocumentTypeResourceKey { get; set; } = null!;

    public long? OwnerCustomerId { get; set; }

    public string? OwnerCustomerTitle { get; set; }

    public long? OwnerCustomerContactId { get; set; }

    public string? OwnerContactName { get; set; }

    public long? OwnerCompanyId { get; set; }

    public string? OwnerCompanyTitle { get; set; }

    public string Title { get; set; } = null!;

    public string? ExternalDocumentNo { get; set; }

    public string? IssuingCountryCode { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public int StatusId { get; set; }

    public string StatusCode { get; set; } = null!;

    public string StatusResourceKey { get; set; } = null!;

    public int? VerificationStatusId { get; set; }

    public string? VerificationStatusCode { get; set; }

    public bool IsReusable { get; set; }

    public bool IsConfidential { get; set; }

    public bool IsDeleted { get; set; }

    public long? CurrentDocumentVersionId { get; set; }

    public int? VersionNo { get; set; }

    public DateTime? UploadedAt { get; set; }

    public long? DocumentBlobId { get; set; }

    public string? BlobNo { get; set; }

    public int? StorageProviderId { get; set; }

    public string? StorageProviderCode { get; set; }

    public string? StorageContainer { get; set; }

    public string? StorageRelativePath { get; set; }

    public string? StorageObjectKey { get; set; }

    public string? StoredFileName { get; set; }

    public string? OriginalFileName { get; set; }

    public string? FileExtension { get; set; }

    public string? MimeType { get; set; }

    public long? FileSizeBytes { get; set; }

    public string? Sha256Hash { get; set; }

    public bool? IsEncrypted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
