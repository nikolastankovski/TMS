using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Domain.Entities;

namespace TMS.Domain.DTO
{
    public class DTO_Reference
    {
        public int ReferenceTypeId { get; set; }
        public string Code { get; set; } = string.Empty;
        public List<DTO_Language> Languages { get; set; } = new List<DTO_Language>();
    }
}
