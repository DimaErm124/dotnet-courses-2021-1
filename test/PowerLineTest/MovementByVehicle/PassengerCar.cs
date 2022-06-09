using System;
using Values;

namespace MovementByVehicle
{
    public class PassengerCar : Vehicle
    {
        private int _passengerCount;

        public int PassengerCount
        {
            get => _passengerCount;
            set
            {
                if (value < BorderValues.MinPassengerCount)
                    throw new ArgumentException(string.Format(ExceptionMessage.MinBorder, value, BorderValues.MinPassengerCount, nameof(PassengerCount)));

                if (value > BorderValues.MaxPassengerCount)
                    throw new ArgumentException(string.Format(ExceptionMessage.MaxBorder, value, BorderValues.MaxPassengerCount, nameof(PassengerCount)));

                _passengerCount = value;
            }
        }

        public PassengerCar(VehicleType vehicleType,
                            double averageFuel,
                            double volume,
                            double speed, 
                            int passengerCount) : base(vehicleType,
                                                 averageFuel,
                                                 volume,
                                                 speed)
        {
            PassengerCount = passengerCount;
        }

        public override double GetPossibleWay(double volume)
        {
            return base.GetPossibleWay(volume) * CoefValues.PassengerCarBrakingPercent * _passengerCount;
        }
    }
}