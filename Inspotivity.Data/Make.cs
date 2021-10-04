using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Data
{
    public class Make
    {
        [Key]
        public int MakeId { get; set; }
        [Required]
        public virtual User UserId { get; set; }
        public virtual Pattern PatternId { get; set; }
        public virtual Fabric FabricId { get; set; }
        public string SizeMade { get; set; }
        public string Notes { get; set; }

    }
}
