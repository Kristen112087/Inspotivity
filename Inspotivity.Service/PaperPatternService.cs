﻿using Inspotivity.Data;
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
        private readonly Guid _UserId;
        public PaperPatternService(Guid userId)
        {
            _UserId = userId;
        }

        //Create
        public bool CreatePaperPattern(PaperPatternCreate model)
        {
            var pattern = new PaperPattern()
            {
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
                database.PaperPattern.Add(pattern);
                return database.SaveChanges() == 1;
            }
        }

        //Read
        public IEnumerable<PaperPatternItem> GetPaperPatterns()
        {
            using (var database = new ApplicationDbContext())
            {
                var query = database.PaperPattern.Where(p => p.OwnerId == _UserId).Select(p => new PaperPatternItem()
                {
                    Designer = p.Designer,
                    PatternName = p.PatternName,
                    HaveMade = p.HaveMade

                });
                return query.ToArray();
            }
        }

        //Read By Id
        public PaperPatternDetail GetPaperPatternById(int id)
        {
            using (var database = new ApplicationDbContext())
            {
                var pattern = database.PaperPattern.Single(p => p.PatternId == id);

                var service = new PaperPatternService(_UserId);
                var paperPatterns = service.GetPaperPatternById(id);

                return new PaperPatternDetail()
                {
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
                var pattern = database.PaperPattern.Single(p => p.PatternId == model.PatternId);

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

                return database.SaveChanges() == 1;
            }
        }

        // Delete By Id

        public bool DeletePaperPattern(int patternId)
        {
            using (var database = new ApplicationDbContext())
            {
                var pattern = database.PaperPattern.Single(p => p.PatternId == patternId && p.OwnerId == _UserId);
                database.PaperPattern.Remove(pattern);

                return database.SaveChanges() == 1;
            }
        }
    }
}