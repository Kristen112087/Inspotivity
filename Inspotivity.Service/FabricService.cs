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

        //Read
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



    }
}
