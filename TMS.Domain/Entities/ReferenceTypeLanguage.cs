namespace TMS.Domain.Entities
{
    public partial class ReferenceTypeLanguage : BaseEntity
    {
        public int ReferenceTypeLanguageId { get; set; }
        public int ReferenceTypeId { get; set; }
        public string Description { get; set; } = null!;
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; } = null!;
        public virtual ReferenceType ReferenceType { get; set; } = null!;
    }
}
