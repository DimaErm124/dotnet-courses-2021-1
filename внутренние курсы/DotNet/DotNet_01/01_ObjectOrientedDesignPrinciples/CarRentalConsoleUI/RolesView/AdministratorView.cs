using CarRental;
using System;
using System.Collections.Generic;

namespace CarRentalConsoleUI
{
    public static class AdministratorView
    {
        public static void CarsView()
        {
            bool carsView = true;

            IFileHandler<RentalSubject> fileHandler = new XmlFileHandler<RentalSubject>(FileNameValues.RentalSubjects);

            IRentalSubjectHandler rentalSubjectHandler = new BaseRentalSubjectHandler(fileHandler);

            while (carsView)
            {
                List<RentalSubject> rentalSubjects = rentalSubjectHandler.GetAllRentalSubjects();

                Console.WriteLine("Cars                     0 - Exit | 00 - Add car");
                Console.WriteLine("");

                foreach (RentalSubject subject in rentalSubjects)
                {
                    Console.WriteLine(subject.ToString() + '\n');
                }

                string answer = Console.ReadLine();

                if (answer == "0")
                {
                    carsView = false;
                }
                if (answer == "00")
                {
                    Console.Clear();
                    AddCarView();
                }

                Console.Clear();
            }
        }

        public static void AddCarView()
        {
            bool addCarsView = true;

            IFileHandler<RentalSubject> fileHandler = new XmlFileHandler<RentalSubject>(FileNameValues.RentalSubjects);

            IRentalSubjectHandler rentalSubjectHandler = new BaseRentalSubjectHandler(fileHandler);
            IRecorder<RentalSubject> recorder = new BaseRecorder<RentalSubject>(fileHandler);

            while (addCarsView)
            {
                Console.WriteLine("Add new car                     ");
                Console.WriteLine("");

                int capacity = InputHandler.InputPositiveIntegerNumber("Enter capacity:                       00 - continue");

                int engineVolume = InputHandler.InputPositiveIntegerNumber("Enter engine volume:                  00 - continue");

                double mileage = InputHandler.InputPositiveDoubleNumber("Enter mileage:                        00 - continue");

                DateTime releaseDate = InputHandler.InputDateTime("Enter release date:                   00 - continue");

                string plateNumber = InputHandler.InputStringWithConcreteSize("Enter plate number:                   00 - continue", ModelValues.PlateNumberSize);

                double insuranceSum = InputHandler.InputPositiveDoubleNumber("Enter insurance sum:                  00 - continue");

                double price = InputHandler.InputPositiveDoubleNumber("Enter price for day:                  00 - continue");

                if (capacity < 0 || engineVolume < 0 || mileage < 0 || releaseDate == DateTime.MinValue || plateNumber == string.Empty || insuranceSum < 0 || price < 0)
                {
                    Console.WriteLine(" 0 - Exit");

                    string answer = Console.ReadLine();
                    if (answer == "0")
                        addCarsView = false;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Correct input data or exit.");
                    }
                }
                else
                {
                    Console.Clear();
                    RentalSubject rentalSubject = new RentalSubject(new Car(capacity, engineVolume, mileage, releaseDate, plateNumber, insuranceSum), price, RentalSubjectStatus.Free);
                    addCarsView = false;
                    if (Administrator.AddCar(rentalSubject, recorder, rentalSubjectHandler))
                    {
                        Console.Clear();
                        Console.WriteLine("Car added successfully!");
                    }
                }
            }
        }

        public static void UsersView()
        {
            bool usersView = true;

            IFileHandler<User> fileHandler = new XmlFileHandler<User>(FileNameValues.Users);
            IUserHandler userHandler = new BaseUserHandler(fileHandler);

            List<User> users = userHandler.GetAllUsers();

            while (usersView)
            {
                Console.WriteLine("Users                     0 - Exit");
                Console.WriteLine("");

                foreach (User user in users)
                {
                    Console.WriteLine(user.ToString());
                }

                string answer = Console.ReadLine();

                if (answer == "0")
                {
                    usersView = false;
                }

                Console.Clear();
            }
        }

        public static void OrdersView()
        {
            bool ordersView = true;

            IFileHandler<Order> fileHandler = new XmlFileHandler<Order>(FileNameValues.Orders);
            IOrdersHandler ordersHandler = new BaseOrdersHandler(fileHandler);

            List<Order> orders = ordersHandler.GetAllOrder();

            while (ordersView)
            {
                Console.WriteLine("Orders                     0 - Exit");

                foreach (Order order in orders)
                {
                    Console.WriteLine(order.ToString() + '\n');
                }

                string answer = Console.ReadLine();

                if (answer == "0")
                {
                    ordersView = false;
                }

                Console.Clear();
            }
        }

    }
}