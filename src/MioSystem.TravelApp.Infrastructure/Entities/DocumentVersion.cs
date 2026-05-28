using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class DocumentVersion
{
    public long Id { get; set; }

    public long DocumentId { get; set; }

    public int VersionNo { get; set; }

    public long DocumentBlobId { get; set; }

    public string? VersionNote { get; set; }

    public bool IsCurrent { get; set; }

    public string? OcrText { get; set; }

    public string? MetadataJson { get; set; }

    public long? UploadedByEmployeeId { get; set; }

    public DateTime UploadedAt { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual ICollection<DocumentAccessLog> DocumentAccessLogs { get; set; } = new List<DocumentAccessLog>();

    public virtual DocumentBlob DocumentBlob { get; set; } = null!;

    public virtual ICollection<DocumentEntityLink> DocumentEntityLinks { get; set; } = new List<DocumentEntityLink>();

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocuments { get; set; } = new List<TransactionVisaDocument>();

    public virtual Employee? UploadedByEmployee { get; set; }
}
