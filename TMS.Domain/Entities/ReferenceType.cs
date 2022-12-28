namespace TMS.Domain.Entities
{
    public partial class ReferenceType : BaseEntity
    {
        public ReferenceType()
        {
            ReferenceTypeLanguages = new HashSet<ReferenceTypeLanguage>();
        }

        public int ReferenceTypeId { get; set; }
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int LanguageId { get; set; }

        public virtual ICollection<ReferenceTypeLanguage> ReferenceTypeLanguages { get; set; }
    }
}
