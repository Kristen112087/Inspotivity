using Inspotivity.Data;
using Inspotivity.Model.PaperPatternModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Service
{
    public class PaperPatternService
    {
        private readonly Guid _userId;
        public PaperPatternService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePaperPattern(PaperPatternCreate model)
        {
            var newPaperPattern = new PaperPattern()
            {
                Designer = 
            }
        }
    }
}
