using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Repositories.BaseRepositories;

namespace TMS.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(TMSDbContext context, ILogger<Project> logger) : base(context, logger) { }
    }
}
