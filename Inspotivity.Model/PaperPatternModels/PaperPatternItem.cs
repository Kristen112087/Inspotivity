using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.PaperPatternModels
{
    public class PaperPatternItem
    {
        public class PaperPatternItems
        {
            [Key]
            public int PaperPatternId { get; set; }
            [Required]
            public Guid OwnerId { get; set; }

            public string Designer { get; set; }
            public string PatternName { get; set; }

            [DefaultValue(false)]
            public bool HaveMade { get; set; }
        }
    }
}
