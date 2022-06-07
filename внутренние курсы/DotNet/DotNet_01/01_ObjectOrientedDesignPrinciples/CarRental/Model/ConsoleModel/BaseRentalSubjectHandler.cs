using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public class BaseRentalSubjectHandler : IRentalSubjectHandler
    {
        private readonly IFileHandler<RentalSubject> _fileHandler;

        public BaseRentalSubjectHandler(IFileHandler<RentalSubject> fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public List<RentalSubject> GetFreeRentalSubjects()
        {
            return _fileHandler.Read()
                .Where(x => x.SubjectStatus == RentalSubjectStatus.Free)
                .ToList();
        }

        public List<RentalSubject> GetAllRentalSubjects()
        {
            return _fileHandler.Read();
        }
    }
}