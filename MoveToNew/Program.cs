using Facile.Governance.AppraisalManagement;
using Facile.Governance.AssetTracker;
using Facile.Governance.InvoiceManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoveToNew;
using MoveToNew.Common;

class Program
{
    static async Task Main(string[] args)
    {
        var connectionString = "Host=192.168.1.37; Database=GovernanceDb; Username=postgres; Password=admin@123;";

        var serviceProvider = new ServiceCollection()
            .AddDbContext<GovernanceDbContext>(options => options.UseNpgsql(connectionString))
            .BuildServiceProvider();



        using (var context = serviceProvider.GetService<GovernanceDbContext>())
        {

            // Keyword

            var prospectKeywords = context.ProspectKeywords.Where(x => x.IsDeleted == false).ToList();
            var contentKeywords = context.ContentKeywords.Where(x => x.IsDeleted == false).ToList();
            var keywordList = context.Keywords.Where(x => x.IsDeleted == false).ToList();

            var keywords = new List<Keyword>();

            foreach (var keyword in prospectKeywords)
            {
                var dto = new Keyword
                {
                    Name = keyword.Name,
                    IdentyType = 1,
                    CreationTime = keyword.CreationTime,
                    CreatorUserId = keyword.CreatorUserId
                };
                if (!keywordList.Any(x => x.Name == dto.Name && x.IdentyType == dto.IdentyType))
                {
                    keywords.Add(dto);
                }
            }

            foreach (var keyword in contentKeywords)
            {
                var dto = new Keyword
                {
                    Name = keyword.Name,
                    IdentyType = 2,
                    CreationTime = keyword.CreationTime,
                    CreatorUserId = keyword.CreatorUserId
                };
                if (!keywordList.Any(x => x.Name == dto.Name && x.IdentyType == dto.IdentyType))
                {
                    keywords.Add(dto);
                }
            }
            context.Keywords.AddRange(keywords);
            await context.SaveChangesAsync();

            var contents = context.Contents.Where(x => x.IsDeleted == false).ToList();

            contents = contents.Select(content =>
            {
                string ProspectKeyword = "";
                if (content.Keyword != null)
                {
                    var PKeywords = content.Keyword.Split(",");

                    foreach (var item in PKeywords)
                    {
                        var data = int.Parse(item) + prospectKeywords.Count;
                        if (ProspectKeyword == "")
                        {
                            ProspectKeyword = data.ToString();
                        }
                        else
                        {
                            ProspectKeyword = ProspectKeyword + "," + data.ToString();
                        }
                    }
                    content.Keyword = ProspectKeyword;
                }
                return content;
            }).Where(x => x.IsDeleted == false).ToList();

            context.Contents.UpdateRange(contents);
            await context.SaveChangesAsync();

            //Priority

            var priority = context.Priorities.Where(x => x.IsDeleted == false).ToList();
            var leadPriority = context.LeadPriorities.Where(x => x.IsDeleted == false).ToList();

            var prioritys = new List<Priority>();

            priority = priority.Select(item =>
            {
                item.IdentyType = 1;
                return item;
            }).ToList();

            context.Priorities.UpdateRange(priority);
            context.SaveChanges();

            foreach (var data in leadPriority)
            {
                var dto = new Priority
                {
                    Name = data.Name,
                    IdentyType = 2,
                    CreationTime = data.CreationTime,
                    CreatorUserId = data.CreatorUserId
                };
                if (!priority.Any(x => x.Name == dto.Name && x.IdentyType == dto.IdentyType))
                {
                    prioritys.Add(dto);
                }
            }

            context.Priorities.AddRange(prioritys);
            context.SaveChanges();

            //LeadPriorities
            var leadss = context.Leads.Where(x => x.IsDeleted == false).ToList();

            leadss = leadss.Select(item =>
            {
                item.PrioritysId = item.PriorityId + priority.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Leads.UpdateRange(leadss);
            context.SaveChanges();


            //Country

            var country = context.Countries.Where(x => x.IsDeleted == false).ToList();
            var salesCountry = context.SalesCountries.Where(x => x.IsDeleted == false).ToList();

            var countries = new List<Country>();
            foreach (var data in salesCountry)
            {
                var dto = new Country
                {
                    Name = data.Name,
                    CreationTime = data.CreationTime,
                    CreatorUserId = data.CreatorUserId,
                };
                if (!country.Any(x => x.Name == data.Name))
                {
                    countries.Add(dto);
                }
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            var allCountry = context.Countries.Where(x => x.IsDeleted == false).ToList();

            //SalesCountries
            var bids = context.Bids.Where(x => x.IsDeleted == false).ToList();

            bids = bids.Select(item =>
            {
                var name = salesCountry.FirstOrDefault(x => x.Id == item.ClientCountryId).Name;
                var id = allCountry.FirstOrDefault(x => x.Name == name).Id;
                item.CountrysId = id;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Bids.UpdateRange(bids);
            context.SaveChanges();

            var prospects = context.Prospects.Where(x => x.IsDeleted == false).ToList();

            prospects = prospects.Select(item =>
            {
                var name = salesCountry.FirstOrDefault(x => x.Id == item.CountryId).Name;
                var id = allCountry.FirstOrDefault(x => x.Name == name).Id;
                item.CountrysId = id;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Prospects.UpdateRange(prospects);
            context.SaveChanges();

            var salesRegions = context.SalesRegions.Where(x => x.IsDeleted == false).ToList();

            salesRegions = salesRegions.Select(item =>
            {
                var name = salesCountry.FirstOrDefault(x => x.Id == item.CountryId).Name;
                var id = allCountry.FirstOrDefault(x => x.Name == name).Id;
                item.CountrysId = id;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.SalesRegions.UpdateRange(salesRegions);
            context.SaveChanges();

            //Project

            var project = context.Projects.Where(x => x.IsDeleted == false).ToList();
            var timesheetProject = context.TimesheetProject.Where(x => x.IsDeleted == false).ToList();

            var projects = new List<Project>();

            foreach (var data in timesheetProject)
            {
                var dto = new Project
                {
                    Name = data.Name,
                    CreationTime = data.CreationTime,
                    CreatorUserId = data.CreatorUserId,
                };
                if (!project.Any(x => x.Name == data.Name))
                {
                    projects.Add(dto);
                }
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();


            var allProject = context.Projects.Where(x => x.IsDeleted == false).ToList();

            //TimesheetProject
            var timesheet = context.Timesheet.Where(x => x.IsDeleted == false).ToList();

            timesheet = timesheet.Select(item =>
            {

                var name = timesheetProject.FirstOrDefault(x => x.Id == item.ProjectId).Name;
                var id = allProject.FirstOrDefault(x => x.Name == name).Id;
                item.ProjectsId = id;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Timesheet.UpdateRange(timesheet);
            context.SaveChanges();

            var timesheetEmpProjects = context.TimesheetEmployeeProjects.Where(x => x.IsDeleted == false).ToList();

            timesheetEmpProjects = timesheetEmpProjects.Select(item =>
            {
                var name = timesheetProject.FirstOrDefault(x => x.Id == item.ProjectId).Name;
                var id = allProject.FirstOrDefault(x => x.Name == name).Id;
                item.ProjectsId = id;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.TimesheetEmployeeProjects.UpdateRange(timesheetEmpProjects);
            context.SaveChanges();


            //Status

            var allStatus = context.Status.Where(x => x.IsDeleted == false).ToList();
            var timesheetStatus = context.TimesheetStatus.Where(x => x.IsDeleted == false).ToList();
            var taskStatus = context.TaskStatuses.Where(x => x.IsDeleted == false).ToList();
            var prospectStatus = context.ProspectStatuses.Where(x => x.IsDeleted == false).ToList();
            var leadStatus = context.LeadStatuses.Where(x => x.IsDeleted == false).ToList();
            var assetStatus = allStatus.Where(x => x.IdentyType == 0).Where(x => x.IsDeleted == false).ToList();
            var leadMessageStatus = context.LeadMessageStatuses.Where(x => x.IsDeleted == false).ToList();
            var contentStatus = context.ContentStatuses.Where(x => x.IsDeleted == false).ToList();
            var campaignStatus = context.CampaignStatuses.Where(x => x.IsDeleted == false).ToList();
            var bidStatus = context.BidStatuses.Where(x => x.IsDeleted == false).ToList();
            var actionStatus = context.ActionStatuses.Where(x => x.IsDeleted == false).ToList();
            var invoiceStatus = context.InvoiceStatuses.Where(x => x.IsDeleted == false).ToList();
            var changeRequestStatus = context.ChangeRequestStatus.Where(x => x.IsDeleted == false).ToList();
            var improvementAreaStatus = context.ImprovementAreaStatuses.Where(x => x.IsDeleted == false).ToList();

            var statuses = new List<Status>();

            assetStatus = assetStatus.Select(item =>
            {
                item.IdentyType = 5;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();

            context.Status.UpdateRange(assetStatus);
            context.SaveChanges();

            foreach (var status in timesheetStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 1,
                    IsActive = status.IsActive,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId,
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in taskStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 2,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId,
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in prospectStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 3,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId,
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in leadStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 4,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId,
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in leadMessageStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 6,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId,
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in contentStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 7,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in campaignStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 8,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in bidStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 9,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in actionStatus)
            {
                var dto = new Status
                {
                    Name = status.Status,
                    IdentyType = 10,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId
                };
                if (!allStatus.Any(x => x.Name == status.Status && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in invoiceStatus)
            {
                var dto = new Status
                {
                    Name = status.Name,
                    IdentyType = 11,
                    IsActive = status.IsActive,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId
                };
                if (!allStatus.Any(x => x.Name == status.Name && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }
            }
            foreach (var status in changeRequestStatus)
            {
                var dto = new Status
                {
                    Name = status.ChangeRequestStatus,
                    IdentyType = 12,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId
                };
                if (!allStatus.Any(x => x.Name == status.ChangeRequestStatus && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }

            }
            foreach (var status in improvementAreaStatus)
            {
                var dto = new Status
                {
                    Name = status.StatusName,
                    IdentyType = 13,
                    CreationTime = status.CreationTime,
                    CreatorUserId = status.CreatorUserId
                };
                if (!allStatus.Any(x => x.Name == status.StatusName && x.IdentyType == dto.IdentyType))
                {
                    statuses.Add(dto);
                }

            }

            context.Status.AddRange(statuses);
            context.SaveChanges();

            //TimesheetStatus
            var timesheets = context.Timesheet.Where(x => x.IsDeleted == false).ToList();

            timesheets = timesheets.Select(item =>
            {
                item.StatusesId = item.StatusId + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();

            context.Timesheet.UpdateRange(timesheets);
            context.SaveChanges();


            //TaskStatuses
            var task = context.Tasks.Where(x => x.IsDeleted == false).ToList();

            task = task.Select(item =>
            {
                item.StatusesId = item.Status + timesheetStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();

            context.Tasks.UpdateRange(task);
            context.SaveChanges();


            var templateTask = context.TemplateTasks.Where(x => x.IsDeleted == false).ToList();

            templateTask = templateTask.Select(item =>
            {
                item.StatusesId = item.Status + timesheetStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.TemplateTasks.UpdateRange(templateTask);
            context.SaveChanges();


            //ProspectStatuses
            var prospect = context.Prospects.Where(x => x.IsDeleted == false).ToList();

            prospect = prospect.Select(item =>
            {
                item.StatusesId = item.StatusId + timesheetStatus.Count + taskStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Prospects.UpdateRange(prospect);
            context.SaveChanges();


            //LeadStatuses && LeadMessageStatuses
            var lead = context.Leads.Where(x => x.IsDeleted == false).ToList();

            lead = lead.Select(item =>
            {
                item.StatusesId = item.StatusId + prospectStatus.Count + timesheetStatus.Count + taskStatus.Count + assetStatus.Count;
                item.MessageStatusesId = item.StatusId + prospectStatus.Count + timesheetStatus.Count + taskStatus.Count + leadStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Leads.UpdateRange(lead);
            context.SaveChanges();


            //ContentStatuses
            var content = context.Contents.Where(x => x.IsDeleted == false).ToList();

            content = content.Select(item =>
            {
                item.StatusesId = item.Status + prospectStatus.Count + timesheetStatus.Count + taskStatus.Count + leadStatus.Count + leadMessageStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Contents.UpdateRange(content);
            context.SaveChanges();


            //CampaignStatuses
            var campaign = context.Campaigns.Where(x => x.IsDeleted == false).ToList();

            campaign = campaign.Select(item =>
            {
                item.StatusesId = item.StatusId + prospectStatus.Count + timesheetStatus.Count + taskStatus.Count + leadStatus.Count + leadMessageStatus.Count + contentStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Campaigns.UpdateRange(campaign);
            context.SaveChanges();


            //BidStatuses
            var bid = context.Bids.Where(x => x.IsDeleted == false).ToList();

            bid = bid.Select(item =>
            {
                item.StatusesId = item.StatusId + prospectStatus.Count + timesheetStatus.Count + taskStatus.Count + leadStatus.Count + leadMessageStatus.Count + contentStatus.Count + campaignStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Bids.UpdateRange(bid);
            context.SaveChanges();


            //ActionStatuses
            var action = context.Actions.Where(x => x.IsDeleted == false).ToList();

            action = action.Select(item =>
            {
                item.StatusesId = item.StatusId + prospectStatus.Count + timesheetStatus.Count + taskStatus.Count + leadStatus.Count + leadMessageStatus.Count + contentStatus.Count + campaignStatus.Count + bidStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Actions.UpdateRange(action);
            context.SaveChanges();


            //InvoiceStatuses
            var creditNote = context.CreditNotes.Where(x => x.IsDeleted == false).ToList();

            creditNote = creditNote.Select(item =>
            {
                item.StatusesId = item.InvoiceStatusId + prospectStatus.Count + timesheetStatus.Count + taskStatus.Count + leadStatus.Count + leadMessageStatus.Count + contentStatus.Count + campaignStatus.Count + bidStatus.Count + actionStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.CreditNotes.UpdateRange(creditNote);
            context.SaveChanges();

            var invoice = context.Invoices.Where(x => x.IsDeleted == false).ToList();

            invoice = invoice.Select(item =>
            {
                item.StatusesId = item.InvoiceStatusId + prospectStatus.Count +
                timesheetStatus.Count + taskStatus.Count + leadStatus.Count +
                leadMessageStatus.Count + contentStatus.Count + campaignStatus.Count +
                bidStatus.Count + actionStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Invoices.UpdateRange(invoice);
            context.SaveChanges();

            // change req

            var changeReqTracking = context.ChangeRequestTracking.Where(x => x.IsDeleted == false).ToList();

            changeReqTracking = changeReqTracking.Select(item =>
            {
                item.StatusesId = item.ChangeReqStatusId + prospectStatus.Count +
                timesheetStatus.Count + taskStatus.Count + leadStatus.Count +
                leadMessageStatus.Count + contentStatus.Count + campaignStatus.Count + bidStatus.Count +
                actionStatus.Count + invoiceStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.ChangeRequestTracking.UpdateRange(changeReqTracking);
            context.SaveChanges();

            // improvement area status

            var improvementArea = context.ImprovementAreas.Where(x => x.IsDeleted == false).ToList();

            improvementArea = improvementArea.Select(item =>
            {
                item.StatusesId = item.StatusId + prospectStatus.Count +
                timesheetStatus.Count + taskStatus.Count + leadStatus.Count +
                leadMessageStatus.Count + contentStatus.Count + campaignStatus.Count + bidStatus.Count +
                actionStatus.Count + invoiceStatus.Count +
                changeRequestStatus.Count + assetStatus.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.ImprovementAreas.UpdateRange(improvementArea);
            context.SaveChanges();

            //Types

            var typeses = context.Types.Where(x => x.IsDeleted == false).ToList();
            var assetType = context.AssetType.Where(x => x.IsDeleted == false).ToList();
            var bussinessType = context.BusinessTypes.Where(x => x.IsDeleted == false).ToList();
            var cmType = context.CMTypes.Where(x => x.IsDeleted == false).ToList();
            var callType = context.CallTypes.Where(x => x.IsDeleted == false).ToList();
            var campaignType = context.CampaignTypes.Where(x => x.IsDeleted == false).ToList();
            var emailTemplateType = context.EmailTemplateTypes.Where(x => x.IsDeleted == false).ToList();
            var leadAttachmentType = context.LeadAttachmentTypes.Where(x => x.IsDeleted == false).ToList();
            var leadConversionType = context.LeadConversionTypes.Where(x => x.IsDeleted == false).ToList();
            var leadType = context.LeadTypes.Where(x => x.IsDeleted == false).ToList();
            var salesTargetType = context.SalesTargetTypes.Where(x => x.IsDeleted == false).ToList();
            var employeeType = context.EmployeeType.Where(x => x.IsDeleted == false).ToList();
            var trackingType = context.Trackingtask.Where(x => x.IsDeleted == false).ToList();

            var types = new List<Facile.Governance.Common.Type>();

            foreach (var type in assetType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 1,
                    IsActive = type.IsActive,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId,
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in bussinessType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 2,
                    IsActive = type.IsActive,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId,
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in cmType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 3,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in callType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.CallTypeName,
                    IdentyType = 4,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.CallTypeName && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in campaignType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 5,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in emailTemplateType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 6,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in leadAttachmentType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 7,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in leadConversionType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 8,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in leadType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 9,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in salesTargetType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.Name,
                    IdentyType = 10,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.Name && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in employeeType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.EmployeeTypes,
                    IdentyType = 11,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.EmployeeTypes && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }
            foreach (var type in trackingType)
            {
                var dto = new Facile.Governance.Common.Type
                {
                    Name = type.TrackingType,
                    IdentyType = 12,
                    CreationTime = type.CreationTime,
                    CreatorUserId = type.CreatorUserId
                };
                if (!typeses.Any(x => x.Name == type.TrackingType && x.IdentyType == dto.IdentyType))
                {
                    types.Add(dto);
                }
            }

            context.Types.AddRange(types);
            context.SaveChanges();


            //AssetType
            var assets = context.Assets.Where(x => x.IsDeleted == false).ToList();

            assets = assets.Select(item =>
            {
                item.TypesId = item.TypeId;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Assets.UpdateRange(assets);
            context.SaveChanges();


            //CMTypes
            var cmRegisters = context.CMCashRegisters.Where(x => x.IsDeleted == false).ToList();

            cmRegisters = cmRegisters.Select(item =>
            {
                item.TypesId = item.TypeId + assetType.Count + bussinessType.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.CMCashRegisters.UpdateRange(cmRegisters);
            context.SaveChanges();

            //CallTypes

            var prospectCall = context.ProspectCalls.Where(x => x.IsDeleted == false).ToList();

            prospectCall = prospectCall.Select(item =>
            {
                item.TypesId = item.CallTypeId + assetType.Count + bussinessType.Count + cmType.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.ProspectCalls.UpdateRange(prospectCall);
            context.SaveChanges();


            //CampaignTypes
            var campaigns = context.Campaigns.Where(x => x.IsDeleted == false).ToList();

            campaigns = campaigns.Select(item =>
            {
                item.TypesId = item.TypeId + assetType.Count + bussinessType.Count + cmType.Count + callType.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Campaigns.UpdateRange(campaigns);
            context.SaveChanges();


            //EmailTemplateTypes
            var emailTemplate = context.EmailTemplates.Where(x => x.IsDeleted == false).ToList();

            emailTemplate = emailTemplate.Select(item =>
            {
                item.TypesId = item.EmailTemplateTypeId + assetType.Count + bussinessType.Count + cmType.Count + callType.Count + campaignType.Count;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.EmailTemplates.UpdateRange(emailTemplate);
            context.SaveChanges();


            //LeadAttachmentTypes
            var leadAttachment = context.LeadAttachments.Where(x => x.IsDeleted == false).ToList();

            leadAttachment = leadAttachment.Select(item =>
            {
                item.TypesId = item.TypeId + assetType.Count + bussinessType.Count + cmType.Count + callType.Count + campaignType.Count + emailTemplateType.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.LeadAttachments.UpdateRange(leadAttachment);
            context.SaveChanges();


            //LeadConversionTypes
            var leadConversion = context.LeadConversions.Where(x => x.IsDeleted == false).ToList();

            leadConversion = leadConversion.Select(item =>
            {
                item.TypesId = item.ConversionTypeId + assetType.Count + bussinessType.Count + cmType.Count + callType.Count + campaignType.Count + emailTemplateType.Count + leadAttachmentType.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.LeadConversions.UpdateRange(leadConversion);
            context.SaveChanges();


            //LeadType
            var leads = context.Leads.Where(x => x.IsDeleted == false).ToList();

            leads = leads.Select(item =>
            {
                item.TypesId = item.TypeId + assetType.Count + bussinessType.Count + cmType.Count + callType.Count + campaignType.Count + emailTemplateType.Count + leadAttachmentType.Count + leadConversionType.Count;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.Leads.UpdateRange(leads);
            context.SaveChanges();


            //SalesTargetTypes
            var salesTargets = context.SalesTargets.Where(x => x.IsDeleted == false).ToList();

            salesTargets = salesTargets.Select(item =>
            {
                item.TypesId = item.TargetTypeId + assetType.Count + bussinessType.Count + cmType.Count + callType.Count + campaignType.Count + emailTemplateType.Count + leadAttachmentType.Count + leadConversionType.Count + leadType.Count;

                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.SalesTargets.UpdateRange(salesTargets);
            context.SaveChanges();


            //EmployeeType
            var empSalarySeting = context.EmployeeSalarySettings.Where(x => x.IsDeleted == false).ToList();

            empSalarySeting = empSalarySeting.Select(item =>
            {
                item.TypesId = item.EmployeeTypeId + assetType.Count + bussinessType.Count + cmType.Count + callType.Count + campaignType.Count + emailTemplateType.Count + leadAttachmentType.Count + leadConversionType.Count + leadType.Count + salesTargetType.Count;
                return item;
            }).Where(x => x.IsDeleted == false).ToList();
            context.EmployeeSalarySettings.UpdateRange(empSalarySeting);
            context.SaveChanges();
        }
    }
}
