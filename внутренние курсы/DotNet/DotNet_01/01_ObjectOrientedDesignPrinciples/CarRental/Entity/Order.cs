using System;

namespace CarRental
{
    [Serializable]
    public class Order : IComparable<Order>, IEquatable<Order>
    {
        private Client _client;

        private RentalSubject _rentalSubject;

        private DateTime _orderStart;

        private double _cost;

        public Client Client
        {
            get => _client;
            set
            {
                if (!(value != null && value.DriverLicense > 0 && value.Name != string.Empty && value.Surname != string.Empty))
                {
                    throw new ArgumentNullException("Сlient must have name, surname and driver license.");
                }
                _client = value;
            }
        }

        public RentalSubject RentalSubject
        {
            get => _rentalSubject;
            set
            {
                if (!(value != null && value.Car != null && !value.Car.IsEmpty() && value.Price > 0))
                {
                    throw new ArgumentNullException("Rental subject must have client, car and price.");
                }
                _rentalSubject = value;
            }
        }

        public DateTime OrderStart
        {
            get => _orderStart;
            set
            {
                if (value > DateTime.Now || value <= DateTime.MinValue)
                    throw new Exception("Order start cannot be more than today!");
                _orderStart = value;
            }
        }

        public DateTime OrderFinish { get; set; }

        public double Cost
        {
            get => _cost;
            set
            {
                if (value < 0)
                    throw new Exception("Cost must be more than zero");
                _cost = value;
            }
        }

        public OrderStatus Status { get; set; }

        public Order() { }

        public Order(Client client, RentalSubject rentalSubject, DateTime orderStart, OrderStatus status)
        {
            Client = client;
            RentalSubject = rentalSubject;
            OrderStart = orderStart;
            Status = status;
        }

        public override string ToString()
        {
            return Client.ToString()
            + RentalSubject.ToString()
            + "Orders start: " + OrderStart + "\n"
            + "Order finish: " + OrderFinish + "\n"
            + "Cost: " + Cost + "\n"
            + "Status: " + Status + "\n";
        }

        public int CompareTo(Order other)
        {
            if (Client.CompareTo(other.Client) == 0)
                if (RentalSubject.CompareTo(other.RentalSubject) == 0)
                    if (OrderStart.CompareTo(other.OrderStart) == 0)
                        if (OrderFinish.CompareTo(other.OrderFinish) == 0)
                            if (Cost.CompareTo(other.Cost) == 0)
                                if (Status.CompareTo(other.Status) == 0)
                                    return 0;
                                else
                                    return Status.CompareTo(other.Status);
                            else
                                return Cost.CompareTo(other.Cost);
                        else
                            return OrderFinish.CompareTo(other.OrderFinish);
                    else
                        return OrderStart.CompareTo(other.OrderStart);
                else
                    return RentalSubject.CompareTo(other.RentalSubject);
            else
                return Client.CompareTo(other.Client);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Order order = obj as Order;

            if (order == null)
                return false;
            else
                return Equals(order);
        }

        public bool Equals(Order other)
        {
            if (other == null)
                return false;

            return Client.Equals(other.Client)
                && RentalSubject.Equals(other.RentalSubject)
                && OrderStart.Equals(other.OrderStart)
                && OrderFinish.Equals(other.OrderFinish)
                && Cost.Equals(other.Cost)
                && Status.Equals(other.Status);
        }
    }
}