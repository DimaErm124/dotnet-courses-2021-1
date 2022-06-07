using System;
using System.Collections.Generic;

namespace CarRental
{
    [Serializable]
    public class Renter : User
    {
        public Client Client { get; set; }

        public Renter() { }

        public Renter(string login, string password, Client client) : base(login, password, Role.Renter)
        {
            Client = client;
        }

        public List<Order> GetActiveOrders(IOrdersHandler clientOrdersHandler)
        {
            return clientOrdersHandler.GetOrdersForClientByStatus(Client, OrderStatus.Open);
        }

        public List<Order> GetOrdersHistory(IOrdersHandler clientOrdersHandler)
        {
            return clientOrdersHandler.GetOrdersForClientByStatus(Client, OrderStatus.Closed);
        }
    }
}