using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class Country : BaseEntity
    {
        public int CountryID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 10)]
        public string Code { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50)]
        public string Region { get; set; } = string.Empty;

        [DataType(DataType.Url)]
        [StringLength(maximumLength: 255)]
        public string FlagURL { get; set; } = string.Empty;
        public bool EUMember { get; set; } = false;

        [StringLength(maximumLength: 10)]
        public string PhoneCode { get; set; } = string.Empty;
    }
}
