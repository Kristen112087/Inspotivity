﻿using Inspotivity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.MeasurementModels
{
    public class MeasurementItem
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Who { get; set; }
        
    }
}
