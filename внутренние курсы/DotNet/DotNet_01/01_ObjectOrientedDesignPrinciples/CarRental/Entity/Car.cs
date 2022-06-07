using System;

namespace CarRental
{
    [Serializable]
    public class Car : IComparable<Car>,IEquatable<Car>
    {
        private int _capacity;

        private int _engineVolume;

        private double _mileage;

        private DateTime _releaseDate;

        private string _plateNumber;

        private double _insuranceSum;

        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value <= 0)
                    throw new Exception("Capacity cannot be less than zero!");
                _capacity = value;
            }
        }

        public int EngineVolume
        {
            get => _engineVolume;
            set
            {
                if (value <= 0)
                    throw new Exception("Engine volume cannot be less than zero!");
                _engineVolume = value;
            }
        }

        public double Mileage
        {
            get => _mileage;
            set
            {
                if (value <= 0)
                    throw new Exception("Mileage cannot be less than zero!");
                _mileage = value;
            }
        }

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (value > DateTime.Now || value <= DateTime.MinValue)
                    throw new Exception("Release date cannot be more than today!");
                _releaseDate = value;
            }
        }

        public string PlateNumber
        {
            get => _plateNumber;
            set
            {
                if (value.Length != ModelValues.PlateNumberSize)
                {
                    throw new ArgumentNullException("Length of number driver license must be equal " + ModelValues.PlateNumberSize + "!");
                }
                _plateNumber = value;
            }
        }

        public double InsuranceSum
        {
            get => _insuranceSum;
            set
            {
                if (value <= 0)
                    throw new Exception("Insurance sum cannot be less than zero!");
                _insuranceSum = value;
            }
        }

        public Car() { }

        public Car(int capacity, int engineVolume, double mileage, DateTime releaseDate, string plateNumber, double insuranceSum)
        {
            Capacity = capacity;
            EngineVolume = engineVolume;
            Mileage = mileage;
            ReleaseDate = releaseDate;
            PlateNumber = plateNumber;
            InsuranceSum = insuranceSum;
        }

        public bool IsEmpty()
        {
            return !(Capacity > 0
                && EngineVolume > 0
                && Mileage > 0
                && ReleaseDate < DateTime.Now
                && ReleaseDate > DateTime.MinValue
                && PlateNumber.Length == ModelValues.PlateNumberSize
                && InsuranceSum > 0);
        }

        public override string ToString()
        {
            return "Capacity: " + Capacity + "\n"
                + "EngineVolume: " + EngineVolume + "\n"
                + "Mileage: " + Mileage + "\n"
                + "ReleaseDate: " + ReleaseDate + "\n"
                + "PlateNumber: " + PlateNumber + "\n"
                + "InsuranceSum: " + InsuranceSum + "\n";
        }

        public int CompareTo(Car other)
        {
            if (Capacity.CompareTo(other.Capacity) == 0)
                if (EngineVolume.CompareTo(other.EngineVolume) == 0)
                    if (Mileage.CompareTo(other.Mileage) == 0)
                        if (ReleaseDate.CompareTo(other.ReleaseDate) == 0)
                            if (PlateNumber.CompareTo(other.PlateNumber) == 0)
                                if (InsuranceSum.CompareTo(other.InsuranceSum) == 0)
                                    return 0;
                                else
                                    return InsuranceSum.CompareTo(other.InsuranceSum);
                            else
                                return PlateNumber.CompareTo(other.PlateNumber);
                        else
                            return ReleaseDate.CompareTo(other.ReleaseDate);
                    else
                        return Mileage.CompareTo(other.Mileage);
                else
                    return EngineVolume.CompareTo(other.EngineVolume);
            else
                return Capacity.CompareTo(other.Capacity);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Car car = obj as Car;

            if (car == null)
                return false;
            else
                return Equals(car);
        }

        public bool Equals(Car other)
        {
            if (other == null)
                return false;

            return Capacity.Equals(other.Capacity)
                && EngineVolume.Equals(other.EngineVolume)
                && Mileage.Equals(other.Mileage)
                && ReleaseDate.Equals(other.ReleaseDate)
                && PlateNumber.Equals(other.PlateNumber)
                && InsuranceSum.Equals(other.InsuranceSum);
        }
    }
}