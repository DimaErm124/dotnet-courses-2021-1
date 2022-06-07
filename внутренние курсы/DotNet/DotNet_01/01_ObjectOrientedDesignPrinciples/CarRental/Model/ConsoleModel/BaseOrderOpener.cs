using System.Collections.Generic;

namespace CarRental
{
    public class BaseOrderOpener : IOrderOpener
    {
        private readonly IFileHandler<Order> _fileHandler;

        private readonly IFileHandler<RentalSubject> _rentalSubjectsFileHandler;

        public BaseOrderOpener(IFileHandler<Order> clientFileHandler, IFileHandler<RentalSubject> rentalSubjectsFileHandler)
        {
            _fileHandler = clientFileHandler;

            _rentalSubjectsFileHandler = rentalSubjectsFileHandler;
        }
        public bool Open(Order order)
        {
            List<RentalSubject> rentalSubjects = _rentalSubjectsFileHandler.Read();

            if (rentalSubjects.Remove(order.RentalSubject))
            {
                order.RentalSubject.SubjectStatus = RentalSubjectStatus.Employed;
                rentalSubjects.Add(order.RentalSubject);

                _rentalSubjectsFileHandler.WriteAll(rentalSubjects);
                
                return _fileHandler.Write(order);
            }

            return false;
        }
    }
}