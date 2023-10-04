using Facile.Governance.AppraisalManagement;
using Facile.Governance.AssetTracker;
using Facile.Governance.CashManagement;
using Facile.Governance.Costing;
using Facile.Governance.InvoiceManagement;
using Facile.Governance.LeaveManagement;
using Facile.Governance.SalesManagement;
using Facile.Governance.TimesheetManagement;
using Microsoft.EntityFrameworkCore;
using MoveToNew.Common;
using MoveToNew.TimesheetManagement;

namespace MoveToNew
{
    public class GovernanceDbContext : DbContext
    {
        public GovernanceDbContext(DbContextOptions<GovernanceDbContext> options) : base(options)
        {
        }

        // common
        public virtual DbSet<ProspectKeyword> ProspectKeywords { get; set; }
        public virtual DbSet<ContentKeyword> ContentKeywords { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TimesheetStatus> TimesheetStatus { get; set; }
        public virtual DbSet<Timesheet> Timesheet { get; set; }
        public virtual DbSet<Facile.Governance.TaskManagement.TaskStatus> TaskStatuses { get; set; }
        public virtual DbSet<Facile.Governance.TaskManagement.Task> Tasks { get; set; }
        public virtual DbSet<Facile.Governance.TaskManagement.TemplateTask> TemplateTasks { get; set; }
        public virtual DbSet<ProspectStatus> ProspectStatuses { get; set; }
        public virtual DbSet<LeadStatus> LeadStatuses { get; set; }
        public virtual DbSet<LeadMessageStatus> LeadMessageStatuses { get; set; }
        public virtual DbSet<ContentStatus> ContentStatuses { get; set; }
        public virtual DbSet<CampaignStatus> CampaignStatuses { get; set; }
        public virtual DbSet<BidStatus> BidStatuses { get; set; }
        public virtual DbSet<ActionStatus> ActionStatuses { get; set; }
        public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; }

        public virtual DbSet<ChangeReqStatus> ChangeRequestStatus { get; set; }

        public virtual DbSet<ImprovementAreaStatus> ImprovementAreaStatuses { get; set; }
        public virtual DbSet<ChangeRequestTracking> ChangeRequestTracking { get; set; }
        public virtual DbSet<Prospect> Prospects { get; set; }

        public virtual DbSet<Campaign> Campaigns { get; set; }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<CreditNote> CreditNotes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Facile.Governance.AppraisalManagement.Action> Actions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Facile.Governance.Common.Type> Types { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<BusinessType> BusinessTypes { get; set; }
        public virtual DbSet<CMType> CMTypes { get; set; }
        public virtual DbSet<CallType> CallTypes { get; set; }
        public virtual DbSet<CampaignType> CampaignTypes { get; set; }
        public virtual DbSet<EmailTemplateType> EmailTemplateTypes { get; set; }
        public virtual DbSet<LeadAttachmentType> LeadAttachmentTypes { get; set; }
        public virtual DbSet<LeadConversionType> LeadConversionTypes { get; set;}
        public virtual DbSet<LeadType> LeadTypes { get; set; }
        public virtual DbSet<SalesTargetType> SalesTargetTypes { get; set; }
        public virtual DbSet<EmployeeType> EmployeeType { get; set; }
        public virtual DbSet<Trackingtask> Trackingtask { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<CMCashRegister> CMCashRegisters { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<LeadAttachment> LeadAttachments { get; set; }
        public virtual DbSet<LeadConversion> LeadConversions { get; set; }
        public virtual DbSet<SalesTarget> SalesTargets { get; set; }
        public virtual DbSet<EmployeeSalarySettings> EmployeeSalarySettings { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<LeadPriority> LeadPriorities { get; set; }
        public virtual DbSet<ImprovementArea> ImprovementAreas { get; set; }
        public virtual DbSet<ProspectCalls> ProspectCalls { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<SalesCountry> SalesCountries { get; set;}
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CompanySetting> CompanySettings { get; set; }
        public virtual DbSet<SalesRegion> SalesRegions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<TimesheetProject> TimesheetProject { get; set; }
        public virtual DbSet<ClientProject> ClientProjects { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        public virtual DbSet<ProjectResource> ProjectResources { get; set; }
        public virtual DbSet<ProjectTax> ProjectTaxes { get; set; }
        public virtual DbSet<TimesheetEmployeeProjects> TimesheetEmployeeProjects { get; set; }
    }

}