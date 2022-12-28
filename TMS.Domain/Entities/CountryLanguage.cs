namespace TMS.Domain.Entities
{
    public partial class CountryLanguage : BaseEntity
    {
        public int CountryLanguageId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public int LanguageId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}
