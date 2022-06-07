namespace CarRental
{
    public interface IOrderClosure
    {
        public bool Close(Order order);
    }
}