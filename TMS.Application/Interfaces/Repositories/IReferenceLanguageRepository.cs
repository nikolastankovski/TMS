using TMS.Domain.Entities;

namespace TMS.Application.Interfaces.Repositories
{
    public interface IReferenceLanguageRepository : IRepository<ReferenceLanguage>
    {
        ReferenceLanguage? GetByRefIdAndLngId(int referenceId, int languageId);
        Task<ReferenceLanguage?> GetByRefIdAndLngIdAsync(int referenceId, int languageId);
        List<ReferenceLanguage> GetByRefTypeIdAndLngId(int referenceTypeId, int languageId);
        Task<List<ReferenceLanguage>> GetByRefTypeIdAndLngIdAsync(int referenceTypeId, int languageId);
    }
}
