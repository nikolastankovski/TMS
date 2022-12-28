namespace TMS.Domain.Entities
{
    public partial class Team : BaseEntity
    {
        public Team()
        {
            TeamProjects = new HashSet<TeamProject>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<TeamProject> TeamProjects { get; set; }
    }
}
