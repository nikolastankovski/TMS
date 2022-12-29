using TMS.Domain.Entities;

namespace TMS.Application.Interfaces.Repositories
{
    public interface IReferenceTypeLanguageRepository : IRepository<ReferenceTypeLanguage>
    {
        ReferenceTypeLanguage? GetByRefTypeIdAndLngId(int referenceTypeId, int languageId);
        Task<ReferenceTypeLanguage?> GetByRefTypeIdAndLngIdAsync(int referenceTypeId, int languageId);
    }
}
