using Inspotivity.Data;
using Inspotivity.Model.MakeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Service
{
    public class MakeService
    {
        private readonly Guid _UserId;
        public MakeService(Guid userId)
        {
            _UserId = userId;
        }

        //Create
        public bool CreateMake(MakeCreate model)
        {
            var make = new Make()
            {
                OwnerId = _UserId,
                PaperPatternId = model.PaperPatternId,
                FabricId = model.FabricId,
                MeasurementsId = model.MeasurementsId,
                SizeMade = model.SizeMade,
                Notes = model.Notes,
                DateMade = model.DateMade
            };

            using(var database = new ApplicationDbContext())
            {
                database.Makes.Add(make);
                return database.SaveChanges() == 1;
            }
        }

        //Read All
        public IEnumerable<MakeItem> GetAllMakes()
        {
            using(var database = new ApplicationDbContext())
            {
                var query = database.Makes.Where(m => m.OwnerId == _UserId).Select(m => new MakeItem()
                {                    
                    OwnerId = _UserId,
                    MakeId = m.MakeId,
                    PaperPattern = m.PaperPattern,
                    Fabric = m.Fabric,
                    Measurements = m.Measurements,
                    Notes = m.Notes,
                    DateMade = m.DateMade
                });
                return query.ToList();
            }
        }

        //Read By Id
        public MakeDetail GetMakeById(int id)
        {
            using(var database = new ApplicationDbContext())
            {
                var make = database.Makes.Single(m => m.MakeId == id);

                return new MakeDetail()
                {
                    OwnerId = _UserId,
                    PaperPattern = make.PaperPattern,
                    Fabric = make.Fabric,
                    Measurements = make.Measurements,
                    SizeMade = make.SizeMade,
                    Notes = make.Notes,
                    DateMade = make.DateMade
                };
            }
        }

        public MakeEdit GetMakeEditById(int id)
        {
            using (var database = new ApplicationDbContext())
            {
                var make = database.Makes.Single(m => m.MakeId == id);

                return new MakeEdit()
                {
                    OwnerId = _UserId,
                    PaperPatternId = make.PaperPatternId,
                    FabricId = make.FabricId,
                    MeasurementsId = make.MeasurementsId,
                    SizeMade = make.SizeMade,
                    Notes = make.Notes,
                    DateMade = make.DateMade
                };
            }
        }

        //Update by Id
        public bool UpdateMake(MakeEdit model)
        {
            using(var database = new ApplicationDbContext())
            {
                var make = database.Makes.Single(m => m.MakeId == model.MakeId);

                make.OwnerId = _UserId;
                make.PaperPatternId = model.PaperPatternId;
                make.FabricId = model.FabricId;
                make.MeasurementsId = model.MeasurementsId;
                make.SizeMade = model.SizeMade;
                make.Notes = model.Notes;
                make.DateMade = model.DateMade;
                var savedObjectCount = database.SaveChanges();
                return savedObjectCount == 1;
            }
        }

        //Delete
        public bool DeleteMake(int makeId)
        {
            using (var database = new ApplicationDbContext())
            {
                var make = database.Makes.Single(m => m.MakeId == makeId && m.OwnerId == _UserId);
                database.Makes.Remove(make);
                return database.SaveChanges() == 1;
            }
        }

        //Delete By Id
        //public MakeEdit DeleteById(int id)
        //{
        //    using(var database = new ApplicationDbContext())
        //    {
        //        var make = database.Makes.Single(m => m.MakeId == id);
        //        return new MakeEdit
        //        {
        //            OwnerId = _UserId,
        //            PaperPattern = make.PaperPattern,
        //            Fabric = make.Fabric,
        //            Measurements = make.Measurements,
        //            SizeMade = make.SizeMade,
        //            Notes = make.Notes,
        //            DateMade = make.DateMade
        //        };
        //    }
        //}
    }
}
