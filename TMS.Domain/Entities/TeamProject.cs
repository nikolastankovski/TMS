namespace TMS.Domain.Entities
{
    public partial class TeamProject : BaseEntity
    {
        public int TeamProjectId { get; set; }
        public int TeamId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
