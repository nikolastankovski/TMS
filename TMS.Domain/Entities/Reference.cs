using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class Reference : BaseEntity
    {
        public int ReferenceID { get; set; }
        public int ReferenceTypeID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 500)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 10)]
        public string Code { get; set; } = string.Empty;
        public int LanguageID { get; set; }
    }
}
