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

        public ReferenceLanguage? GetByRefIdAndLngId(int referenceId, int languageId)
        {
            ReferenceLanguage? entity = _context.ReferenceLanguage
                                                    .Include(x => x.Reference)
                                                    .Where(x => x.ReferenceId == referenceId
                                                                && x.LanguageId == languageId
                                                    )
                                                    .FirstOrDefault();

            return entity;
        }

        public async Task<ReferenceLanguage?> GetByRefIdAndLngIdAsync(int referenceId, int languageId)
        {
            ReferenceLanguage? entity = await _context.ReferenceLanguage
                                                            .Include(x => x.Reference)
                                                            .Where(x => x.ReferenceId == referenceId
                                                                        && x.LanguageId == languageId
                                                            )
                                                            .FirstOrDefaultAsync();

            return entity;
        }

        public List<ReferenceLanguage> GetByRefTypeIdAndLngId(int referenceTypeId, int languageId)
        {
            List<ReferenceLanguage> entities = _context.ReferenceLanguage
                                                            .Include(x => x.Reference)
                                                            .Where(x => x.Reference.ReferenceTypeId == referenceTypeId
                                                                        && x.LanguageId == languageId
                                                            )
                                                            .ToList();

            return entities;
        }
        public async Task<List<ReferenceLanguage>> GetByRefTypeIdAndLngIdAsync(int referenceTypeId, int languageId)
        {
            List<ReferenceLanguage> entities = await _context.ReferenceLanguage
                                                                .Include(x => x.Reference)
                                                                .Where(x => x.Reference.ReferenceTypeId == referenceTypeId
                                                                            && x.LanguageId == languageId
                                                                )
                                                                .ToListAsync();

            return entities;
        }
    }
}
