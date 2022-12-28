using TMS.Domain.Entities;

namespace TMS.Application.Interfaces.Repositories
{
    public interface IReferenceLanguageRepository : IRepository<ReferenceLanguage>
    {
        ReferenceLanguage? GetByRefIdAndLngId(int referenceId, int lngId);
        Task<ReferenceLanguage?> GetByRefIdAndLngIdAsync(int referenceId, int lngId);
    }
}
