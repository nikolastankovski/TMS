using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class ReferenceLanguage : BaseEntity
    {
        public int ReferenceLanguageID { get; set; }
        public virtual Reference Reference { get; set; } = new Reference();

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 500)]
        public string Description { get; set; } = string.Empty;
        public virtual Language Language { get; set; } = new Language();
    }
}
