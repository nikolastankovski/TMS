using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Repositories;

namespace TMS.Infrastructure.Repositories
{
    public class ReferenceTypeLanguageRepository : Repository<ReferenceTypeLanguage>, IReferenceTypeLanguageRepository
    {
        public ReferenceTypeLanguageRepository(TMSDbContext context, ILogger<ReferenceTypeLanguage> logger) : base(context, logger) { }
    }
}
