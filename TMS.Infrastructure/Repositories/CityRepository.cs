using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Repositories.BaseRepositories;

namespace TMS.Infrastructure.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(TMSDbContext context, ILogger<City> logger) : base(context, logger) { }
    }
}
