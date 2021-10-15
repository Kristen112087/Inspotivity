using Inspotivity.Data;
using Inspotivity.Model.PaperPatternModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Inspotivity.Model.PaperPatternModels.PaperPatternItem;

namespace Inspotivity.Service
{
    public class PaperPatternService
    {
        private readonly Guid _UserId;
        public PaperPatternService(Guid userId)
        {
            _UserId = userId;
        }

        //Create
        public bool CreatePaperPattern(PaperPatternCreate model)
        {
            var newPattern = new PaperPattern()
            {
                OwnerId = _UserId,
                Designer = model.Designer,
                PatternName = model.PatternName,
                ReleaseDate = model.ReleaseDate,
                PurchaseDate = model.PurchaseDate,
                PatternURL = model.PatternURL,
                PatternNumber = model.PatternNumber,
                Category = model.Category,
                FabricTypeNeeded = model.FabricTypeNeeded,
                FabricRequirementInYards = model.FabricRequirementInYards,
                NotionsNeeded = model.NotionsNeeded,
                WhereStored = model.WhereStored,
                HaveMade = model.HaveMade,
            };
            using (var database = new ApplicationDbContext())
            {
                database.PaperPatterns.Add(newPattern);
                return database.SaveChanges() == 1;
            }
        }

        //Read All
        public IEnumerable<PaperPatternItem> GetPaperPatterns()
        {
            using (var database = new ApplicationDbContext())
            {
                var query = database.PaperPatterns.Where(p => p.OwnerId == _UserId).Select(p => new PaperPatternItem()
                {
                    OwnerId = _UserId,
                    PaperPatternId = p.PaperPatternId,
                    Designer = p.Designer,
                    PatternName = p.PatternName,
                    HaveMade = p.HaveMade
                });
                return query.ToList();
            }
        }

        //Read By Id
        public PaperPatternDetail GetPaperPatternById(int id)
        {
            using (var database = new ApplicationDbContext())
            {
                var pattern = database.PaperPatterns.Single(p => p.PaperPatternId == id);

                //var service = new PaperPatternService(_UserId);
                //var paperPatterns = service.GetPaperPatternById(id);

                return new PaperPatternDetail
                {
                    OwnerId = _UserId,
                    PaperPatternId = pattern.PaperPatternId,
                    Designer = pattern.Designer,
                    PatternName = pattern.PatternName,
                    ReleaseDate = pattern.ReleaseDate,
                    PurchaseDate = pattern.PurchaseDate,
                    PatternURL = pattern.PatternURL,
                    PatternNumber = pattern.PatternNumber,
                    Category = pattern.Category,
                    FabricTypeNeeded = pattern.FabricTypeNeeded,
                    FabricRequirementInYards = pattern.FabricRequirementInYards,
                    NotionsNeeded = pattern.NotionsNeeded,
                    WhereStored = pattern.WhereStored,
                    HaveMade = pattern.HaveMade
                };
            }
        }

        // Update/Edit by Id

        public bool UpdatePaperPattern(PaperPatternEdit model)
        {
            using (var database = new ApplicationDbContext())
            {
                var pattern = database.PaperPatterns.Single(p => p.PaperPatternId == model.PaperPatternId);

                pattern.OwnerId = _UserId;
                pattern.Designer = model.Designer;
                pattern.PatternName = model.PatternName;
                pattern.ReleaseDate = model.ReleaseDate;
                pattern.PurchaseDate = model.PurchaseDate;
                pattern.PatternURL = model.PatternURL;
                pattern.PatternNumber = model.PatternNumber;
                pattern.Category = model.Category;
                pattern.FabricTypeNeeded = model.FabricTypeNeeded;
                pattern.FabricRequirementInYards = model.FabricRequirementInYards;
                pattern.NotionsNeeded = model.NotionsNeeded;
                pattern.WhereStored = model.WhereStored;
                pattern.HaveMade = model.HaveMade;
                var savedObjectCount = database.SaveChanges();
                return savedObjectCount == 1;
               
            }
        }

        // Delete

        public bool DeletePaperPattern(int patternId)
        {
            using (var database = new ApplicationDbContext())
            {
                var pattern = database.PaperPatterns.Single(p => p.PaperPatternId == patternId && p.OwnerId == _UserId);
                database.PaperPatterns.Remove(pattern);
                return database.SaveChanges() == 1;
            }
        }

        //Delete By Id
        public PaperPatternEdit DeleteById(int id)
        {
            using (var database = new ApplicationDbContext())
            {
                var pattern = database.PaperPatterns.Single(p => p.PaperPatternId == id);

                //var service = new PaperPatternService(_UserId);
                //var paperPatterns = service.GetPaperPatternById(id);

                return new PaperPatternEdit
                {
                    OwnerId = _UserId,
                    PaperPatternId = pattern.PaperPatternId,
                    Designer = pattern.Designer,
                    PatternName = pattern.PatternName,
                    ReleaseDate = pattern.ReleaseDate,
                    PurchaseDate = pattern.PurchaseDate,
                    PatternURL = pattern.PatternURL,
                    PatternNumber = pattern.PatternNumber,
                    Category = pattern.Category,
                    FabricTypeNeeded = pattern.FabricTypeNeeded,
                    FabricRequirementInYards = pattern.FabricRequirementInYards,
                    NotionsNeeded = pattern.NotionsNeeded,
                    WhereStored = pattern.WhereStored,
                    HaveMade = pattern.HaveMade
                };
            }
        }
    }
}