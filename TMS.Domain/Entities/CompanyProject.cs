namespace TMS.Domain.Entities
{
    public class CompanyProject : BaseEntity
    {
        public int CompanyProjectID { get; set; }
        public virtual Company Company { get; set; } = new Company();
        public virtual Project Project { get; set; } = new Project();
    }
}
