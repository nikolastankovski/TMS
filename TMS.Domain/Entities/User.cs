using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class User : BaseEntity
    {
        public int UserID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 450)]
        public string AspNetUserID { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public long ProfilePictureID { get; set; }
        public long CompanyID { get; set; }
        public long UserTypeID { get; set; }
        public long TeamID { get; set; }
    }
}
