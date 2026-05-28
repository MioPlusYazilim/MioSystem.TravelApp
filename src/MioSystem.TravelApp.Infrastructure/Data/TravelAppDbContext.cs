using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MioSystem.TravelApp.Infrastructure.Entities;

namespace MioSystem.TravelApp.Infrastructure.Data;

public partial class TravelAppDbContext : DbContext
{
    public TravelAppDbContext(DbContextOptions<TravelAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillingPlan> BillingPlans { get; set; }

    public virtual DbSet<BillingPlanLine> BillingPlanLines { get; set; }

    public virtual DbSet<BillingPlanLineDetail> BillingPlanLineDetails { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CurrentAccount> CurrentAccounts { get; set; }

    public virtual DbSet<CurrentAccountTransaction> CurrentAccountTransactions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerContact> CustomerContacts { get; set; }

    public virtual DbSet<CustomerContactEmployment> CustomerContactEmployments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentAccessLog> DocumentAccessLogs { get; set; }

    public virtual DbSet<DocumentBlob> DocumentBlobs { get; set; }

    public virtual DbSet<DocumentEntityLink> DocumentEntityLinks { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<DocumentVersion> DocumentVersions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceBatch> InvoiceBatches { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectProgressLog> ProjectProgressLogs { get; set; }

    public virtual DbSet<ProjectProgressSnapshot> ProjectProgressSnapshots { get; set; }

    public virtual DbSet<ProjectStage> ProjectStages { get; set; }

    public virtual DbSet<ProjectTask> ProjectTasks { get; set; }

    public virtual DbSet<ProjectTaskAssignee> ProjectTaskAssignees { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestAssignment> RequestAssignments { get; set; }

    public virtual DbSet<RequestNote> RequestNotes { get; set; }

    public virtual DbSet<RequestOffer> RequestOffers { get; set; }

    public virtual DbSet<RequestOfferItem> RequestOfferItems { get; set; }

    public virtual DbSet<RequestOfferStatusHistory> RequestOfferStatusHistories { get; set; }

    public virtual DbSet<RequestStatusHistory> RequestStatusHistories { get; set; }

    public virtual DbSet<ServiceChargeLine> ServiceChargeLines { get; set; }

    public virtual DbSet<ServiceLine> ServiceLines { get; set; }

    public virtual DbSet<SysCurrency> SysCurrencies { get; set; }

    public virtual DbSet<SysLanguage> SysLanguages { get; set; }

    public virtual DbSet<SysLookupGroup> SysLookupGroups { get; set; }

    public virtual DbSet<SysLookupItem> SysLookupItems { get; set; }

    public virtual DbSet<SysResource> SysResources { get; set; }

    public virtual DbSet<SysResourceTranslation> SysResourceTranslations { get; set; }

    public virtual DbSet<TransactionFlightTicket> TransactionFlightTickets { get; set; }

    public virtual DbSet<TransactionHotel> TransactionHotels { get; set; }

    public virtual DbSet<TransactionLine> TransactionLines { get; set; }

    public virtual DbSet<TransactionMaster> TransactionMasters { get; set; }

    public virtual DbSet<TransactionRentAcar> TransactionRentAcars { get; set; }

    public virtual DbSet<TransactionTransfer> TransactionTransfers { get; set; }

    public virtual DbSet<TransactionVisa> TransactionVisas { get; set; }

    public virtual DbSet<TransactionVisaDocument> TransactionVisaDocuments { get; set; }

    public virtual DbSet<VisaDocumentRule> VisaDocumentRules { get; set; }

    public virtual DbSet<VwBillingPlanSummary> VwBillingPlanSummaries { get; set; }

    public virtual DbSet<VwDocumentCurrentVersion> VwDocumentCurrentVersions { get; set; }

    public virtual DbSet<VwProjectList> VwProjectLists { get; set; }

    public virtual DbSet<VwRequestList> VwRequestLists { get; set; }

    public virtual DbSet<VwServiceChargeLine> VwServiceChargeLines { get; set; }

    public virtual DbSet<VwSysLookupItem> VwSysLookupItems { get; set; }

    public virtual DbSet<VwTransactionList> VwTransactionLists { get; set; }

    public virtual DbSet<VwTransactionVisaDocumentStatus> VwTransactionVisaDocumentStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");

        modelBuilder.Entity<BillingPlan>(entity =>
        {
            entity.ToTable("BillingPlan");

            entity.HasIndex(e => e.CustomerId, "IX_BillingPlan_CustomerID");

            entity.HasIndex(e => e.StatusId, "IX_BillingPlan_StatusID");

            entity.HasIndex(e => e.TransactionId, "IX_BillingPlan_TransactionID");

            entity.HasIndex(e => e.PlanNo, "UQ_BillingPlan_PlanNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovedAt).HasPrecision(0);
            entity.Property(e => e.ApprovedByEmployeeId).HasColumnName("ApprovedByEmployeeID");
            entity.Property(e => e.BillingNote).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DistributionMethodId).HasColumnName("DistributionMethodID");
            entity.Property(e => e.PlanNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('BLP-'+right(replicate('0',(10))+CONVERT([varchar](20),[PlanNoSequence]),(10)))", true);
            entity.Property(e => e.PlanNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_BillingPlanNo])");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TotalPlanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.ApprovedByEmployee).WithMany(p => p.BillingPlanApprovedByEmployees)
                .HasForeignKey(d => d.ApprovedByEmployeeId)
                .HasConstraintName("FK_BillingPlan_ApprovedByEmployee");

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.BillingPlanCreatedByEmployees)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_BillingPlan_CreatedByEmployee");

            entity.HasOne(d => d.Currency).WithMany(p => p.BillingPlans)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlan_Currency");

            entity.HasOne(d => d.Customer).WithMany(p => p.BillingPlans)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlan_Customer");

            entity.HasOne(d => d.DistributionMethod).WithMany(p => p.BillingPlanDistributionMethods)
                .HasForeignKey(d => d.DistributionMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlan_DistributionMethod");

            entity.HasOne(d => d.Project).WithMany(p => p.BillingPlans)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_BillingPlan_Project");

            entity.HasOne(d => d.Status).WithMany(p => p.BillingPlanStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlan_Status");

            entity.HasOne(d => d.Transaction).WithMany(p => p.BillingPlans)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlan_TransactionMaster");
        });

        modelBuilder.Entity<BillingPlanLine>(entity =>
        {
            entity.ToTable("BillingPlanLine");

            entity.HasIndex(e => e.BillToCustomerId, "IX_BillingPlanLine_BillToCustomerID");

            entity.HasIndex(e => e.BillingPlanId, "IX_BillingPlanLine_BillingPlanID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BillToCustomerContactEmploymentId).HasColumnName("BillToCustomerContactEmploymentID");
            entity.Property(e => e.BillToCustomerId).HasColumnName("BillToCustomerID");
            entity.Property(e => e.BillingPlanId).HasColumnName("BillingPlanID");
            entity.Property(e => e.CostCenter).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.Department).HasMaxLength(150);
            entity.Property(e => e.DistributionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DistributionPercent).HasColumnType("decimal(9, 4)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.BillToCustomerContactEmployment).WithMany(p => p.BillingPlanLines)
                .HasForeignKey(d => d.BillToCustomerContactEmploymentId)
                .HasConstraintName("FK_BillingPlanLine_ContactEmployment");

            entity.HasOne(d => d.BillToCustomer).WithMany(p => p.BillingPlanLines)
                .HasForeignKey(d => d.BillToCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlanLine_BillToCustomer");

            entity.HasOne(d => d.BillingPlan).WithMany(p => p.BillingPlanLines)
                .HasForeignKey(d => d.BillingPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlanLine_BillingPlan");

            entity.HasOne(d => d.Currency).WithMany(p => p.BillingPlanLines)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlanLine_Currency");
        });

        modelBuilder.Entity<BillingPlanLineDetail>(entity =>
        {
            entity.ToTable("BillingPlanLineDetail");

            entity.HasIndex(e => e.BillingPlanLineId, "IX_BillingPlanLineDetail_BillingPlanLineID");

            entity.HasIndex(e => e.ServiceChargeLineId, "IX_BillingPlanLineDetail_ServiceChargeLineID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BillingPlanLineId).HasColumnName("BillingPlanLineID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.DistributionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DistributionPercent).HasColumnType("decimal(9, 4)");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.ServiceChargeLineId).HasColumnName("ServiceChargeLineID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.BillingPlanLine).WithMany(p => p.BillingPlanLineDetails)
                .HasForeignKey(d => d.BillingPlanLineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlanLineDetail_BillingPlanLine");

            entity.HasOne(d => d.Currency).WithMany(p => p.BillingPlanLineDetails)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlanLineDetail_Currency");

            entity.HasOne(d => d.ServiceChargeLine).WithMany(p => p.BillingPlanLineDetails)
                .HasForeignKey(d => d.ServiceChargeLineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillingPlanLineDetail_ServiceChargeLine");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.HasIndex(e => e.Title, "IX_Company_Title");

            entity.HasIndex(e => e.CompanyCode, "UQ_Company_CompanyCode").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddressLine).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CompanyCode).HasMaxLength(30);
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.ShortTitle).HasMaxLength(100);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);
            entity.Property(e => e.TaxOffice).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
        });

        modelBuilder.Entity<CurrentAccount>(entity =>
        {
            entity.ToTable("CurrentAccount");

            entity.HasIndex(e => e.CustomerId, "IX_CurrentAccount_CustomerID");

            entity.HasIndex(e => e.AccountCode, "UQ_CurrentAccount_AccountCode").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountCode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasComputedColumnSql("('CA-'+right(replicate('0',(10))+CONVERT([varchar](20),[AccountNoSequence]),(10)))", true);
            entity.Property(e => e.AccountNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_CurrentAccountNo])");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Company).WithMany(p => p.CurrentAccounts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_CurrentAccount_Company");

            entity.HasOne(d => d.Currency).WithMany(p => p.CurrentAccounts)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CurrentAccount_Currency");

            entity.HasOne(d => d.Customer).WithMany(p => p.CurrentAccounts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CurrentAccount_Customer");
        });

        modelBuilder.Entity<CurrentAccountTransaction>(entity =>
        {
            entity.ToTable("CurrentAccountTransaction");

            entity.HasIndex(e => e.CurrentAccountId, "IX_CurrentAccountTransaction_CurrentAccountID");

            entity.HasIndex(e => e.TransactionDate, "IX_CurrentAccountTransaction_TransactionDate").IsDescending();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreditAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CurrentAccountId).HasColumnName("CurrentAccountID");
            entity.Property(e => e.DebitAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.TransactionDate)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

            entity.HasOne(d => d.Currency).WithMany(p => p.CurrentAccountTransactions)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CurrentAccountTransaction_Currency");

            entity.HasOne(d => d.CurrentAccount).WithMany(p => p.CurrentAccountTransactions)
                .HasForeignKey(d => d.CurrentAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CurrentAccountTransaction_CurrentAccount");

            entity.HasOne(d => d.Invoice).WithMany(p => p.CurrentAccountTransactions)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_CurrentAccountTransaction_Invoice");

            entity.HasOne(d => d.Payment).WithMany(p => p.CurrentAccountTransactions)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_CurrentAccountTransaction_Payment");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.CurrentAccountTransactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CurrentAccountTransaction_Type");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "IX_Customer_Email");

            entity.HasIndex(e => e.Phone, "IX_Customer_Phone");

            entity.HasIndex(e => e.Title, "IX_Customer_Title");

            entity.HasIndex(e => e.CustomerCode, "UQ_Customer_CustomerCode").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddressLine).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CustomerCode).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobilePhone).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);
            entity.Property(e => e.TaxOffice).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Company).WithMany(p => p.Customers).HasForeignKey(d => d.CompanyId);
        });

        modelBuilder.Entity<CustomerContact>(entity =>
        {
            entity.ToTable("CustomerContact");

            entity.HasIndex(e => e.PersonalEmail, "IX_CustomerContact_Email");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "IX_CustomerContact_Name");

            entity.HasIndex(e => e.ContactCode, "UX_CustomerContact_ContactCode")
                .IsUnique()
                .HasFilter("([ContactCode] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContactCode).HasMaxLength(30);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IdentityNo).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobilePhone).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.PassportNo).HasMaxLength(50);
            entity.Property(e => e.PersonalEmail).HasMaxLength(150);
            entity.Property(e => e.PersonalPhone).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
        });

        modelBuilder.Entity<CustomerContactEmployment>(entity =>
        {
            entity.ToTable("CustomerContactEmployment");

            entity.HasIndex(e => e.CustomerContactId, "IX_CustomerContactEmployment_ContactID");

            entity.HasIndex(e => e.CustomerId, "IX_CustomerContactEmployment_CustomerID");

            entity.HasIndex(e => e.CustomerContactId, "UX_CustomerContactEmployment_OneActivePerContact")
                .IsUnique()
                .HasFilter("([IsActive]=(1))");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CostCenter).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CustomerContactId).HasColumnName("CustomerContactID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Department).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JobTitle).HasMaxLength(150);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.WorkEmail).HasMaxLength(150);
            entity.Property(e => e.WorkPhone).HasMaxLength(50);

            entity.HasOne(d => d.Company).WithMany(p => p.CustomerContactEmployments)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_CustomerContactEmployment_Company");

            entity.HasOne(d => d.CustomerContact).WithOne(p => p.CustomerContactEmployment)
                .HasForeignKey<CustomerContactEmployment>(d => d.CustomerContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerContactEmployment_Contact");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerContactEmployments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerContactEmployment_Customer");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Document");

            entity.HasIndex(e => e.DocumentTypeId, "IX_Document_DocumentTypeID");

            entity.HasIndex(e => e.ExpiryDate, "IX_Document_ExpiryDate").HasFilter("([ExpiryDate] IS NOT NULL AND [IsDeleted]=(0))");

            entity.HasIndex(e => e.OwnerCompanyId, "IX_Document_OwnerCompanyID");

            entity.HasIndex(e => e.OwnerCustomerContactId, "IX_Document_OwnerCustomerContactID");

            entity.HasIndex(e => e.OwnerCustomerId, "IX_Document_OwnerCustomerID");

            entity.HasIndex(e => e.StatusId, "IX_Document_StatusID");

            entity.HasIndex(e => e.DocumentNo, "UQ_Document_DocumentNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.DeletedAt).HasPrecision(0);
            entity.Property(e => e.DocumentNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('DOC-'+right(replicate('0',(10))+CONVERT([varchar](20),[DocumentNoSequence]),(10)))", true);
            entity.Property(e => e.DocumentNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_DocumentNo])");
            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.ExternalDocumentNo).HasMaxLength(100);
            entity.Property(e => e.IsConfidential).HasDefaultValue(true);
            entity.Property(e => e.IsReusable).HasDefaultValue(true);
            entity.Property(e => e.IssuingCountryCode).HasMaxLength(10);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.OwnerCompanyId).HasColumnName("OwnerCompanyID");
            entity.Property(e => e.OwnerCustomerContactId).HasColumnName("OwnerCustomerContactID");
            entity.Property(e => e.OwnerCustomerId).HasColumnName("OwnerCustomerID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Tags).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.VerificationStatusId).HasColumnName("VerificationStatusID");
            entity.Property(e => e.VerifiedAt).HasPrecision(0);
            entity.Property(e => e.VerifiedByEmployeeId).HasColumnName("VerifiedByEmployeeID");

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.DocumentCreatedByEmployees)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_Document_CreatedByEmployee");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_DocumentType");

            entity.HasOne(d => d.OwnerCompany).WithMany(p => p.Documents)
                .HasForeignKey(d => d.OwnerCompanyId)
                .HasConstraintName("FK_Document_OwnerCompany");

            entity.HasOne(d => d.OwnerCustomerContact).WithMany(p => p.Documents)
                .HasForeignKey(d => d.OwnerCustomerContactId)
                .HasConstraintName("FK_Document_OwnerCustomerContact");

            entity.HasOne(d => d.OwnerCustomer).WithMany(p => p.Documents)
                .HasForeignKey(d => d.OwnerCustomerId)
                .HasConstraintName("FK_Document_OwnerCustomer");

            entity.HasOne(d => d.Status).WithMany(p => p.DocumentStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_Status");

            entity.HasOne(d => d.VerificationStatus).WithMany(p => p.DocumentVerificationStatuses)
                .HasForeignKey(d => d.VerificationStatusId)
                .HasConstraintName("FK_Document_VerificationStatus");

            entity.HasOne(d => d.VerifiedByEmployee).WithMany(p => p.DocumentVerifiedByEmployees)
                .HasForeignKey(d => d.VerifiedByEmployeeId)
                .HasConstraintName("FK_Document_VerifiedByEmployee");
        });

        modelBuilder.Entity<DocumentAccessLog>(entity =>
        {
            entity.ToTable("DocumentAccessLog");

            entity.HasIndex(e => e.ActionId, "IX_DocumentAccessLog_ActionID");

            entity.HasIndex(e => new { e.DocumentId, e.AccessedAt }, "IX_DocumentAccessLog_DocumentID_AccessedAt").IsDescending(false, true);

            entity.HasIndex(e => e.EmployeeId, "IX_DocumentAccessLog_EmployeeID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccessedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ActionId).HasColumnName("ActionID");
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentVersionId).HasColumnName("DocumentVersionID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.IpAddress).HasMaxLength(64);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.Succeeded).HasDefaultValue(true);
            entity.Property(e => e.UserAgent).HasMaxLength(500);

            entity.HasOne(d => d.Action).WithMany(p => p.DocumentAccessLogs)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentAccessLog_Action");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentAccessLogs)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentAccessLog_Document");

            entity.HasOne(d => d.DocumentVersion).WithMany(p => p.DocumentAccessLogs)
                .HasForeignKey(d => d.DocumentVersionId)
                .HasConstraintName("FK_DocumentAccessLog_DocumentVersion");

            entity.HasOne(d => d.Employee).WithMany(p => p.DocumentAccessLogs)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_DocumentAccessLog_Employee");
        });

        modelBuilder.Entity<DocumentBlob>(entity =>
        {
            entity.ToTable("DocumentBlob");

            entity.HasIndex(e => e.CreatedAt, "IX_DocumentBlob_CreatedAt").IsDescending();

            entity.HasIndex(e => e.StorageProviderId, "IX_DocumentBlob_StorageProviderID");

            entity.HasIndex(e => e.BlobNo, "UQ_DocumentBlob_BlobNo").IsUnique();

            entity.HasIndex(e => new { e.Sha256Hash, e.FileSizeBytes }, "UX_DocumentBlob_Sha256_Size_Active")
                .IsUnique()
                .HasFilter("([IsDeleted]=(0))");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BlobNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('DBL-'+right(replicate('0',(10))+CONVERT([varchar](20),[BlobNoSequence]),(10)))", true);
            entity.Property(e => e.BlobNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_DocumentBlobNo])");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.DeletedAt).HasPrecision(0);
            entity.Property(e => e.EncryptionKeyRef).HasMaxLength(200);
            entity.Property(e => e.FileExtension).HasMaxLength(20);
            entity.Property(e => e.MimeType).HasMaxLength(150);
            entity.Property(e => e.OriginalFileName).HasMaxLength(260);
            entity.Property(e => e.Sha256Hash)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StorageContainer).HasMaxLength(200);
            entity.Property(e => e.StorageObjectKey).HasMaxLength(1000);
            entity.Property(e => e.StorageProviderId).HasColumnName("StorageProviderID");
            entity.Property(e => e.StorageRelativePath).HasMaxLength(1000);
            entity.Property(e => e.StoredFileName).HasMaxLength(260);

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.DocumentBlobs)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_DocumentBlob_CreatedByEmployee");

            entity.HasOne(d => d.StorageProvider).WithMany(p => p.DocumentBlobs)
                .HasForeignKey(d => d.StorageProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentBlob_StorageProvider");
        });

        modelBuilder.Entity<DocumentEntityLink>(entity =>
        {
            entity.ToTable("DocumentEntityLink");

            entity.HasIndex(e => e.DocumentId, "IX_DocumentEntityLink_DocumentID");

            entity.HasIndex(e => e.DocumentVersionId, "IX_DocumentEntityLink_DocumentVersionID");

            entity.HasIndex(e => new { e.EntityTypeId, e.EntityId, e.IsActive }, "IX_DocumentEntityLink_Entity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentVersionId).HasColumnName("DocumentVersionID");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.EntityTypeId).HasColumnName("EntityTypeID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LinkRoleId).HasColumnName("LinkRoleID");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.DocumentEntityLinks)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_DocumentEntityLink_CreatedByEmployee");

            entity.HasOne(d => d.Document).WithMany(p => p.DocumentEntityLinks)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentEntityLink_Document");

            entity.HasOne(d => d.DocumentVersion).WithMany(p => p.DocumentEntityLinks)
                .HasForeignKey(d => d.DocumentVersionId)
                .HasConstraintName("FK_DocumentEntityLink_DocumentVersion");

            entity.HasOne(d => d.EntityType).WithMany(p => p.DocumentEntityLinkEntityTypes)
                .HasForeignKey(d => d.EntityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentEntityLink_EntityType");

            entity.HasOne(d => d.LinkRole).WithMany(p => p.DocumentEntityLinkLinkRoles)
                .HasForeignKey(d => d.LinkRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentEntityLink_LinkRole");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.ToTable("DocumentType");

            entity.HasIndex(e => e.CategoryId, "IX_DocumentType_CategoryID");

            entity.HasIndex(e => new { e.SortOrder, e.Id }, "IX_DocumentType_SortOrder");

            entity.HasIndex(e => e.Code, "UQ_DocumentType_Code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AllowedExtensions).HasMaxLength(500);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Code).HasMaxLength(80);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsReusable).HasDefaultValue(true);
            entity.Property(e => e.IsSystem).HasDefaultValue(true);
            entity.Property(e => e.MaxFileSizeMb).HasColumnName("MaxFileSizeMB");
            entity.Property(e => e.ResourceKey).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Category).WithMany(p => p.DocumentTypes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_DocumentType_Category");
        });

        modelBuilder.Entity<DocumentVersion>(entity =>
        {
            entity.ToTable("DocumentVersion");

            entity.HasIndex(e => e.DocumentBlobId, "IX_DocumentVersion_DocumentBlobID");

            entity.HasIndex(e => e.UploadedAt, "IX_DocumentVersion_UploadedAt").IsDescending();

            entity.HasIndex(e => new { e.DocumentId, e.VersionNo }, "UQ_DocumentVersion_Document_VersionNo").IsUnique();

            entity.HasIndex(e => e.DocumentId, "UX_DocumentVersion_Current")
                .IsUnique()
                .HasFilter("([IsCurrent]=(1))");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DocumentBlobId).HasColumnName("DocumentBlobID");
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.IsCurrent).HasDefaultValue(true);
            entity.Property(e => e.UploadedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.UploadedByEmployeeId).HasColumnName("UploadedByEmployeeID");
            entity.Property(e => e.VersionNote).HasMaxLength(1000);

            entity.HasOne(d => d.DocumentBlob).WithMany(p => p.DocumentVersions)
                .HasForeignKey(d => d.DocumentBlobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentVersion_DocumentBlob");

            entity.HasOne(d => d.Document).WithOne(p => p.DocumentVersion)
                .HasForeignKey<DocumentVersion>(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DocumentVersion_Document");

            entity.HasOne(d => d.UploadedByEmployee).WithMany(p => p.DocumentVersions)
                .HasForeignKey(d => d.UploadedByEmployeeId)
                .HasConstraintName("FK_DocumentVersion_UploadedByEmployee");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.HasIndex(e => e.Email, "IX_Employee_Email");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "IX_Employee_Name");

            entity.HasIndex(e => e.EmployeeCode, "UQ_Employee_EmployeeCode").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.EmployeeCode).HasMaxLength(30);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JobTitle).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Company).WithMany(p => p.Employees).HasForeignKey(d => d.CompanyId);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice");

            entity.HasIndex(e => e.CustomerId, "IX_Invoice_CustomerID");

            entity.HasIndex(e => e.InvoiceDate, "IX_Invoice_InvoiceDate").IsDescending();

            entity.HasIndex(e => e.StatusId, "IX_Invoice_StatusID");

            entity.HasIndex(e => e.InvoiceNo, "UQ_Invoice_InvoiceNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BillingPlanId).HasColumnName("BillingPlanID");
            entity.Property(e => e.BillingPlanLineId).HasColumnName("BillingPlanLineID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.EinvoiceUuid).HasColumnName("EInvoiceUuid");
            entity.Property(e => e.InvoiceBatchId).HasColumnName("InvoiceBatchID");
            entity.Property(e => e.InvoiceDate)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('INV-'+right(replicate('0',(10))+CONVERT([varchar](20),[InvoiceNoSequence]),(10)))", true);
            entity.Property(e => e.InvoiceNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_InvoiceNo])");
            entity.Property(e => e.InvoiceTypeId).HasColumnName("InvoiceTypeID");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.ScenarioCode).HasMaxLength(50);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.SubTotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.BillingPlan).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.BillingPlanId)
                .HasConstraintName("FK_Invoice_BillingPlan");

            entity.HasOne(d => d.BillingPlanLine).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.BillingPlanLineId)
                .HasConstraintName("FK_Invoice_BillingPlanLine");

            entity.HasOne(d => d.Currency).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Currency");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Customer");

            entity.HasOne(d => d.InvoiceBatch).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.InvoiceBatchId)
                .HasConstraintName("FK_Invoice_InvoiceBatch");

            entity.HasOne(d => d.InvoiceType).WithMany(p => p.InvoiceInvoiceTypes)
                .HasForeignKey(d => d.InvoiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_InvoiceType");

            entity.HasOne(d => d.Status).WithMany(p => p.InvoiceStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Status");
        });

        modelBuilder.Entity<InvoiceBatch>(entity =>
        {
            entity.ToTable("InvoiceBatch");

            entity.HasIndex(e => e.BatchNo, "UQ_InvoiceBatch_BatchNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BatchNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('IBT-'+right(replicate('0',(10))+CONVERT([varchar](20),[BatchNoSequence]),(10)))", true);
            entity.Property(e => e.BatchNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_InvoiceBatchNo])");
            entity.Property(e => e.BillingPlanId).HasColumnName("BillingPlanID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.BillingPlan).WithMany(p => p.InvoiceBatches)
                .HasForeignKey(d => d.BillingPlanId)
                .HasConstraintName("FK_InvoiceBatch_BillingPlan");

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.InvoiceBatches)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_InvoiceBatch_CreatedByEmployee");

            entity.HasOne(d => d.Status).WithMany(p => p.InvoiceBatches)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceBatch_Status");
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.ToTable("InvoiceLine");

            entity.HasIndex(e => e.InvoiceId, "IX_InvoiceLine_InvoiceID");

            entity.HasIndex(e => e.ServiceChargeLineId, "IX_InvoiceLine_ServiceChargeLineID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BillingPlanLineDetailId).HasColumnName("BillingPlanLineDetailID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.LineTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ServiceChargeLineId).HasColumnName("ServiceChargeLineID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxRate).HasColumnType("decimal(9, 4)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.BillingPlanLineDetail).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.BillingPlanLineDetailId)
                .HasConstraintName("FK_InvoiceLine_BillingPlanLineDetail");

            entity.HasOne(d => d.Currency).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLine_Currency");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLine_Invoice");

            entity.HasOne(d => d.ServiceChargeLine).WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.ServiceChargeLineId)
                .HasConstraintName("FK_InvoiceLine_ServiceChargeLine");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.HasIndex(e => e.CustomerId, "IX_Payment_CustomerID");

            entity.HasIndex(e => e.InvoiceId, "IX_Payment_InvoiceID");

            entity.HasIndex(e => e.PaymentNo, "UQ_Payment_PaymentNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CurrentAccountId).HasColumnName("CurrentAccountID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.DirectionId).HasColumnName("DirectionID");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.PaymentDate)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.PaymentNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('PAY-'+right(replicate('0',(10))+CONVERT([varchar](20),[PaymentNoSequence]),(10)))", true);
            entity.Property(e => e.PaymentNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_PaymentNo])");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Currency).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Currency");

            entity.HasOne(d => d.CurrentAccount).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CurrentAccountId)
                .HasConstraintName("FK_Payment_CurrentAccount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Payment_Customer");

            entity.HasOne(d => d.Direction).WithMany(p => p.PaymentDirections)
                .HasForeignKey(d => d.DirectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Direction");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK_Payment_Invoice");

            entity.HasOne(d => d.Status).WithMany(p => p.PaymentStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Status");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.HasIndex(e => e.CustomerId, "IX_Project_CustomerID");

            entity.HasIndex(e => e.SourceTransactionId, "IX_Project_SourceTransactionID");

            entity.HasIndex(e => e.StatusId, "IX_Project_StatusID");

            entity.HasIndex(e => e.ProjectNo, "UQ_Project_ProjectNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.CustomerContactEmploymentId).HasColumnName("CustomerContactEmploymentID");
            entity.Property(e => e.CustomerContactId).HasColumnName("CustomerContactID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProgressPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProjectName).HasMaxLength(250);
            entity.Property(e => e.ProjectNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('PRJ-'+right(replicate('0',(10))+CONVERT([varchar](20),[ProjectNoSequence]),(10)))", true);
            entity.Property(e => e.ProjectNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_ProjectNo])");
            entity.Property(e => e.SourceOfferId).HasColumnName("SourceOfferID");
            entity.Property(e => e.SourceRequestId).HasColumnName("SourceRequestID");
            entity.Property(e => e.SourceTransactionId).HasColumnName("SourceTransactionID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_Project_CreatedByEmployee");

            entity.HasOne(d => d.CustomerContactEmployment).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CustomerContactEmploymentId)
                .HasConstraintName("FK_Project_CustomerContactEmployment");

            entity.HasOne(d => d.CustomerContact).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CustomerContactId)
                .HasConstraintName("FK_Project_CustomerContact");

            entity.HasOne(d => d.Customer).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Customer");

            entity.HasOne(d => d.SourceOffer).WithMany(p => p.Projects)
                .HasForeignKey(d => d.SourceOfferId)
                .HasConstraintName("FK_Project_SourceOffer");

            entity.HasOne(d => d.SourceRequest).WithMany(p => p.Projects)
                .HasForeignKey(d => d.SourceRequestId)
                .HasConstraintName("FK_Project_SourceRequest");

            entity.HasOne(d => d.SourceTransaction).WithMany(p => p.Projects)
                .HasForeignKey(d => d.SourceTransactionId)
                .HasConstraintName("FK_Project_TransactionMaster");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Project_Status");
        });

        modelBuilder.Entity<ProjectProgressLog>(entity =>
        {
            entity.ToTable("ProjectProgressLog");

            entity.HasIndex(e => new { e.ProjectId, e.ChangedAt }, "IX_ProjectProgressLog_ProjectID_ChangedAt").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChangedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ChangedByEmployeeId).HasColumnName("ChangedByEmployeeID");
            entity.Property(e => e.NewProgressPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.OldProgressPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectStageId).HasColumnName("ProjectStageID");
            entity.Property(e => e.ProjectTaskId).HasColumnName("ProjectTaskID");

            entity.HasOne(d => d.ChangedByEmployee).WithMany(p => p.ProjectProgressLogs)
                .HasForeignKey(d => d.ChangedByEmployeeId)
                .HasConstraintName("FK_ProjectProgressLog_Employee");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectProgressLogs)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectProgressLog_Project");

            entity.HasOne(d => d.ProjectStage).WithMany(p => p.ProjectProgressLogs)
                .HasForeignKey(d => d.ProjectStageId)
                .HasConstraintName("FK_ProjectProgressLog_ProjectStage");

            entity.HasOne(d => d.ProjectTask).WithMany(p => p.ProjectProgressLogs)
                .HasForeignKey(d => d.ProjectTaskId)
                .HasConstraintName("FK_ProjectProgressLog_ProjectTask");
        });

        modelBuilder.Entity<ProjectProgressSnapshot>(entity =>
        {
            entity.ToTable("ProjectProgressSnapshot");

            entity.HasIndex(e => new { e.ProjectId, e.SnapshotAt }, "IX_ProjectProgressSnapshot_ProjectID_SnapshotAt").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.ProgressPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.SnapshotAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectProgressSnapshots)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectProgressSnapshot_Project");
        });

        modelBuilder.Entity<ProjectStage>(entity =>
        {
            entity.ToTable("ProjectStage");

            entity.HasIndex(e => e.ProjectId, "IX_ProjectStage_ProjectID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ProgressPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StageName).HasMaxLength(250);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.WeightPercent).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectStages)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectStage_Project");

            entity.HasOne(d => d.Status).WithMany(p => p.ProjectStages)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectStage_Status");
        });

        modelBuilder.Entity<ProjectTask>(entity =>
        {
            entity.ToTable("ProjectTask");

            entity.HasIndex(e => e.ProjectId, "IX_ProjectTask_ProjectID");

            entity.HasIndex(e => e.ProjectStageId, "IX_ProjectTask_ProjectStageID");

            entity.HasIndex(e => e.StatusId, "IX_ProjectTask_StatusID");

            entity.HasIndex(e => e.TaskNo, "UQ_ProjectTask_TaskNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActualEndAt).HasPrecision(0);
            entity.Property(e => e.ActualStartAt).HasPrecision(0);
            entity.Property(e => e.AssignedEmployeeId).HasColumnName("AssignedEmployeeID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ParentTaskId).HasColumnName("ParentTaskID");
            entity.Property(e => e.PlannedEndAt).HasPrecision(0);
            entity.Property(e => e.PlannedStartAt).HasPrecision(0);
            entity.Property(e => e.ProgressPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectStageId).HasColumnName("ProjectStageID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TaskNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('TSK-'+right(replicate('0',(10))+CONVERT([varchar](20),[TaskNoSequence]),(10)))", true);
            entity.Property(e => e.TaskNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_ProjectTaskNo])");
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.WeightPercent).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.AssignedEmployee).WithMany(p => p.ProjectTasks)
                .HasForeignKey(d => d.AssignedEmployeeId)
                .HasConstraintName("FK_ProjectTask_AssignedEmployee");

            entity.HasOne(d => d.ParentTask).WithMany(p => p.InverseParentTask)
                .HasForeignKey(d => d.ParentTaskId)
                .HasConstraintName("FK_ProjectTask_ParentTask");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectTasks)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTask_Project");

            entity.HasOne(d => d.ProjectStage).WithMany(p => p.ProjectTasks)
                .HasForeignKey(d => d.ProjectStageId)
                .HasConstraintName("FK_ProjectTask_ProjectStage");

            entity.HasOne(d => d.Status).WithMany(p => p.ProjectTasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTask_Status");
        });

        modelBuilder.Entity<ProjectTaskAssignee>(entity =>
        {
            entity.ToTable("ProjectTaskAssignee");

            entity.HasIndex(e => e.EmployeeId, "IX_ProjectTaskAssignee_EmployeeID");

            entity.HasIndex(e => e.ProjectTaskId, "IX_ProjectTaskAssignee_ProjectTaskID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ProjectTaskId).HasColumnName("ProjectTaskID");
            entity.Property(e => e.UnassignedAt).HasPrecision(0);

            entity.HasOne(d => d.Employee).WithMany(p => p.ProjectTaskAssignees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTaskAssignee_Employee");

            entity.HasOne(d => d.ProjectTask).WithMany(p => p.ProjectTaskAssignees)
                .HasForeignKey(d => d.ProjectTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectTaskAssignee_ProjectTask");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.HasIndex(e => e.AssignedEmployeeId, "IX_Request_AssignedEmployeeID");

            entity.HasIndex(e => e.ChannelId, "IX_Request_ChannelID");

            entity.HasIndex(e => e.CreatedAt, "IX_Request_CreatedAt").IsDescending();

            entity.HasIndex(e => e.CustomerId, "IX_Request_CustomerID");

            entity.HasIndex(e => e.RequestTypeId, "IX_Request_RequestTypeID");

            entity.HasIndex(e => e.StatusId, "IX_Request_StatusID");

            entity.HasIndex(e => e.RequestNo, "UQ_Request_RequestNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedEmployeeId).HasColumnName("AssignedEmployeeID");
            entity.Property(e => e.ChannelId).HasColumnName("ChannelID");
            entity.Property(e => e.ClosedAt).HasPrecision(0);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.CustomerContactEmploymentId).HasColumnName("CustomerContactEmploymentID");
            entity.Property(e => e.CustomerContactId).HasColumnName("CustomerContactID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('REQ-'+right(replicate('0',(10))+CONVERT([varchar](20),[RequestNoSequence]),(10)))", true);
            entity.Property(e => e.RequestNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_RequestNo])");
            entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");
            entity.Property(e => e.RequestedEndDate).HasPrecision(0);
            entity.Property(e => e.RequestedStartDate).HasPrecision(0);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Subject).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.AssignedEmployee).WithMany(p => p.RequestAssignedEmployees)
                .HasForeignKey(d => d.AssignedEmployeeId)
                .HasConstraintName("FK_Request_AssignedEmployee_EmployeeID");

            entity.HasOne(d => d.Channel).WithMany(p => p.RequestChannels)
                .HasForeignKey(d => d.ChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Channel_SysLookupItem");

            entity.HasOne(d => d.Company).WithMany(p => p.Requests).HasForeignKey(d => d.CompanyId);

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.RequestCreatedByEmployees)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_Request_CreatedByEmployee_EmployeeID");

            entity.HasOne(d => d.CustomerContactEmployment).WithMany(p => p.Requests)
                .HasForeignKey(d => d.CustomerContactEmploymentId)
                .HasConstraintName("FK_Request_CustomerContactEmployment");

            entity.HasOne(d => d.CustomerContact).WithMany(p => p.Requests)
                .HasForeignKey(d => d.CustomerContactId)
                .HasConstraintName("FK_Request_CustomerContact");

            entity.HasOne(d => d.Customer).WithMany(p => p.Requests)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.RequestType).WithMany(p => p.RequestRequestTypes)
                .HasForeignKey(d => d.RequestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_RequestType_SysLookupItem");

            entity.HasOne(d => d.Status).WithMany(p => p.RequestStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Status_SysLookupItem");
        });

        modelBuilder.Entity<RequestAssignment>(entity =>
        {
            entity.ToTable("RequestAssignment");

            entity.HasIndex(e => e.EmployeeId, "IX_RequestAssignment_EmployeeID");

            entity.HasIndex(e => e.RequestId, "IX_RequestAssignment_RequestID");

            entity.HasIndex(e => e.RequestId, "UX_RequestAssignment_OnlyOneActivePerRequest")
                .IsUnique()
                .HasFilter("([IsActive]=(1))");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.AssignedByEmployeeId).HasColumnName("AssignedByEmployeeID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.UnassignedAt).HasPrecision(0);

            entity.HasOne(d => d.AssignedByEmployee).WithMany(p => p.RequestAssignmentAssignedByEmployees)
                .HasForeignKey(d => d.AssignedByEmployeeId)
                .HasConstraintName("FK_RequestAssignment_AssignedByEmployee_EmployeeID");

            entity.HasOne(d => d.Employee).WithMany(p => p.RequestAssignmentEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Request).WithOne(p => p.RequestAssignment)
                .HasForeignKey<RequestAssignment>(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RequestNote>(entity =>
        {
            entity.ToTable("RequestNote");

            entity.HasIndex(e => new { e.RequestId, e.CreatedAt }, "IX_RequestNote_RequestID_CreatedAt").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.IsInternal).HasDefaultValue(true);
            entity.Property(e => e.NoteTypeCode).HasMaxLength(50);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.Employee).WithMany(p => p.RequestNotes).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.Request).WithMany(p => p.RequestNotes)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RequestOffer>(entity =>
        {
            entity.ToTable("RequestOffer");

            entity.HasIndex(e => e.OfferDate, "IX_RequestOffer_OfferDate").IsDescending();

            entity.HasIndex(e => e.RequestId, "IX_RequestOffer_RequestID");

            entity.HasIndex(e => e.StatusId, "IX_RequestOffer_StatusID");

            entity.HasIndex(e => e.OfferNo, "UQ_RequestOffer_OfferNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcceptedAt).HasPrecision(0);
            entity.Property(e => e.ConvertedToSaleAt).HasPrecision(0);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.OfferDate)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.OfferNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('OFF-'+right(replicate('0',(10))+CONVERT([varchar](20),[OfferNoSequence]),(10)))", true);
            entity.Property(e => e.OfferNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_RequestOfferNo])");
            entity.Property(e => e.PreparedByEmployeeId).HasColumnName("PreparedByEmployeeID");
            entity.Property(e => e.RejectedAt).HasPrecision(0);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.SubTotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.ValidUntil).HasPrecision(0);

            entity.HasOne(d => d.Currency).WithMany(p => p.RequestOffers)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestOffer_Currency_CurrencyID");

            entity.HasOne(d => d.PreparedByEmployee).WithMany(p => p.RequestOffers)
                .HasForeignKey(d => d.PreparedByEmployeeId)
                .HasConstraintName("FK_RequestOffer_PreparedByEmployee_EmployeeID");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestOffers)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.RequestOffers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestOffer_Status_SysLookupItem");
        });

        modelBuilder.Entity<RequestOfferItem>(entity =>
        {
            entity.ToTable("RequestOfferItem");

            entity.HasIndex(e => e.RequestOfferId, "IX_RequestOfferItem_RequestOfferID");

            entity.HasIndex(e => e.ServiceTypeId, "IX_RequestOfferItem_ServiceTypeID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ExternalReferenceNo).HasMaxLength(100);
            entity.Property(e => e.OptionGroupCode).HasMaxLength(50);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProviderCompanyId).HasColumnName("ProviderCompanyID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.RequestOfferId).HasColumnName("RequestOfferID");
            entity.Property(e => e.ServiceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Currency).WithMany(p => p.RequestOfferItems)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestOfferItem_Currency_CurrencyID");

            entity.HasOne(d => d.ProviderCompany).WithMany(p => p.RequestOfferItems)
                .HasForeignKey(d => d.ProviderCompanyId)
                .HasConstraintName("FK_RequestOfferItem_ProviderCompany_CompanyID");

            entity.HasOne(d => d.RequestOffer).WithMany(p => p.RequestOfferItems)
                .HasForeignKey(d => d.RequestOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ServiceType).WithMany(p => p.RequestOfferItems)
                .HasForeignKey(d => d.ServiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestOfferItem_ServiceType_SysLookupItem");
        });

        modelBuilder.Entity<RequestOfferStatusHistory>(entity =>
        {
            entity.ToTable("RequestOfferStatusHistory");

            entity.HasIndex(e => new { e.RequestOfferId, e.ChangedAt }, "IX_RequestOfferStatusHistory_RequestOfferID_ChangedAt").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChangedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ChangedByEmployeeId).HasColumnName("ChangedByEmployeeID");
            entity.Property(e => e.NewStatusId).HasColumnName("NewStatusID");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.OldStatusId).HasColumnName("OldStatusID");
            entity.Property(e => e.RequestOfferId).HasColumnName("RequestOfferID");

            entity.HasOne(d => d.ChangedByEmployee).WithMany(p => p.RequestOfferStatusHistories)
                .HasForeignKey(d => d.ChangedByEmployeeId)
                .HasConstraintName("FK_RequestOfferStatusHistory_Employee");

            entity.HasOne(d => d.NewStatus).WithMany(p => p.RequestOfferStatusHistoryNewStatuses)
                .HasForeignKey(d => d.NewStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestOfferStatusHistory_NewStatus");

            entity.HasOne(d => d.OldStatus).WithMany(p => p.RequestOfferStatusHistoryOldStatuses)
                .HasForeignKey(d => d.OldStatusId)
                .HasConstraintName("FK_RequestOfferStatusHistory_OldStatus");

            entity.HasOne(d => d.RequestOffer).WithMany(p => p.RequestOfferStatusHistories)
                .HasForeignKey(d => d.RequestOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RequestStatusHistory>(entity =>
        {
            entity.ToTable("RequestStatusHistory");

            entity.HasIndex(e => new { e.RequestId, e.ChangedAt }, "IX_RequestStatusHistory_RequestID_ChangedAt").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChangedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ChangedByEmployeeId).HasColumnName("ChangedByEmployeeID");
            entity.Property(e => e.NewStatusId).HasColumnName("NewStatusID");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.OldStatusId).HasColumnName("OldStatusID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");

            entity.HasOne(d => d.ChangedByEmployee).WithMany(p => p.RequestStatusHistories)
                .HasForeignKey(d => d.ChangedByEmployeeId)
                .HasConstraintName("FK_RequestStatusHistory_Employee");

            entity.HasOne(d => d.NewStatus).WithMany(p => p.RequestStatusHistoryNewStatuses)
                .HasForeignKey(d => d.NewStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestStatusHistory_NewStatus");

            entity.HasOne(d => d.OldStatus).WithMany(p => p.RequestStatusHistoryOldStatuses)
                .HasForeignKey(d => d.OldStatusId)
                .HasConstraintName("FK_RequestStatusHistory_OldStatus");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestStatusHistories)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ServiceChargeLine>(entity =>
        {
            entity.ToTable("ServiceChargeLine");

            entity.HasIndex(e => e.ChargeTypeId, "IX_ServiceChargeLine_ChargeTypeID");

            entity.HasIndex(e => e.ServiceLineId, "IX_ServiceChargeLine_ServiceLineID");

            entity.HasIndex(e => e.TransactionLineId, "IX_ServiceChargeLine_TransactionLineID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChargeTypeId).HasColumnName("ChargeTypeID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsBillable).HasDefaultValue(true);
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ServiceLineId).HasColumnName("ServiceLineID");
            entity.Property(e => e.SourceReferenceNo).HasMaxLength(100);
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxRate).HasColumnType("decimal(9, 4)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionLineId).HasColumnName("TransactionLineID");
            entity.Property(e => e.UnitAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.ChargeType).WithMany(p => p.ServiceChargeLines)
                .HasForeignKey(d => d.ChargeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceChargeLine_ChargeType");

            entity.HasOne(d => d.Currency).WithMany(p => p.ServiceChargeLines)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceChargeLine_Currency");

            entity.HasOne(d => d.ServiceLine).WithMany(p => p.ServiceChargeLines)
                .HasForeignKey(d => d.ServiceLineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceChargeLine_ServiceLine");

            entity.HasOne(d => d.TransactionLine).WithMany(p => p.ServiceChargeLines)
                .HasForeignKey(d => d.TransactionLineId)
                .HasConstraintName("FK_ServiceChargeLine_TransactionLine");
        });

        modelBuilder.Entity<ServiceLine>(entity =>
        {
            entity.ToTable("ServiceLine");

            entity.HasIndex(e => e.CustomerId, "IX_ServiceLine_CustomerID");

            entity.HasIndex(e => e.TransactionId, "IX_ServiceLine_TransactionID");

            entity.HasIndex(e => e.TransactionLineId, "IX_ServiceLine_TransactionLineID");

            entity.HasIndex(e => e.ServiceLineNumber, "UQ_ServiceLine_ServiceLineNumber").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CostAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerContactEmploymentId).HasColumnName("CustomerContactEmploymentID");
            entity.Property(e => e.CustomerContactId).HasColumnName("CustomerContactID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsBillable).HasDefaultValue(true);
            entity.Property(e => e.ProviderCompanyId).HasColumnName("ProviderCompanyID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.SaleAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceEndAt).HasPrecision(0);
            entity.Property(e => e.ServiceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceLineNumber)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('SRV-'+right(replicate('0',(10))+CONVERT([varchar](20),[ServiceLineNumberSequence]),(10)))", true);
            entity.Property(e => e.ServiceLineNumberSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_ServiceLineNumber])");
            entity.Property(e => e.ServiceStartAt).HasPrecision(0);
            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionLineId).HasColumnName("TransactionLineID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Currency).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceLine_Currency");

            entity.HasOne(d => d.CustomerContactEmployment).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.CustomerContactEmploymentId)
                .HasConstraintName("FK_ServiceLine_CustomerContactEmployment");

            entity.HasOne(d => d.CustomerContact).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.CustomerContactId)
                .HasConstraintName("FK_ServiceLine_CustomerContact");

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceLine_Customer");

            entity.HasOne(d => d.ProviderCompany).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.ProviderCompanyId)
                .HasConstraintName("FK_ServiceLine_ProviderCompany");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.ServiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceLine_ServiceType");

            entity.HasOne(d => d.Transaction).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceLine_TransactionMaster");

            entity.HasOne(d => d.TransactionLine).WithMany(p => p.ServiceLines)
                .HasForeignKey(d => d.TransactionLineId)
                .HasConstraintName("FK_ServiceLine_TransactionLine");
        });

        modelBuilder.Entity<SysCurrency>(entity =>
        {
            entity.ToTable("SysCurrency");

            entity.HasIndex(e => e.Code, "UQ_SysCurrency_Code").IsUnique();

            entity.HasIndex(e => e.IsDefault, "UX_SysCurrency_OnlyOneDefault")
                .IsUnique()
                .HasFilter("([IsDefault]=(1))");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Symbol).HasMaxLength(10);
        });

        modelBuilder.Entity<SysLanguage>(entity =>
        {
            entity.ToTable("SysLanguage");

            entity.HasIndex(e => e.Code, "UQ_SysLanguage_Code").IsUnique();

            entity.HasIndex(e => e.ShortCode, "UQ_SysLanguage_ShortCode").IsUnique();

            entity.HasIndex(e => e.IsDefault, "UX_SysLanguage_OnlyOneDefault")
                .IsUnique()
                .HasFilter("([IsDefault]=(1))");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CultureName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ShortCode).HasMaxLength(5);
        });

        modelBuilder.Entity<SysLookupGroup>(entity =>
        {
            entity.ToTable("SysLookupGroup");

            entity.HasIndex(e => e.Code, "UQ_SysLookupGroup_Code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsSystem).HasDefaultValue(true);
            entity.Property(e => e.ResourceKey).HasMaxLength(250);
        });

        modelBuilder.Entity<SysLookupItem>(entity =>
        {
            entity.ToTable("SysLookupItem");

            entity.HasIndex(e => new { e.GroupId, e.SortOrder, e.Id }, "IX_SysLookupItem_GroupID_SortOrder");

            entity.HasIndex(e => new { e.GroupId, e.Code }, "UQ_SysLookupItem_Group_Code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsSystem).HasDefaultValue(true);
            entity.Property(e => e.ResourceKey).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(100);

            entity.HasOne(d => d.Group).WithMany(p => p.SysLookupItems)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysLookupItem_SysLookupGroup");
        });

        modelBuilder.Entity<SysResource>(entity =>
        {
            entity.ToTable("SysResource");

            entity.HasIndex(e => e.ResourceType, "IX_SysResource_ResourceType");

            entity.HasIndex(e => e.ResourceKey, "UQ_SysResource_ResourceKey").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsSystem).HasDefaultValue(true);
            entity.Property(e => e.ResourceKey).HasMaxLength(250);
            entity.Property(e => e.ResourceType).HasMaxLength(50);
        });

        modelBuilder.Entity<SysResourceTranslation>(entity =>
        {
            entity.ToTable("SysResourceTranslation");

            entity.HasIndex(e => new { e.ResourceId, e.LanguageId }, "UQ_SysResourceTranslation_Resource_Language").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsApproved).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

            entity.HasOne(d => d.Language).WithMany(p => p.SysResourceTranslations)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysResourceTranslation_SysLanguage");

            entity.HasOne(d => d.Resource).WithMany(p => p.SysResourceTranslations)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysResourceTranslation_SysResource");
        });

        modelBuilder.Entity<TransactionFlightTicket>(entity =>
        {
            entity.ToTable("TransactionFlightTicket");

            entity.HasIndex(e => e.Pnr, "IX_TransactionFlightTicket_Pnr");

            entity.HasIndex(e => e.TicketNumber, "IX_TransactionFlightTicket_TicketNumber");

            entity.HasIndex(e => e.TransactionId, "IX_TransactionFlightTicket_TransactionID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AirlineCode).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DepartureAt).HasPrecision(0);
            entity.Property(e => e.FareAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IssueDate).HasPrecision(0);
            entity.Property(e => e.PassengerName).HasMaxLength(200);
            entity.Property(e => e.PassengerTypeId).HasColumnName("PassengerTypeID");
            entity.Property(e => e.Pnr).HasMaxLength(20);
            entity.Property(e => e.ReturnAt).HasPrecision(0);
            entity.Property(e => e.RouteText).HasMaxLength(300);
            entity.Property(e => e.ServiceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TicketDocumentTypeId).HasColumnName("TicketDocumentTypeID");
            entity.Property(e => e.TicketNumber).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionLineId).HasColumnName("TransactionLineID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.PassengerType).WithMany(p => p.TransactionFlightTicketPassengerTypes)
                .HasForeignKey(d => d.PassengerTypeId)
                .HasConstraintName("FK_TransactionFlightTicket_PassengerType");

            entity.HasOne(d => d.TicketDocumentType).WithMany(p => p.TransactionFlightTicketTicketDocumentTypes)
                .HasForeignKey(d => d.TicketDocumentTypeId)
                .HasConstraintName("FK_TransactionFlightTicket_DocumentType");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionFlightTickets)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionFlightTicket_TransactionMaster");

            entity.HasOne(d => d.TransactionLine).WithMany(p => p.TransactionFlightTickets)
                .HasForeignKey(d => d.TransactionLineId)
                .HasConstraintName("FK_TransactionFlightTicket_TransactionLine");
        });

        modelBuilder.Entity<TransactionHotel>(entity =>
        {
            entity.ToTable("TransactionHotel");

            entity.HasIndex(e => e.TransactionId, "IX_TransactionHotel_TransactionID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.ConfirmationNo).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.GuestName).HasMaxLength(200);
            entity.Property(e => e.HotelName).HasMaxLength(250);
            entity.Property(e => e.RoomType).HasMaxLength(100);
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionLineId).HasColumnName("TransactionLineID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionHotels)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionHotel_TransactionMaster");

            entity.HasOne(d => d.TransactionLine).WithMany(p => p.TransactionHotels)
                .HasForeignKey(d => d.TransactionLineId)
                .HasConstraintName("FK_TransactionHotel_TransactionLine");
        });

        modelBuilder.Entity<TransactionLine>(entity =>
        {
            entity.ToTable("TransactionLine");

            entity.HasIndex(e => e.ServiceTypeId, "IX_TransactionLine_ServiceTypeID");

            entity.HasIndex(e => e.TransactionId, "IX_TransactionLine_TransactionID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerContactEmploymentId).HasColumnName("CustomerContactEmploymentID");
            entity.Property(e => e.CustomerContactId).HasColumnName("CustomerContactID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ExternalReferenceNo).HasMaxLength(100);
            entity.Property(e => e.ProviderCompanyId).HasColumnName("ProviderCompanyID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ServiceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");
            entity.Property(e => e.SourceRequestOfferItemId).HasColumnName("SourceRequestOfferItemID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalCostAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalSaleAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.UnitCostPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UnitSalePrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Currency).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionLine_Currency");

            entity.HasOne(d => d.CustomerContactEmployment).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.CustomerContactEmploymentId)
                .HasConstraintName("FK_TransactionLine_CustomerContactEmployment");

            entity.HasOne(d => d.CustomerContact).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.CustomerContactId)
                .HasConstraintName("FK_TransactionLine_CustomerContact");

            entity.HasOne(d => d.ProviderCompany).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.ProviderCompanyId)
                .HasConstraintName("FK_TransactionLine_ProviderCompany");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.ServiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionLine_ServiceType");

            entity.HasOne(d => d.SourceRequestOfferItem).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.SourceRequestOfferItemId)
                .HasConstraintName("FK_TransactionLine_SourceRequestOfferItem");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionLines)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TransactionMaster>(entity =>
        {
            entity.ToTable("TransactionMaster");

            entity.HasIndex(e => e.CustomerId, "IX_TransactionMaster_CustomerID");

            entity.HasIndex(e => e.StatusId, "IX_TransactionMaster_StatusID");

            entity.HasIndex(e => e.TransactionDate, "IX_TransactionMaster_TransactionDate").IsDescending();

            entity.HasIndex(e => e.TransactionNo, "UQ_TransactionMaster_TransactionNo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.CreatedByEmployeeId).HasColumnName("CreatedByEmployeeID");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerContactEmploymentId).HasColumnName("CustomerContactEmploymentID");
            entity.Property(e => e.CustomerContactId).HasColumnName("CustomerContactID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.MainServiceTypeId).HasColumnName("MainServiceTypeID");
            entity.Property(e => e.ServiceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SourceOfferId).HasColumnName("SourceOfferID");
            entity.Property(e => e.SourceRequestId).HasColumnName("SourceRequestID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalCostAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalSaleAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionDate)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasComputedColumnSql("('TRX-'+right(replicate('0',(10))+CONVERT([varchar](20),[TransactionNoSequence]),(10)))", true);
            entity.Property(e => e.TransactionNoSequence).HasDefaultValueSql("(NEXT VALUE FOR [dbo].[Seq_TransactionNo])");
            entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Company).WithMany(p => p.TransactionMasters).HasForeignKey(d => d.CompanyId);

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.TransactionMasters)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .HasConstraintName("FK_TransactionMaster_CreatedByEmployee");

            entity.HasOne(d => d.Currency).WithMany(p => p.TransactionMasters)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionMaster_Currency");

            entity.HasOne(d => d.CustomerContactEmployment).WithMany(p => p.TransactionMasters)
                .HasForeignKey(d => d.CustomerContactEmploymentId)
                .HasConstraintName("FK_TransactionMaster_CustomerContactEmployment");

            entity.HasOne(d => d.CustomerContact).WithMany(p => p.TransactionMasters)
                .HasForeignKey(d => d.CustomerContactId)
                .HasConstraintName("FK_TransactionMaster_CustomerContact");

            entity.HasOne(d => d.Customer).WithMany(p => p.TransactionMasters)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.MainServiceType).WithMany(p => p.TransactionMasterMainServiceTypes)
                .HasForeignKey(d => d.MainServiceTypeId)
                .HasConstraintName("FK_TransactionMaster_MainServiceType");

            entity.HasOne(d => d.SourceOffer).WithMany(p => p.TransactionMasters)
                .HasForeignKey(d => d.SourceOfferId)
                .HasConstraintName("FK_TransactionMaster_SourceOffer");

            entity.HasOne(d => d.SourceRequest).WithMany(p => p.TransactionMasters)
                .HasForeignKey(d => d.SourceRequestId)
                .HasConstraintName("FK_TransactionMaster_SourceRequest");

            entity.HasOne(d => d.Status).WithMany(p => p.TransactionMasterStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionMaster_Status");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.TransactionMasterTransactionTypes)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionMaster_TransactionType");
        });

        modelBuilder.Entity<TransactionRentAcar>(entity =>
        {
            entity.ToTable("TransactionRentACar");

            entity.HasIndex(e => e.TransactionId, "IX_TransactionRentACar_TransactionID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConfirmationNo).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DriverName).HasMaxLength(200);
            entity.Property(e => e.DropoffAt).HasPrecision(0);
            entity.Property(e => e.DropoffLocation).HasMaxLength(250);
            entity.Property(e => e.PickupAt).HasPrecision(0);
            entity.Property(e => e.PickupLocation).HasMaxLength(250);
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionLineId).HasColumnName("TransactionLineID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.VehicleGroup).HasMaxLength(100);

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionRentAcars)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionRentACar_TransactionMaster");

            entity.HasOne(d => d.TransactionLine).WithMany(p => p.TransactionRentAcars)
                .HasForeignKey(d => d.TransactionLineId)
                .HasConstraintName("FK_TransactionRentACar_TransactionLine");
        });

        modelBuilder.Entity<TransactionTransfer>(entity =>
        {
            entity.ToTable("TransactionTransfer");

            entity.HasIndex(e => e.TransactionId, "IX_TransactionTransfer_TransactionID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConfirmationNo).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DropoffLocation).HasMaxLength(250);
            entity.Property(e => e.PassengerName).HasMaxLength(200);
            entity.Property(e => e.PickupAt).HasPrecision(0);
            entity.Property(e => e.PickupLocation).HasMaxLength(250);
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionLineId).HasColumnName("TransactionLineID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.VehicleType).HasMaxLength(100);

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionTransfers)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionTransfer_TransactionMaster");

            entity.HasOne(d => d.TransactionLine).WithMany(p => p.TransactionTransfers)
                .HasForeignKey(d => d.TransactionLineId)
                .HasConstraintName("FK_TransactionTransfer_TransactionLine");
        });

        modelBuilder.Entity<TransactionVisa>(entity =>
        {
            entity.ToTable("TransactionVisa");

            entity.HasIndex(e => e.ApplicationNo, "IX_TransactionVisa_ApplicationNo");

            entity.HasIndex(e => e.TransactionId, "IX_TransactionVisa_TransactionID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicantFirstName).HasMaxLength(100);
            entity.Property(e => e.ApplicantLastName).HasMaxLength(100);
            entity.Property(e => e.ApplicationNo).HasMaxLength(100);
            entity.Property(e => e.AppointmentDate).HasPrecision(0);
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.StatusNote).HasMaxLength(1000);
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionLineId).HasColumnName("TransactionLineID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.VisaType).HasMaxLength(100);

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionVisas)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionVisa_TransactionMaster");

            entity.HasOne(d => d.TransactionLine).WithMany(p => p.TransactionVisas)
                .HasForeignKey(d => d.TransactionLineId)
                .HasConstraintName("FK_TransactionVisa_TransactionLine");
        });

        modelBuilder.Entity<TransactionVisaDocument>(entity =>
        {
            entity.ToTable("TransactionVisaDocument");

            entity.HasIndex(e => e.DocumentId, "IX_TransactionVisaDocument_DocumentID");

            entity.HasIndex(e => e.DocumentTypeId, "IX_TransactionVisaDocument_DocumentTypeID");

            entity.HasIndex(e => e.DocumentVersionId, "IX_TransactionVisaDocument_DocumentVersionID");

            entity.HasIndex(e => e.RequirementStatusId, "IX_TransactionVisaDocument_RequirementStatusID");

            entity.HasIndex(e => e.TransactionVisaId, "IX_TransactionVisaDocument_TransactionVisaID");

            entity.HasIndex(e => new { e.TransactionVisaId, e.DocumentTypeId, e.LineNumber }, "UQ_TransactionVisaDocument_Line").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovedAt).HasPrecision(0);
            entity.Property(e => e.ApprovedByEmployeeId).HasColumnName("ApprovedByEmployeeID");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.DocumentVersionId).HasColumnName("DocumentVersionID");
            entity.Property(e => e.LineNumber).HasDefaultValue(1);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.ReceivedAt).HasPrecision(0);
            entity.Property(e => e.RejectReason).HasMaxLength(1000);
            entity.Property(e => e.RejectedAt).HasPrecision(0);
            entity.Property(e => e.RejectedByEmployeeId).HasColumnName("RejectedByEmployeeID");
            entity.Property(e => e.RequestedAt).HasPrecision(0);
            entity.Property(e => e.RequirementStatusId).HasColumnName("RequirementStatusID");
            entity.Property(e => e.TransactionVisaId).HasColumnName("TransactionVisaID");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.VisaDocumentRuleId).HasColumnName("VisaDocumentRuleID");

            entity.HasOne(d => d.ApprovedByEmployee).WithMany(p => p.TransactionVisaDocumentApprovedByEmployees)
                .HasForeignKey(d => d.ApprovedByEmployeeId)
                .HasConstraintName("FK_TransactionVisaDocument_ApprovedByEmployee");

            entity.HasOne(d => d.Document).WithMany(p => p.TransactionVisaDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK_TransactionVisaDocument_Document");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.TransactionVisaDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionVisaDocument_DocumentType");

            entity.HasOne(d => d.DocumentVersion).WithMany(p => p.TransactionVisaDocuments)
                .HasForeignKey(d => d.DocumentVersionId)
                .HasConstraintName("FK_TransactionVisaDocument_DocumentVersion");

            entity.HasOne(d => d.RejectedByEmployee).WithMany(p => p.TransactionVisaDocumentRejectedByEmployees)
                .HasForeignKey(d => d.RejectedByEmployeeId)
                .HasConstraintName("FK_TransactionVisaDocument_RejectedByEmployee");

            entity.HasOne(d => d.RequirementStatus).WithMany(p => p.TransactionVisaDocuments)
                .HasForeignKey(d => d.RequirementStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionVisaDocument_RequirementStatus");

            entity.HasOne(d => d.TransactionVisa).WithMany(p => p.TransactionVisaDocuments)
                .HasForeignKey(d => d.TransactionVisaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransactionVisaDocument_TransactionVisa");

            entity.HasOne(d => d.VisaDocumentRule).WithMany(p => p.TransactionVisaDocuments)
                .HasForeignKey(d => d.VisaDocumentRuleId)
                .HasConstraintName("FK_TransactionVisaDocument_VisaDocumentRule");
        });

        modelBuilder.Entity<VisaDocumentRule>(entity =>
        {
            entity.ToTable("VisaDocumentRule");

            entity.HasIndex(e => new { e.CountryCode, e.VisaType, e.IsActive }, "IX_VisaDocumentRule_Country_VisaType");

            entity.HasIndex(e => e.DocumentTypeId, "IX_VisaDocumentRule_DocumentTypeID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsRequired).HasDefaultValue(true);
            entity.Property(e => e.IsReusableAllowed).HasDefaultValue(true);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.VisaType).HasMaxLength(100);

            entity.HasOne(d => d.DocumentType).WithMany(p => p.VisaDocumentRules)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisaDocumentRule_DocumentType");
        });

        modelBuilder.Entity<VwBillingPlanSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_BillingPlanSummary");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerTitle).HasMaxLength(250);
            entity.Property(e => e.DetailAmount).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.DistributionMethodCode).HasMaxLength(100);
            entity.Property(e => e.DistributionMethodId).HasColumnName("DistributionMethodID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PlanNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.StatusCode).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TotalPlanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(14)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwDocumentCurrentVersion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DocumentCurrentVersion");

            entity.Property(e => e.BlobNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.CurrentDocumentVersionId).HasColumnName("CurrentDocumentVersionID");
            entity.Property(e => e.DocumentBlobId).HasColumnName("DocumentBlobID");
            entity.Property(e => e.DocumentNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.DocumentTypeCode).HasMaxLength(80);
            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.DocumentTypeResourceKey).HasMaxLength(250);
            entity.Property(e => e.ExternalDocumentNo).HasMaxLength(100);
            entity.Property(e => e.FileExtension).HasMaxLength(20);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IssuingCountryCode).HasMaxLength(10);
            entity.Property(e => e.MimeType).HasMaxLength(150);
            entity.Property(e => e.OriginalFileName).HasMaxLength(260);
            entity.Property(e => e.OwnerCompanyId).HasColumnName("OwnerCompanyID");
            entity.Property(e => e.OwnerCompanyTitle).HasMaxLength(250);
            entity.Property(e => e.OwnerContactName).HasMaxLength(201);
            entity.Property(e => e.OwnerCustomerContactId).HasColumnName("OwnerCustomerContactID");
            entity.Property(e => e.OwnerCustomerId).HasColumnName("OwnerCustomerID");
            entity.Property(e => e.OwnerCustomerTitle).HasMaxLength(250);
            entity.Property(e => e.Sha256Hash)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StatusCode).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusResourceKey).HasMaxLength(250);
            entity.Property(e => e.StorageContainer).HasMaxLength(200);
            entity.Property(e => e.StorageObjectKey).HasMaxLength(1000);
            entity.Property(e => e.StorageProviderCode).HasMaxLength(100);
            entity.Property(e => e.StorageProviderId).HasColumnName("StorageProviderID");
            entity.Property(e => e.StorageRelativePath).HasMaxLength(1000);
            entity.Property(e => e.StoredFileName).HasMaxLength(260);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.UploadedAt).HasPrecision(0);
            entity.Property(e => e.VerificationStatusCode).HasMaxLength(100);
            entity.Property(e => e.VerificationStatusId).HasColumnName("VerificationStatusID");
        });

        modelBuilder.Entity<VwProjectList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectList");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerTitle).HasMaxLength(250);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProgressPercent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ProjectName).HasMaxLength(250);
            entity.Property(e => e.ProjectNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.SourceTransactionId).HasColumnName("SourceTransactionID");
            entity.Property(e => e.StatusCode).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusResourceKey).HasMaxLength(250);
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(14)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwRequestList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RequestList");

            entity.Property(e => e.AssignedEmployeeId).HasColumnName("AssignedEmployeeID");
            entity.Property(e => e.AssignedEmployeeName).HasMaxLength(201);
            entity.Property(e => e.ChannelCode).HasMaxLength(100);
            entity.Property(e => e.ChannelId).HasColumnName("ChannelID");
            entity.Property(e => e.ChannelResourceKey).HasMaxLength(250);
            entity.Property(e => e.ClosedAt).HasPrecision(0);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CompanyTitle).HasMaxLength(250);
            entity.Property(e => e.CreatedAt).HasPrecision(0);
            entity.Property(e => e.CustomerContactId).HasColumnName("CustomerContactID");
            entity.Property(e => e.CustomerContactName).HasMaxLength(201);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerTitle).HasMaxLength(250);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.RequestTypeCode).HasMaxLength(100);
            entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");
            entity.Property(e => e.RequestTypeResourceKey).HasMaxLength(250);
            entity.Property(e => e.StatusCode).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusResourceKey).HasMaxLength(250);
            entity.Property(e => e.Subject).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
        });

        modelBuilder.Entity<VwServiceChargeLine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ServiceChargeLine");

            entity.Property(e => e.ChargeTypeCode).HasMaxLength(100);
            entity.Property(e => e.ChargeTypeId).HasColumnName("ChargeTypeID");
            entity.Property(e => e.ChargeTypeResourceKey).HasMaxLength(250);
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerTitle).HasMaxLength(250);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ServiceLineNumber)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.ServiceTypeCode).HasMaxLength(100);
            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxRate).HasColumnType("decimal(9, 4)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.UnitAmount).HasColumnType("decimal(18, 4)");
        });

        modelBuilder.Entity<VwSysLookupItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SysLookupItem");

            entity.Property(e => e.GroupCode).HasMaxLength(100);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemCode).HasMaxLength(100);
            entity.Property(e => e.ResourceKey).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(100);
        });

        modelBuilder.Entity<VwTransactionList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TransactionList");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerTitle).HasMaxLength(250);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MainServiceTypeCode).HasMaxLength(100);
            entity.Property(e => e.MainServiceTypeId).HasColumnName("MainServiceTypeID");
            entity.Property(e => e.ProfitAmount).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.ServiceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SourceOfferId).HasColumnName("SourceOfferID");
            entity.Property(e => e.SourceRequestId).HasColumnName("SourceRequestID");
            entity.Property(e => e.StatusCode).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusResourceKey).HasMaxLength(250);
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalCostAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalSaleAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionDate).HasPrecision(0);
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.TransactionTypeCode).HasMaxLength(100);
            entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");
            entity.Property(e => e.TransactionTypeResourceKey).HasMaxLength(250);
        });

        modelBuilder.Entity<VwTransactionVisaDocumentStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TransactionVisaDocumentStatus");

            entity.Property(e => e.ApplicantName).HasMaxLength(201);
            entity.Property(e => e.ApprovedAt).HasPrecision(0);
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.DocumentTypeCode).HasMaxLength(80);
            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");
            entity.Property(e => e.DocumentTypeResourceKey).HasMaxLength(250);
            entity.Property(e => e.DocumentVersionId).HasColumnName("DocumentVersionID");
            entity.Property(e => e.FileExtension).HasMaxLength(20);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.OriginalFileName).HasMaxLength(260);
            entity.Property(e => e.ReceivedAt).HasPrecision(0);
            entity.Property(e => e.RejectReason).HasMaxLength(1000);
            entity.Property(e => e.RejectedAt).HasPrecision(0);
            entity.Property(e => e.RequestedAt).HasPrecision(0);
            entity.Property(e => e.RequirementStatusCode).HasMaxLength(100);
            entity.Property(e => e.RequirementStatusId).HasColumnName("RequirementStatusID");
            entity.Property(e => e.RequirementStatusResourceKey).HasMaxLength(250);
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.TransactionVisaId).HasColumnName("TransactionVisaID");
            entity.Property(e => e.VisaType).HasMaxLength(100);
        });
        modelBuilder.HasSequence("Seq_BillingPlanNo");
        modelBuilder.HasSequence("Seq_CurrentAccountNo");
        modelBuilder.HasSequence("Seq_DocumentBlobNo");
        modelBuilder.HasSequence("Seq_DocumentNo");
        modelBuilder.HasSequence("Seq_InvoiceBatchNo");
        modelBuilder.HasSequence("Seq_InvoiceNo");
        modelBuilder.HasSequence("Seq_PaymentNo");
        modelBuilder.HasSequence("Seq_ProjectNo");
        modelBuilder.HasSequence("Seq_ProjectTaskNo");
        modelBuilder.HasSequence("Seq_RequestNo");
        modelBuilder.HasSequence("Seq_RequestOfferNo");
        modelBuilder.HasSequence("Seq_ServiceLineNumber");
        modelBuilder.HasSequence("Seq_TransactionNo");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
