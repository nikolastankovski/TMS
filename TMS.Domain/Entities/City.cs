namespace TMS.Domain.Entities
{
    public partial class City : BaseEntity
    {
        public City()
        {
            CityLanguages = new HashSet<CityLanguage>();
        }

        public int CityId { get; set; }
        public string PostalCode { get; set; } = null!;
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<CityLanguage> CityLanguages { get; set; }
    }
}
