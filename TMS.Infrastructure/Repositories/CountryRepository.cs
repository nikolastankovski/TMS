using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Repositories;

namespace TMS.Infrastructure.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(TMSDbContext context, ILogger<Country> logger) : base(context, logger) { }
    }
}
