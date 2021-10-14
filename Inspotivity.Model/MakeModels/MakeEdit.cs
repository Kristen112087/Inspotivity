using Inspotivity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.MakeModels
{
    public class MakeEdit
    {
        public int MakeId { get; set; }

        [Display(Name = "Pattern Used")]
        [ForeignKey(nameof(PaperPattern))]
        public virtual PaperPattern PaperPattern { get; set; }

        [Display(Name = "Fabric Used")]
        [ForeignKey(nameof(Fabric))]
        public virtual Fabric Fabric { get; set; }

        [Display(Name = "Made For")]
        [ForeignKey(nameof(Measurements))]
        public virtual Measurements Measurements { get; set; }

        [Display(Name = "Size Made")]
        public string SizeMade { get; set; }

        [Display(Name = "Any Notes")]
        public string Notes { get; set; }

        [Display(Name = "When Made")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // added for date picker
        public DateTimeOffset DateMade { get; set; }
    }
}
