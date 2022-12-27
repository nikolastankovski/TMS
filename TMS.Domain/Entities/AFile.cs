using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TMS.Domain.Entities
{
    public class AFile : BaseEntity
    {
        public long AFileID { get; set; }
        public int FileTypeID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 10, MinimumLength = 2)]
        public string Extension { get; set; } = string.Empty;
        public byte[] Data { get; set; } = new byte[0];
    }
}
