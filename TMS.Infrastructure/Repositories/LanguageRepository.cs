using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Repositories.BaseRepositories;

namespace TMS.Infrastructure.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(TMSDbContext context, ILogger<Language> logger) : base(context, logger) { }
    }
}
