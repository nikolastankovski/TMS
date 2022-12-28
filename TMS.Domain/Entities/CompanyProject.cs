namespace TMS.Domain.Entities
{
    public partial class CompanyProject : BaseEntity
    {
        public int CompanyProjectId { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
    }
}
