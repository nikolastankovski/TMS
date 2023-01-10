using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Repositories.BaseRepositories;

namespace TMS.Infrastructure.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(TMSDbContext context, ILogger<Country> logger) : base(context, logger) { }
    }
}
