using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.MeasurementModels
{
   public class MeasurementDetail
    {
        [ForeignKey(nameof(Guid))]
        public virtual Guid OwnerId { get; set; }
        [Key]
        public int MeasurementsId { get; set; }
        public string Who { get; set; }
        [Display(Name = "Height in Inches")]
        public double Height { get; set; }
        [Display(Name = "Head Circumference")]
        public double HeadCircumference { get; set; }

        [Display(Name = "Upper Bust: (Under arm-pits, over full bust)")]
        public double UpperBust { get; set; }

        [Display(Name = "FullBust: (Fullest part of Bust)")]
        public double FullBust { get; set; }

        [Display(Name = "Under Bust: (Where a bra would sit)")]
        public double UnderBust { get; set; }

        [Display(Name = "Waist: (Put hands on sides and bend to side. Wherever your top torso bends is your natural Waist)")]
        public double Waist { get; set; }

        [Display(Name = "Hips: (Fullest part around bottom)")]
        public double Hips { get; set; }

        [Display(Name = "Thigh: (Around one Thigh)")]
        public double OneThigh { get; set; }

        [Display(Name = "Calf: (Around one Calf)")]
        public double OneCalf { get; set; }

        [Display(Name = "Upper Arm: (Around one bicep)")]
        public double OneUpperArm { get; set; }

        [Display(Name = "Lower Arm: (Around one arm, half way between wrist and elbow)")]
        public double OneLowerArm { get; set; }
    }
}
