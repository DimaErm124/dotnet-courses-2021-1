using System.Collections.Generic;

namespace CarRental
{
    public class BaseFreeRentalSubjectReporter : IReporter<RentalSubject>
    {
        private readonly IFileHandler<RentalSubject> _fileHandler;

        public BaseFreeRentalSubjectReporter(IFileHandler<RentalSubject> fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public bool Report(List<RentalSubject> cars)
        {
            return _fileHandler.WriteAll(cars);
        }
    }
}