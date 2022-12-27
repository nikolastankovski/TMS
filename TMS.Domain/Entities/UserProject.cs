namespace TMS.Domain.Entities
{
    public class UserProject : BaseEntity
    {
        public int UserProjectID { get; set; }
        public virtual User User { get; set; } = new User();
        public virtual Project Project { get; set; } = new Project();
    }
}
