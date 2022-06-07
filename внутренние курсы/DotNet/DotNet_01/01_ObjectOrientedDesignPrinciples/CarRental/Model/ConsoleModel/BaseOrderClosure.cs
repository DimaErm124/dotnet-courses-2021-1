using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class BaseOrderClosure : IOrderClosure
    {
        private readonly IFileHandler<Order> _fileHandler;

        private readonly IFileHandler<RentalSubject> _subjectFileHandler;

        public BaseOrderClosure(IFileHandler<Order> fileHandler, IFileHandler<RentalSubject> subjectFileHandler)
        {
            _fileHandler = fileHandler;
            _subjectFileHandler = subjectFileHandler;
        }

        public bool Close(Order order)
        {
            List<RentalSubject> subjects = _subjectFileHandler.Read();

            RentalSubject rentalSubject = subjects.Where(x => x.Car.PlateNumber == order.RentalSubject.Car.PlateNumber).First();

            if (subjects.Remove(rentalSubject))
            {
                rentalSubject.SubjectStatus = RentalSubjectStatus.Free;
                subjects.Add(rentalSubject);
                _subjectFileHandler.WriteAll(subjects);

                List<Order> orders = _fileHandler.Read();

                if (orders.Remove(order))
                {
                    order.OrderFinish = DateTime.Now;
                    order.Cost = (order.OrderFinish - order.OrderStart).TotalDays * order.RentalSubject.Price;
                    order.Status = OrderStatus.Closed;
                    order.RentalSubject.SubjectStatus = RentalSubjectStatus.Free;

                    orders.Add(order);

                    return _fileHandler.WriteAll(orders);
                }
            }

            return false;
        }
    }
}