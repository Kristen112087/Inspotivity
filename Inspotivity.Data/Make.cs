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
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(PaperPattern))]
        public virtual PaperPattern PaperPattern { get; set; }

        [ForeignKey(nameof(Fabric))]
        public virtual Fabric Fabric { get; set; }

        [ForeignKey(nameof(Measurements))]
        public virtual Measurements Measurements { get; set; }

        public string SizeMade { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset DateMade { get; set; }

    }
}
