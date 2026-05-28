using System;
using System.Collections.Generic;

namespace MioSystem.TravelApp.Infrastructure.Entities;

public partial class SysLookupItem
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public string Code { get; set; } = null!;

    public string? Value { get; set; }

    public string ResourceKey { get; set; } = null!;

    public int SortOrder { get; set; }

    public bool IsDefault { get; set; }

    public bool IsSystem { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<BillingPlan> BillingPlanDistributionMethods { get; set; } = new List<BillingPlan>();

    public virtual ICollection<BillingPlan> BillingPlanStatuses { get; set; } = new List<BillingPlan>();

    public virtual ICollection<CurrentAccountTransaction> CurrentAccountTransactions { get; set; } = new List<CurrentAccountTransaction>();

    public virtual ICollection<DocumentAccessLog> DocumentAccessLogs { get; set; } = new List<DocumentAccessLog>();

    public virtual ICollection<DocumentBlob> DocumentBlobs { get; set; } = new List<DocumentBlob>();

    public virtual ICollection<DocumentEntityLink> DocumentEntityLinkEntityTypes { get; set; } = new List<DocumentEntityLink>();

    public virtual ICollection<DocumentEntityLink> DocumentEntityLinkLinkRoles { get; set; } = new List<DocumentEntityLink>();

    public virtual ICollection<Document> DocumentStatuses { get; set; } = new List<Document>();

    public virtual ICollection<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

    public virtual ICollection<Document> DocumentVerificationStatuses { get; set; } = new List<Document>();

    public virtual SysLookupGroup Group { get; set; } = null!;

    public virtual ICollection<InvoiceBatch> InvoiceBatches { get; set; } = new List<InvoiceBatch>();

    public virtual ICollection<Invoice> InvoiceInvoiceTypes { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceStatuses { get; set; } = new List<Invoice>();

    public virtual ICollection<Payment> PaymentDirections { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentStatuses { get; set; } = new List<Payment>();

    public virtual ICollection<ProjectStage> ProjectStages { get; set; } = new List<ProjectStage>();

    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Request> RequestChannels { get; set; } = new List<Request>();

    public virtual ICollection<RequestOfferItem> RequestOfferItems { get; set; } = new List<RequestOfferItem>();

    public virtual ICollection<RequestOfferStatusHistory> RequestOfferStatusHistoryNewStatuses { get; set; } = new List<RequestOfferStatusHistory>();

    public virtual ICollection<RequestOfferStatusHistory> RequestOfferStatusHistoryOldStatuses { get; set; } = new List<RequestOfferStatusHistory>();

    public virtual ICollection<RequestOffer> RequestOffers { get; set; } = new List<RequestOffer>();

    public virtual ICollection<Request> RequestRequestTypes { get; set; } = new List<Request>();

    public virtual ICollection<RequestStatusHistory> RequestStatusHistoryNewStatuses { get; set; } = new List<RequestStatusHistory>();

    public virtual ICollection<RequestStatusHistory> RequestStatusHistoryOldStatuses { get; set; } = new List<RequestStatusHistory>();

    public virtual ICollection<Request> RequestStatuses { get; set; } = new List<Request>();

    public virtual ICollection<ServiceChargeLine> ServiceChargeLines { get; set; } = new List<ServiceChargeLine>();

    public virtual ICollection<ServiceLine> ServiceLines { get; set; } = new List<ServiceLine>();

    public virtual ICollection<TransactionFlightTicket> TransactionFlightTicketPassengerTypes { get; set; } = new List<TransactionFlightTicket>();

    public virtual ICollection<TransactionFlightTicket> TransactionFlightTicketTicketDocumentTypes { get; set; } = new List<TransactionFlightTicket>();

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public virtual ICollection<TransactionMaster> TransactionMasterMainServiceTypes { get; set; } = new List<TransactionMaster>();

    public virtual ICollection<TransactionMaster> TransactionMasterStatuses { get; set; } = new List<TransactionMaster>();

    public virtual ICollection<TransactionMaster> TransactionMasterTransactionTypes { get; set; } = new List<TransactionMaster>();

    public virtual ICollection<TransactionVisaDocument> TransactionVisaDocuments { get; set; } = new List<TransactionVisaDocument>();
}
