using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class DocumentBlob
{
    public long Id { get; set; }

    public long BlobNoSequence { get; set; }

    public string? BlobNo { get; set; }

    public int StorageProviderId { get; set; }

    public string? StorageContainer { get; set; }

    public string StorageRelativePath { get; set; } = null!;

    public string? StorageObjectKey { get; set; }

    public string StoredFileName { get; set; } = null!;

    public string OriginalFileName { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string? MimeType { get; set; }

    public long FileSizeBytes { get; set; }

    public string Sha256Hash { get; set; } = null!;

    public bool IsEncrypted { get; set; }

    public string? EncryptionKeyRef { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedByEmployeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Employee? CreatedByEmployee { get; set; }

    public virtual ICollection<DocumentVersion> DocumentVersions { get; set; } = new List<DocumentVersion>();

    public virtual SysLookupItem StorageProvider { get; set; } = null!;
}
