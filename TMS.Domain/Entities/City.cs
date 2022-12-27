using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class City : BaseEntity
    {
        public int CityID { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50)]
        public string PostalCode { get; set; } = string.Empty;
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public virtual Country Country { get; set; } = new Country(); 
    }
}
