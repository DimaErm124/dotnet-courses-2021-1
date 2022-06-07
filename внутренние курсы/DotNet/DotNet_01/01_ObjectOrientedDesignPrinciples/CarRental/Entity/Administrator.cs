using System;
using System.Collections.Generic;

namespace CarRental
{
    [Serializable]
    public class Administrator : User
    {
        public Administrator() { }

        public Administrator(string login, string password) : base(login, password, Role.Administrator)
        {
        }

        public static bool AddCar(RentalSubject rentalSubject, IRecorder<RentalSubject> recorder, IRentalSubjectHandler rentalSubjectHandler)
        {
            RentalSubject findingRentalSubject = GetAllRentalSubjects(rentalSubjectHandler).Find(x => x == rentalSubject);

            if (findingRentalSubject == null)
            {
                return recorder.Add(rentalSubject);
            }

            return false;
        }

        public static List<Order> GetAllOrders(IOrdersHandler ordersHandler)
        {
            return ordersHandler.GetAllOrder();
        }

        public static List<User> GetAllUsers(IUserHandler userHandler)
        {
            return userHandler.GetAllUsers();
        }

        public static List<RentalSubject> GetAllRentalSubjects(IRentalSubjectHandler rentalSubjectHandler)
        {
            return rentalSubjectHandler.GetAllRentalSubjects();
        }
    }
}