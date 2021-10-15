using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.PaperPatternModels
{
    public class PaperPatternItem
    {

        [Key]
        public int PaperPatternId { get; set; }
        [ForeignKey(nameof(Guid))]
        public virtual Guid OwnerId { get; set; }

        public string Designer { get; set; }
        public string PatternName { get; set; }
        public string WhereStored { get; set; }

        [DefaultValue(false)]
        public bool HaveMade { get; set; }

    }
}
