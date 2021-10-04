using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Data
{
    public class Measurements
    {
        [Key]
        public int MeasurementsId { get; set; }
        [Required]
        public virtual User UserId { get; set; }
        public double Height { get; set; }
        public double HeadCircumference { get; set; }
        public double UpperBust { get; set; }
        public double FullBust { get; set; }
        public double UnderBust { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }
        public double OneThigh { get; set; }
        public double OneCalf { get; set; }
        public double OneUpperArm { get; set; }
        public double OneLowerArm { get; set; }
    }
}
