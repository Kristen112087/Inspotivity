﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.Fabric
{
    public class FabricEdit
    {
        public int FabricId { get; set; }
        [Required]
        public string FabricType { get; set; }
        [Display(Name = "Fiber Content")]
        public string FiberContent { get; set; }
        [Display(Name = "Wight per Yard in Ounces")]
        public double WeightPerYard { get; set; }
        [Display(Name = "Date Purchased")]
        public DateTimeOffset DatePurchased { get; set; }
        [Display(Name = "Price Per Yard when Purchased")]
        public double PricePerYard { get; set; }
        [Display(Name = "Stretch Percentage")]
        public int StretchPercentage { get; set; }
        [Display(Name = "How much on hand in Yards")]
        public double YardsOnHand { get; set; }
    }
}
