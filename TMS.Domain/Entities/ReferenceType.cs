namespace TMS.Domain.Entities
{
    public partial class ReferenceType : BaseEntity
    {
        public ReferenceType()
        {
            ReferenceTypeLanguages = new HashSet<ReferenceTypeLanguage>();
        }

        public int ReferenceTypeId { get; set; }
        public string Code { get; set; } = null!;

        public virtual ICollection<ReferenceTypeLanguage> ReferenceTypeLanguages { get; set; }
    }
}
