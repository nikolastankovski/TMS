namespace TMS.Domain.Entities
{
    public partial class Reference : BaseEntity
    {
        public Reference()
        {
            ReferenceLanguages = new HashSet<ReferenceLanguage>();
        }

        public int ReferenceId { get; set; }
        public int ReferenceTypeId { get; set; }
        public string Code { get; set; } = null!;

        public virtual ICollection<ReferenceLanguage> ReferenceLanguages { get; set; }
    }
}
