using System.Collections.Generic;

namespace CarRental
{
    public interface IOrdersHandler
    {
        public List<Order> GetOrdersForClient(Client client);

        public List<Order> GetOrdersForClientByStatus(Client client, OrderStatus status);

        public List<Order> GetAllOrder();
    }
}