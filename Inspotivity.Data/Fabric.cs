using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Data
{
    public class Fabric
    {
        [Key]
        public int FabricId { get; set; }
        public virtual User UserId { get; set; }
        public string FabricType { get; set; }
        public string FiberContent { get; set; }
        public double Weight { get; set; }
        public DateTimeOffset DatePurchased { get; set; }
        public double PricePerYard { get; set; }
        public int StretchPercentage { get; set; }
        public double YardsOnHand { get; set; }
    }
}
