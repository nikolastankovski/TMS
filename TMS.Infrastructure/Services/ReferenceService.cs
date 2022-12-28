using TMS.Application.Interfaces.Repositories;

namespace TMS.Infrastructure.Services
{
    public class ReferenceService
    {
        public readonly IReferenceRepository _refRepo;
        public readonly IReferenceLanguageRepository _refLngRepo;
        public readonly IReferenceTypeRepository _refTypeRepo;
        public readonly IReferenceTypeLanguageRepository _refTypeLngRepo;

        public ReferenceService(IReferenceRepository refRepo, IReferenceLanguageRepository refLngRepo, IReferenceTypeRepository refTypeRepo, IReferenceTypeLanguageRepository refTypeLngRepo)
        {
            _refRepo = refRepo;
            _refLngRepo = refLngRepo;
            _refTypeRepo = refTypeRepo;
            _refTypeLngRepo = refTypeLngRepo;
        }
    }
}
