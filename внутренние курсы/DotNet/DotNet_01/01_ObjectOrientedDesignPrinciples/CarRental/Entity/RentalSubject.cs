using System;

namespace CarRental
{
    [Serializable]
    public class RentalSubject : IComparable<RentalSubject>, IEquatable<RentalSubject>
    {
        private Car _car;

        private double _price;

        public Car Car
        {
            get => _car;
            set
            {
                if (!(value != null && !value.IsEmpty()))
                {
                    throw new ArgumentNullException("Car must have all parameters!");
                }
                _car = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be more than zero!");
                }
                _price = value;
            }
        }

        public RentalSubjectStatus SubjectStatus { get; set; }

        public RentalSubject() { }

        public RentalSubject(Car car, double price, RentalSubjectStatus subjectStatus)
        {
            Car = car;
            Price = price;
            SubjectStatus = subjectStatus;
        }

        public override string ToString()
        {
            return  Car.ToString()
                + "Price: " + Price + "\n"
                + "Status: " + SubjectStatus + "\n";
        }

        public int CompareTo(RentalSubject other)
        {
            if (Car.CompareTo(other.Car) == 0)
                if (Price.CompareTo(other.Price) == 0)
                    if (SubjectStatus.CompareTo(other.SubjectStatus) == 0)
                        return 0;
                    else
                        return SubjectStatus.CompareTo(other.SubjectStatus);
                else
                    return Price.CompareTo(other.Price);
            else
                return Car.CompareTo(other.Car);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            RentalSubject rentalSubject = obj as RentalSubject;

            if (rentalSubject == null)
                return false;
            else
                return Equals(rentalSubject);
        }

        public bool Equals(RentalSubject other)
        {
            if (other == null)
                return false;

            return Car.Equals(other.Car)
                && Price.Equals(other.Price)
                && SubjectStatus.Equals(other.SubjectStatus);
        }
    }
}