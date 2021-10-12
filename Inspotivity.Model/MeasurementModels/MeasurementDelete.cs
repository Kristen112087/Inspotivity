using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.MeasurementModels
{
    public class MeasurementDelete
    {
        [Required]
        public string Who { get; set; }
    }
}
