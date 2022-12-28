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

        public DTO_Reference GetReferenceModel(int? referenceId = null)
        {
            var model = new DTO_Reference();

            var reference = _refRepo.Get(filter: x => x.ReferenceId == referenceId, includeProperties: "ReferenceLanguages,ReferenceLanguages.Language").FirstOrDefault();

            if (reference != null)
            {
                model.ReferenceTypeId = reference.ReferenceTypeId;
                model.Code = reference.Code;
                model.Languages = reference.ReferenceLanguages.Select(x => new DTO_Language() { Description = x.Description, DisplayName = x.Language.DisplayName, LanguageID = x.LanguageId }).ToList();
            }
            else
            {
                var languages = _lngRepo.GetAll();

                model.Languages = languages.Select(x => new DTO_Language() { DisplayName = x.DisplayName, LanguageID = x.LanguageId }).ToList();
            }

            return model;
        }

        public void Create(Reference reference, List<DTO_Language> refLngs)
        {
            _refRepo.Create(reference);

            var referenceLng = refLngs.Select(x => new ReferenceLanguage() { Description = x.Description, ReferenceId = reference.ReferenceId, LanguageId = x.LanguageID }).ToList();

            _refLngRepo.Create(referenceLng);
        }
    }
}
