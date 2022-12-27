using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class CityLanguage
    {
        public int CityLanguageID { get; set; }
        public virtual City City { get; set; } = new City();

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; } = string.Empty;
        public virtual Language Language { get; set; } = new Language();
    }
}
