using Inspotivity.Data;
using Inspotivity.Model.FabricModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Service
{ 
    public class FabricService
    {
        private readonly Guid _UserId;
        public FabricService(Guid userId)
        {
            _UserId = userId;
        }

        //Create
        public bool CreateFabric(FabricCreate model)
        {
            var fabric = new Fabric()
            {
                FabricType = model.FabricType,
                FiberContent = model.FiberContent,
                WeightPerYard = model.WeightPerYard,
                DatePurchased = model.DatePurchased,
                PricePerYard = model.PricePerYard,
                StretchPercentage = model.StretchPercentage,
                YardsOnHand = model.YardsOnHand
            };

            using (var database = new ApplicationDbContext())
            {
                database.Fabrics.Add(fabric);
                return database.SaveChanges() == 1;
            }
        }

        //Read All
        public IEnumerable<FabricItem> GetAllFabric()
        {
            using(var database = new ApplicationDbContext())
            {
                var query = database.Fabrics.Where(f => f.OwnerId == _UserId).Select(f => new FabricItem()
                {
                    FabricType = f.FabricType,
                    YardsOnHand = f.YardsOnHand
                });
                return query.ToArray();
            }
        }

        //Read by Id
        public FabricDetail GetFabricById(int id)
        {
            using(var database = new ApplicationDbContext())
            {
                var fabric = database.Fabrics.Single(f => f.FabricId == id);

                var service = new FabricService(_UserId);
                var singleFabric = service.GetFabricById(id);

                return new FabricDetail()
                {
                    FabricType = fabric.FabricType,
                    FiberContent = fabric.FiberContent,
                    WeightPerYard = fabric.WeightPerYard,
                    DatePurchased = fabric.DatePurchased,
                    PricePerYard = fabric.PricePerYard,
                    StretchPercentage = fabric.StretchPercentage,
                    YardsOnHand = fabric.YardsOnHand
                };
            }
        }

        //Update by Id
        public bool UpdateFabric(FabricEdit model)
        {
            using(var database = new ApplicationDbContext())
            {
                var fabric = database.Fabrics.Single(f => f.FabricId == model.FabricId);

                fabric.FabricType = model.FabricType;
                fabric.FiberContent = model.FiberContent;
                fabric.WeightPerYard = model.WeightPerYard;
                fabric.DatePurchased = model.DatePurchased;
                fabric.PricePerYard = model.PricePerYard;
                fabric.StretchPercentage = model.StretchPercentage;
                fabric.YardsOnHand = model.YardsOnHand;

                return database.SaveChanges() == 1;
            };
        }

        //Delete by Id
        public bool DeleteFabric(int fabricId)
        {
            using(var database = new ApplicationDbContext())
            {
                var fabric = database.Fabrics.Single(f => f.FabricId == fabricId && f.OwnerId == _UserId);
                database.Fabrics.Remove(fabric);

                return database.SaveChanges() == 1;
            }
        }

    }
}
