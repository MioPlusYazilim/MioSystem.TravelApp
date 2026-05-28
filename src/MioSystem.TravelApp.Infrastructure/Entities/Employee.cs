using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class Employee
{
    public long Id { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public long? CompanyId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? JobTitle { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillingPlan> BillingPlanApprovedByEmployees { get; set; } = new List<BillingPlan>();

    public virtual ICollection<BillingPlan> BillingPlanCreatedByEmployees { get; set; } = new List<BillingPlan>();

    public virtual Company? Company { get; set; }

    public virtual ICollection<DocumentAccessLog> DocumentAccessLogs { get; set; } = new List<DocumentAccessLog>();

    public virtual ICollection<DocumentBlob> DocumentBlobs { get; set; } = new List<DocumentBlob>();

    public virtual ICollection<Document> DocumentCreatedByEmployees { get; set; } = new List<Document>();

    public virtual ICollection<DocumentEntityLink> DocumentEntityLinks { get; set; } = new List<DocumentEntityLink>();

    public virtual ICollection<Document> DocumentVerifiedByEmployees { get; set; } = new List<Document>();

    public virtual ICollection<DocumentVersion> DocumentVersions { get; set; } = new List<DocumentVersion>();

    public virtual ICollection<InvoiceBatch> InvoiceBatches { get; set; } = new List<InvoiceBatch>();

    public virtual ICollection<ProjectProgressLog> ProjectProgressLogs { get; set; } = new List<ProjectProgressLog>();

    public virtual ICollection<ProjectTaskAssignee> ProjectTaskAssignees { get; set; } = new List<ProjectTaskAssignee>();

    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Request> RequestAssignedEmployees { get; set; } = new List<Request>();

    public virtual ICollection<RequestAssignment> RequestAssignmentAssignedByEmployees { get; set; } = new List<RequestAssignment>();

    public virtual ICollection<RequestAssignment> RequestAssignmentEmployees { get; set; } = new List<RequestAssignment>();

    public virtual ICollection<Request> RequestCreatedByEmployees { get; set; } = new List<Request>();

    public virtual ICollection<RequestNote> RequestNotes { get; set; } = new List<RequestNote>();

    public virtual ICollection<RequestOfferStatusHistory> RequestOfferStatusHistories { get; set; } = new List<RequestOfferStatusHistory>();

    public virtual ICollection<RequestOffer> RequestOffers { get; set; } = new List<RequestOffer>();

    public virtual ICollection<RequestStatusHistory> RequestStatusHistories { get; set; } = new List<RequestStatusHistory>();

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocumentApprovedByEmployees { get; set; } = new List<TransactionVisaDocument>();

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocumentRejectedByEmployees { get; set; } = new List<TransactionVisaDocument>();
}
