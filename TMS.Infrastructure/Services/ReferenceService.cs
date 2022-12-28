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
                model.ReferenceId = reference.ReferenceId;
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

        public bool Create(Reference reference, List<DTO_Language> refLngs)
        {
            if (reference == null)
                return false;

            refLngs.TryGetNonEnumeratedCount(out int count);
            if (refLngs == null || count == 0)
                return false;

            var createReference = _refRepo.Create(reference);

            if(!createReference.IsSuccess)
                return false;

            var referenceLng = refLngs.Select(x => new ReferenceLanguage() { Description = x.Description, ReferenceId = reference.ReferenceId, LanguageId = x.LanguageID }).ToList();

            var createRefLng = _refLngRepo.Create(referenceLng);

            return true;
        }

        public bool Edit(Reference reference, List<DTO_Language> referenceLangugeages)
        {
            if (reference == null)
                return false;

            var oldReference = _refRepo.GetById(reference.ReferenceId);

            if(oldReference != null)
            {
                oldReference.ReferenceTypeId = reference.ReferenceTypeId;
                oldReference.Code = reference.Code;

                var updateReference = _refRepo.Update(oldReference);

                if (!updateReference.IsSuccess)
                    return false;
            }

            referenceLangugeages.TryGetNonEnumeratedCount(out int count);
            if (referenceLangugeages == null || count == 0)
                return false;

            foreach(var lng in referenceLangugeages)
            {
                var oldRefLng = _refLngRepo.GetByRefIdAndLngId(referenceId: oldReference.ReferenceId, languageId: lng.LanguageID);

                if(oldRefLng == null)
                {
                    ReferenceLanguage refLng = new ReferenceLanguage()
                    {
                        ReferenceId = oldReference.ReferenceId,
                        LanguageId = lng.LanguageID,
                        Description = lng.Description
                    };

                    var createRefLng = _refLngRepo.Create(refLng);
                }
                else
                {
                    oldRefLng.Description = lng.Description;

                    var updateRefLng = _refLngRepo.Update(oldRefLng);
                }
            }

            return true;
        }
    }
}
