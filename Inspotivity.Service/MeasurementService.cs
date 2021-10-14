using Inspotivity.Data;
using Inspotivity.Model.MeasurementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspotivity.Service
{
    public class MeasurementService
    {
        private readonly Guid _UserId;
        public MeasurementService(Guid userId)
        {
            _UserId = userId;
        }

        //Create
        public bool CreateMeasurement(MeasurementCreate model)
        {
            var measurement = new Measurements()
            {
                Who = model.Who,
                Height = model.Height,
                HeadCircumference = model.HeadCircumference,
                UpperBust = model.UpperBust,
                FullBust = model.FullBust,
                UnderBust = model.UnderBust,
                Waist = model.Waist,
                Hips = model.Hips,
                OneThigh = model.OneThigh,
                OneCalf = model.OneCalf,
                OneUpperArm = model.OneUpperArm,
                OneLowerArm = model.OneLowerArm
            };

            using (var database = new ApplicationDbContext())
            {
                database.Measurements.Add(measurement);
                return database.SaveChanges() == 1;
            }
        }

        //Read
        public IEnumerable<MeasurementItem> GetAllMeasurements()
        {
            using (var database = new ApplicationDbContext())
            {
                var query = database.Measurements.Where(m => m.OwnerId == _UserId).Select(m => new MeasurementItem()
                {

                })
            }
        }
    }
}