using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.FabricModels
{
    public class FabricItem
    {
        [Key]
        public int FabricId { get; set; }

        [Display(Name = "Type Of Fabric")]
        public string FabricType { get; set; }

        [Display(Name = "How much on hand in Yards")]
        public double YardsOnHand { get; set; }
    }
}
