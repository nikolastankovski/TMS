namespace TMS.Domain.Entities
{
    public partial class CityLanguage : BaseEntity
    {
        public int CityLanguageId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; } = null!;
        public int LanguageId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}
