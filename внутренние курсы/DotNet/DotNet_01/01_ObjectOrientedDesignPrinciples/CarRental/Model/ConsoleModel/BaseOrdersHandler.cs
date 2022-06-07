using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class BaseOrdersHandler : IOrdersHandler
    {
        private readonly IFileHandler<Order> _fileHandler;

        public BaseOrdersHandler(IFileHandler<Order> fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public List<Order> GetOrdersForClient(Client client)
        {
            return _fileHandler.Read().Where(x => x.Client == client).ToList();
        }

        public List<Order> GetOrdersForClientByStatus(Client client, OrderStatus status)
        {
            return _fileHandler.Read()
                .Where(x => x.Client.DriverLicense == client.DriverLicense)
                .Where(x => x.Status == status)
                .ToList();
        }

        public List<Order> GetAllOrder()
        {
            return _fileHandler.Read();
        }
    }
}