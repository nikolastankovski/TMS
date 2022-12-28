namespace TMS.Domain.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            UserProjects = new HashSet<UserProject>();
        }

        public int UserId { get; set; }
        public string AspNetUserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public long ProfilePictureId { get; set; }
        public long CompanyId { get; set; }
        public long UserTypeId { get; set; }
        public long TeamId { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
