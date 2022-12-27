namespace TMS.Domain.Entities
{
    public class TeamProject : BaseEntity
    {
        public int TeamProjectID { get; set; }
        public virtual Team Team { get; set; } = new Team();
        public virtual Project Project { get; set; } = new Project(); 
    }
}
