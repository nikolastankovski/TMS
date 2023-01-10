using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Repositories.BaseRepositories;

namespace TMS.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(TMSDbContext context, ILogger<Company> logger) : base(context, logger) { }
    }
}
