namespace TMS.Domain.Entities
{
    public partial class ReferenceLanguage : BaseEntity
    {
        public int ReferenceLanguageId { get; set; }
        public int ReferenceId { get; set; }
        public string Description { get; set; } = null!;
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; } = null!;
        public virtual Reference Reference { get; set; } = null!;
    }
}
