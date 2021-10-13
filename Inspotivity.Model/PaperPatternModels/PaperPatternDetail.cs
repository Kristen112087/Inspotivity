using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Model.PaperPatternModels
{
    public class PaperPatternDetail
    {
        public enum PatternFor
        {
            Adult,
            Teen,
            Child,
            Infant
        }
        public enum DifficultyLevel
        {
            Novice,
            Beginner,
            Intermediate,
            Advanced,
            Expert
        }
        
        public string Designer { get; set; }
        public string PatternName { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public string PatternURL { get; set; }
        public string PatternNumber { get; set; }
        public string Category { get; set; }
        public string FabricTypeNeeded { get; set; }
        public double FabricRequirementInYards { get; set; }
        public string NotionsNeeded { get; set; }
        [Display(Name = "Where I have it stored")]
        public string WhereStored { get; set; }
        [DefaultValue(false)]
        public bool HaveMade { get; set; }
        
    }
}

