namespace TMS.Domain.Entities
{
    public partial class Language : BaseEntity
    {
        public Language()
        {
            CityLanguages = new HashSet<CityLanguage>();
            CountryLanguages = new HashSet<CountryLanguage>();
            ReferenceLanguages = new HashSet<ReferenceLanguage>();
            ReferenceTypeLanguages = new HashSet<ReferenceTypeLanguage>();
        }

        public int LanguageId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<CityLanguage> CityLanguages { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
        public virtual ICollection<ReferenceLanguage> ReferenceLanguages { get; set; }
        public virtual ICollection<ReferenceTypeLanguage> ReferenceTypeLanguages { get; set; }
    }
}
