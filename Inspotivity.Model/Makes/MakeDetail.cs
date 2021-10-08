using Inspotivity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.Makes
{
    public class MakeDetail
    {
        [Required]
        public virtual User UserId { get; set; }
        [Display(Name = "Pattern Used")]
        public virtual Pattern PatternId { get; set; }
        [Display(Name = "Fabric Used")]
        public virtual Fabric FabricId { get; set; }
        [Display(Name = "Made For")]
        public virtual Measurements Who { get; set; }
        [Display(Name = "Size Made")]
        public string SizeMade { get; set; }
        [Display(Name = "Any Notes")]
        public string Notes { get; set; }
        [Display(Name = "When Made")]
        public DateTimeOffset DateMade { get; set; }
    }
}
