using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Repositories;

namespace TMS.Infrastructure.Repositories
{
    public class ReferenceTypeLanguageRepository : Repository<ReferenceTypeLanguage>, IReferenceTypeLanguageRepository
    {
        private readonly TMSDbContext _context;

        public ReferenceTypeLanguageRepository(TMSDbContext context, ILogger<ReferenceTypeLanguage> logger) : base(context, logger) 
        {
            _context = context;
        }

        public ReferenceTypeLanguage? GetByRefTypeIdAndLngId(int referenceTypeId, int languageId)
        {
            ReferenceTypeLanguage? entity = _context.ReferenceTypeLanguage
                                                    .Where(x => x.ReferenceTypeId == referenceTypeId
                                                                && x.LanguageId == languageId
                                                    )
                                                    .Include(x => x.ReferenceType)
                                                    .FirstOrDefault();

            return entity;
        }

        public async Task<ReferenceTypeLanguage?> GetByRefTypeIdAndLngIdAsync(int referenceTypeId, int languageId)
        {
            ReferenceTypeLanguage? entity = await _context.ReferenceTypeLanguage
                                                            .Where(x => x.ReferenceTypeId == referenceTypeId
                                                                        && x.LanguageId == languageId
                                                            )
                                                            .Include(x => x.ReferenceType)
                                                            .FirstOrDefaultAsync();

            return entity;
        }
    }
}
