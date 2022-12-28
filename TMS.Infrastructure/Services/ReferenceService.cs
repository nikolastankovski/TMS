using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.DTO;
using TMS.Domain.Entities;

namespace TMS.Infrastructure.Services
{
    public class ReferenceService
    {
        public readonly IReferenceRepository _refRepo;
        public readonly IReferenceLanguageRepository _refLngRepo;
        public readonly IReferenceTypeRepository _refTypeRepo;
        public readonly IReferenceTypeLanguageRepository _refTypeLngRepo;
        public readonly ILanguageRepository _lngRepo;

        public ReferenceService(IReferenceRepository refRepo, IReferenceLanguageRepository refLngRepo, IReferenceTypeRepository refTypeRepo, IReferenceTypeLanguageRepository refTypeLngRepo, ILanguageRepository lngRepo)
        {
            _refRepo = refRepo;
            _refLngRepo = refLngRepo;
            _refTypeRepo = refTypeRepo;
            _refTypeLngRepo = refTypeLngRepo;
            _lngRepo = lngRepo;
        }
    }
}
