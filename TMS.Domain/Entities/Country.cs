namespace TMS.Domain.Entities
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
            CountryLanguages = new HashSet<CountryLanguage>();
        }

        public int CountryId { get; set; }
        public string Code { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string FlagUrl { get; set; } = null!;
        public bool Eumember { get; set; }
        public string PhoneCode { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
    }
}
