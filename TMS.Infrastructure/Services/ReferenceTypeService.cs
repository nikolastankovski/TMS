using TMS.Application.Interfaces.Repositories;
using TMS.Domain.DTO;
using TMS.Domain.Entities;

namespace TMS.Infrastructure.Services
{
    public class ReferenceTypeService
    {
        public readonly IReferenceTypeRepository _refTypeRepo;
        public readonly IReferenceTypeLanguageRepository _refTypeLngRepo;
        public readonly ILanguageRepository _lngRepo;

        public ReferenceTypeService(IReferenceTypeRepository refTypeRepo, IReferenceTypeLanguageRepository refTypeLngRepo, ILanguageRepository lngRepo)
        {
            _refTypeRepo = refTypeRepo;
            _refTypeLngRepo = refTypeLngRepo;
            _lngRepo = lngRepo;
        }

        public DTO_ReferenceType GetReferenceModel(int? referenceTypeId = null)
        {
            var model = new DTO_ReferenceType();

            var referenceType = _refTypeRepo.Get(filter: x => x.ReferenceTypeId == referenceTypeId, includeProperties: "ReferenceTypeLanguages,ReferenceTypeLanguages.Language").FirstOrDefault();

            if (referenceType != null)
            {
                model.ReferenceTypeId = referenceType.ReferenceTypeId;
                model.Code = referenceType.Code;
                model.Languages = referenceType.ReferenceTypeLanguages.Select(x => new DTO_Language() { Description = x.Description, DisplayName = x.Language.DisplayName, LanguageID = x.LanguageId }).ToList();
            }
            else
            {
                var languages = _lngRepo.GetAll();
                model.Languages = languages.Select(x => new DTO_Language() { DisplayName = x.DisplayName, LanguageID = x.LanguageId }).ToList();
            }

            return model;
        }

        public bool Create(ReferenceType referenceType, List<DTO_Language> refLngs)
        {
            if (referenceType == null)
                return false;

            refLngs.TryGetNonEnumeratedCount(out int count);
            if (refLngs == null || count == 0)
                return false;

            var createReferenceType = _refTypeRepo.Create(referenceType);

            if (!createReferenceType.IsSuccess)
                return false;

            var referenceTypeLng = refLngs.Select(x => new ReferenceTypeLanguage() { Description = x.Description, ReferenceTypeId = referenceType.ReferenceTypeId, LanguageId = x.LanguageID }).ToList();

            var createRefTypeLng = _refTypeLngRepo.Create(referenceTypeLng);

            return true;
        }

        public bool Edit(ReferenceType referenceType, List<DTO_Language> refTypeLanguages)
        {
            if (referenceType == null)
                return false;

            var oldRefType = _refTypeRepo.GetById(referenceType.ReferenceTypeId);

            if (oldRefType != null)
            {
                oldRefType.Code = referenceType.Code;

                var updateReference = _refTypeRepo.Update(oldRefType);

                if (!updateReference.IsSuccess)
                    return false;
            }

            refTypeLanguages.TryGetNonEnumeratedCount(out int count);
            if (refTypeLanguages == null || count == 0)
                return false;

            foreach (var lng in refTypeLanguages)
            {
                var oldRefLng = _refTypeLngRepo.GetByRefTypeIdAndLngId(referenceTypeId: oldRefType.ReferenceTypeId, languageId: lng.LanguageID);

                if (oldRefLng == null)
                {
                    ReferenceTypeLanguage refTypeLng = new ReferenceTypeLanguage()
                    {
                        ReferenceTypeId = oldRefType.ReferenceTypeId,
                        LanguageId = lng.LanguageID,
                        Description = lng.Description
                    };

                    var createRefLng = _refTypeLngRepo.Create(refTypeLng);
                }
                else
                {
                    oldRefLng.Description = lng.Description;

                    var updateRefLng = _refTypeLngRepo.Update(oldRefLng);
                }
            }

            return true;
        }
    }
}
