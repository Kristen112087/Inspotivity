using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.Measurements
{
    public class MeasurementEdit
    {
        public string Who { get; set; }
        public double Height { get; set; }
        public double HeadCircumference { get; set; }
        [Display(Name = "Upper Bust: Under arm-pits, over full bust")]
        public double UpperBust { get; set; }
        [Display(Name = "FullBust: Fullest part of Bust")]
        public double FullBust { get; set; }
        [Display(Name = "Under Bust: where a bra would sit")]
        public double UnderBust { get; set; }
        [Display(Name = "Waist: Put hands on sides and bend. Wherever your top torso bends is your natural Waist")]
        public double Waist { get; set; }
        [Display(Name = "Hips: Fullest part around bottm")]
        public double Hips { get; set; }
        [Display(Name = "Thigh: Around one Thigh")]
        public double OneThigh { get; set; }
        [Display(Name = "Calf: Around one Calf")]
        public double OneCalf { get; set; }
        [Display(Name = "Upper Arm: Around one bicep")]
        public double OneUpperArm { get; set; }
        [Display(Name = "Lower Arm: around one arm, half way between wrist and elbow")]
        public double OneLowerArm { get; set; }
    }
}
