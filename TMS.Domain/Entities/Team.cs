using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class Team : BaseEntity
    {
        public int TeamID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 500)]
        public string Description { get; set; } = string.Empty;
    }
}
