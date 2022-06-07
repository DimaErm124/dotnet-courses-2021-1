using System.Collections.Generic;

namespace CarRental
{
    public interface IRentalSubjectHandler
    {
        public List<RentalSubject> GetFreeRentalSubjects();

        public List<RentalSubject> GetAllRentalSubjects();
    }
}