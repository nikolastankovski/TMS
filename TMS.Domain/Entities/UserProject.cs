namespace TMS.Domain.Entities
{
    public partial class UserProject : BaseEntity
    {
        public int UserProjectId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
