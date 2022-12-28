using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Repositories;

namespace TMS.Infrastructure.Repositories
{
    public class ReferenceLanguageRepository : Repository<ReferenceLanguage>, IReferenceLanguageRepository
    {
        private readonly TMSDbContext _context;
        public ReferenceLanguageRepository(TMSDbContext context, ILogger<ReferenceLanguage> logger) : base(context, logger)
        {
            _context = context;
        }

        /*public ReferenceLanguage? GetByRefIdAndLngId(int referenceId, int lngId)
        {
            ReferenceLanguage? entity = _context.ReferenceLanguage
                                                        .Include(x => x.Reference)
                                                        .Include(x => x.Language)
                                                        .Where(x => x.Reference.ReferenceID == referenceId
                                                                    && x.Language.LanguageID == lngId
                                                        )
                                                        .FirstOrDefault();

            return entity;
        }

        public async Task<ReferenceLanguage?> GetByRefIdAndLngIdAsync(int referenceId, int lngId)
        {
            ReferenceLanguage? entity = await _context.ReferenceLanguage
                                                                    .Include(x => x.Reference)
                                                                    .Include(x => x.Language)
                                                                    .Where(x => x.Reference.ReferenceID == referenceId
                                                                                && x.Language.LanguageID == lngId
                                                                    )
                                                                    .FirstOrDefaultAsync();

            return entity;
        }*/
    }
}
