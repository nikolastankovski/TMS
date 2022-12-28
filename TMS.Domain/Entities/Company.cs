namespace TMS.Domain.Entities
{
    public partial class Company : BaseEntity
    {
        public Company()
        {
            CompanyProjects = new HashSet<CompanyProject>();
        }

        public int CompanyId { get; set; }
        public long LogoId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<CompanyProject> CompanyProjects { get; set; }
    }
}
