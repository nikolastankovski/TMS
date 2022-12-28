namespace TMS.Domain.Entities
{
    public partial class Project : BaseEntity
    {
        public Project()
        {
            CompanyProjects = new HashSet<CompanyProject>();
            TeamProjects = new HashSet<TeamProject>();
            UserProjects = new HashSet<UserProject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<CompanyProject> CompanyProjects { get; set; }
        public virtual ICollection<TeamProject> TeamProjects { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
