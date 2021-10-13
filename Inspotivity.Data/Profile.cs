using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Data
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
    }
}
