using System.Transactions;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.DTO;
using TMS.Domain.Entities;

namespace TMS.Infrastructure.Services
{
    public class ReferenceService
    {
        public readonly IReferenceRepository _refRepo;
        public readonly IReferenceLanguageRepository _refLngRepo;
        public readonly ILanguageRepository _lngRepo;

        public ReferenceService(IReferenceRepository refRepo, IReferenceLanguageRepository refLngRepo, ILanguageRepository lngRepo)
        {
            _refRepo = refRepo;
            _refLngRepo = refLngRepo;
            _lngRepo = lngRepo;
        }

        public async Task<DTO_Reference> GetModelAsync(int? referenceId = null)
        {
            var model = new DTO_Reference();
            var languages = await _lngRepo.GetAllAsync();

            var getReference = await _refRepo.GetAsync(filter: x => x.ReferenceId == referenceId, includeProperties: "ReferenceLanguages,ReferenceLanguages.Language");
            var reference = getReference.FirstOrDefault();

            if (reference != null)
            {
                model.ReferenceId = reference.ReferenceId;
                model.ReferenceTypeId = reference.ReferenceTypeId;
                model.Code = reference.Code;

                languages.TryGetNonEnumeratedCount(out int countLng);
                reference.ReferenceLanguages.TryGetNonEnumeratedCount(out int countRefLng);

                model.Languages = reference.ReferenceLanguages.Select(x => new DTO_Language() { Description = x.Description, DisplayName = x.Language.DisplayName, LanguageID = x.LanguageId }).ToList();

                if (countLng != countRefLng)
                {
                    var existingLngsIds = reference.ReferenceLanguages.Select(x => x.LanguageId).ToList();
                    var missingLanguages = languages.Where(x => !existingLngsIds.Contains(x.LanguageId)).ToList();

                    if (missingLanguages.Count > 0)
                    {
                        var dtoLngs = missingLanguages.Select(x => new DTO_Language() { DisplayName = x.DisplayName, LanguageID = x.LanguageId }).ToList();
                        model.Languages.AddRange(dtoLngs);
                    }
                }
            }
            else
            {
                model.Languages = languages.Select(x => new DTO_Language() { DisplayName = x.DisplayName, LanguageID = x.LanguageId }).ToList();
            }

            return model;
        }

        public async Task<bool> CreateAsync(Reference reference, List<DTO_Language> refLanguages)
        {
            if (reference == null)
                return false;

            refLanguages.TryGetNonEnumeratedCount(out int count);
            if (refLanguages == null || count == 0)
                return false;

            using(var t = new TransactionScope())
            {
                var createReference = await _refRepo.CreateAsync(reference);

                if (!createReference.IsSuccess)
                {
                    t.Dispose();
                    return false;
                }

                var referenceLng = refLanguages.Select(x => new ReferenceLanguage() { Description = x.Description, ReferenceId = reference.ReferenceId, LanguageId = x.LanguageID }).ToList();
                var createRefLng = await _refLngRepo.CreateAsync(referenceLng);

                if (!createRefLng.IsSuccess)
                {
                    t.Dispose();
                    return false;
                }

                t.Complete();
                return true;
            }           
        }

        public async Task<bool> EditAsync(Reference reference, List<DTO_Language> refLanguages)
        {
            if (reference == null)
                return false;

            var oldReference = await _refRepo.GetByIdAsync(reference.ReferenceId);

            using(var t = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                if (oldReference != null)
                {
                    oldReference.ReferenceTypeId = reference.ReferenceTypeId;
                    oldReference.Code = reference.Code;

                    var updateReference = await _refRepo.UpdateAsync(oldReference);

                    if (!updateReference.IsSuccess)
                    {
                        t.Dispose();
                        return false;
                    }
                }

                foreach (var lng in refLanguages)
                {
                    var oldRefLng = await _refLngRepo.GetByRefIdAndLngIdAsync(referenceId: oldReference.ReferenceId, languageId: lng.LanguageID);

                    if (oldRefLng == null)
                    {
                        ReferenceLanguage refLng = new ReferenceLanguage()
                        {
                            ReferenceId = oldReference.ReferenceId,
                            LanguageId = lng.LanguageID,
                            Description = lng.Description
                        };

                        var createRefLng = await _refLngRepo.CreateAsync(refLng);

                        if(!createRefLng.IsSuccess)
                        {
                            t.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        oldRefLng.Description = lng.Description;

                        var updateRefLng = await _refLngRepo.UpdateAsync(oldRefLng);

                        if (!updateRefLng.IsSuccess)
                        {
                            t.Dispose();
                            return false;
                        }
                    }
                }

                t.Complete();
                return true;
            }
        }
    }
}
