using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities
{
    public class CountryLanguage
    {
        public int CountryLanguageID { get; set; }
        public virtual Country Country { get; set; } = new Country();

        [DataType(DataType.Text)]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; } = string.Empty;
        public virtual Language Language { get; set; } = new Language();

    }
}
