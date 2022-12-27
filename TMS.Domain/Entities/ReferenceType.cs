using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class ReferenceType : BaseEntity
    {
        public int ReferenceTypeID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 500)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50)]
        public string Code { get; set; } = string.Empty;
        public int LanguageID { get; set; }
    }
}
