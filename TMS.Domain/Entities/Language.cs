using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.Entities
{
    public class Language : BaseEntity
    {
        public int LanguageID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string DisplayName { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 10)]
        public string ShortName { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 10)]
        public string Name { get; set; } = string.Empty;
    }
}
