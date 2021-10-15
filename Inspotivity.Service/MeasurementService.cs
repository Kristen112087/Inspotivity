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
                    Who = m.Who
                });
                return query.ToArray();
            }
        }

        //Read by Id
        public MeasurementDetail GetMeasurementById(int id)
        {
            using(var database = new ApplicationDbContext())
            {
                var measurement = database.Measurements.Single(m => m.MeasurementsId == id);

                var service = new MeasurementService(_UserId);
                var singleMeasurement = service.GetMeasurementById(id);

                return new MeasurementDetail()
                {
                    Who = measurement.Who,
                    Height = measurement.Height,
                    HeadCircumference = measurement.HeadCircumference,
                    UpperBust = measurement.UpperBust,
                    FullBust = measurement.FullBust,
                    UnderBust = measurement.UnderBust,
                    Waist = measurement.Waist,
                    Hips = measurement.Hips,
                    OneThigh = measurement.OneThigh,
                    OneCalf = measurement.OneCalf,
                    OneUpperArm = measurement.OneUpperArm,
                    OneLowerArm = measurement.OneLowerArm
                };
            }
        }

        //Update by Id
        public bool UpdateMeasurement(MeasurementEdit model)
        {
            using(var database = new ApplicationDbContext())
            {
                var measurement = database.Measurements.Single(m => m.MeasurementsId == model.MeasurementsId);

                measurement.Who = model.Who;
                measurement.Height = model.Height;
                measurement.HeadCircumference = measurement.HeadCircumference;
                measurement.UpperBust = model.UpperBust;
                measurement.FullBust = model.FullBust;
                measurement.UnderBust = model.UnderBust;
                measurement.Waist = model.Waist;
                measurement.Hips = model.Hips;
                measurement.OneThigh = model.OneThigh;
                measurement.OneCalf = model.OneCalf;
                measurement.OneUpperArm = model.OneUpperArm;
                measurement.OneLowerArm = model.OneLowerArm;

                return database.SaveChanges() == 1;
            }
        }

        //Delete by Id
        public bool DeleteMeasurement(int measurementsId)
        {
            using(var database = new ApplicationDbContext())
            {
                var measurement = database.Measurements.Single(m => m.MeasurementsId == measurementsId && m.OwnerId == _UserId);
                database.Measurements.Remove(measurement);

                return database.SaveChanges() == 1;
            }
        }
    }
}