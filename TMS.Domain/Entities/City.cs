using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class City : BaseEntity
    {
        public int CityID { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50)]
        public string PostalCode { get; set; } = string.Empty;
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public int CountryID { get; set; }
        public int LanguageID { get; set; }
    }
}
