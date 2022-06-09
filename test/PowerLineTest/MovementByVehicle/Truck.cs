using System;
using Values;

namespace MovementByVehicle
{
    public class Truck : Vehicle
    {
        private double _tonnage;

        public double Tonnage
        {
            get => _tonnage;
            set
            {
                if (value < BorderValues.MinTonnage)
                    throw new ArgumentException(string.Format(ExceptionMessage.MinBorder, value, BorderValues.MinTonnage, nameof(Tonnage)));

                if (value > BorderValues.MaxTonnage)
                    throw new ArgumentException(string.Format(ExceptionMessage.MaxBorder, value, BorderValues.MaxTonnage, nameof(Tonnage)));

                _tonnage = value;
            }
        }

        public Truck(VehicleType vehicleType,
                            double averageFuel,
                            double volume,
                            double speed,
                            double tonnage) : base(vehicleType,
                                                 averageFuel,
                                                 volume,
                                                 speed)
        {
            Tonnage = tonnage;
        }

        public override double GetPossibleWay(double volume)
        {
            return base.GetPossibleWay(volume) * CoefValues.TruckBrakingPercent * (_tonnage / CoefValues.CriticalTonnage);
        }
    }
}