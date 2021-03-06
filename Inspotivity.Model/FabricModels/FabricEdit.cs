using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.FabricModels
{
    public class FabricEdit
    {
        [ForeignKey(nameof(Guid))]
        public virtual Guid OwnerId { get; set; }
        [Key]
        public int FabricId { get; set; }
        [Required]
        public string FabricType { get; set; }

        [Display(Name = "Fiber Content")]
        public string FiberContent { get; set; }

        [Display(Name = "Wight per Yard in Ounces")]
        public double WeightPerYard { get; set; }

        [Display(Name = "Date Purchased")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // added for date picker
        public DateTimeOffset DatePurchased { get; set; }

        [Display(Name = "Price Per Yard when Purchased")]
        public double PricePerYard { get; set; }

        [Display(Name = "Stretch Percentage")]
        public double StretchPercentage { get; set; }

        [Display(Name = "How much on hand in Yards")]
        public double YardsOnHand { get; set; }
    }
}
