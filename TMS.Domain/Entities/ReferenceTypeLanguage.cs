using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class ReferenceTypeLanguage : BaseEntity
    {
        public int ReferenceTypeLanguageID { get; set; }
        public virtual ReferenceType ReferenceType { get; set; } = new ReferenceType(); 

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 500)]
        public string Description { get; set; } = string.Empty;
        public virtual Language Language { get; set; } = new Language();
    }
}
