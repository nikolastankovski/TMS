using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class Company : BaseEntity
    {
        public int CompanyID { get; set; }
        public long LogoID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string Address { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 50)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress), MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
