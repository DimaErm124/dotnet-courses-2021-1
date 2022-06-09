using System;
using Values;

namespace MovementByVehicle
{
    public class Vehicle
    {
        private double _averageFuel;

        private double _volume;

        private double _speed;

        public VehicleType VehicleType { get; set; }

        public double AverageFuel
        {
            get => _averageFuel;
            set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessage.MinBorder, value, 0, nameof(AverageFuel)));

                _averageFuel = value;
            }
        }

        public double Volume
        {
            get => _volume;
            set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessage.MinBorder, value, 0, nameof(Volume)));

                _volume = value;
            }
        }

        public double Speed
        {
            get => _speed;
            set
            {
                if (value < 0)
                    throw new ArgumentException(string.Format(ExceptionMessage.MinBorder, value, 0, nameof(Speed)));

                _speed = value;
            }
        }

        public Vehicle(VehicleType vehicleType,
                       double averageFuel,
                       double volume,
                       double speed)
        {
            VehicleType = vehicleType;
            AverageFuel = averageFuel;
            Volume = volume;
            Speed = speed;
        }

        public double GetPossibleWay()
        {
            return GetPossibleWay(Volume);
        }

        public virtual double GetPossibleWay(double volume)
        {
            return volume / AverageFuel;
        }

        public double GetWayTime(double way)
        {
            return way / Speed;
        }
    }
}