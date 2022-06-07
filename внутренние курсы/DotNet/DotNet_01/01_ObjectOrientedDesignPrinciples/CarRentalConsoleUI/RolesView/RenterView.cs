using CarRental;
using System;
using System.Collections.Generic;

namespace CarRentalConsoleUI
{
    public static class RenterView
    {
        public static void RentACarView(Renter renter)
        {
            bool clientRent = true;

            IFileHandler<Order> fileHandler = new XmlFileHandler<Order>(FileNameValues.Orders);
            IFileHandler<RentalSubject> rentalSubjectFileHandler = new XmlFileHandler<RentalSubject>(FileNameValues.RentalSubjects);

            IOrderOpener orderOpener = new BaseOrderOpener(fileHandler, rentalSubjectFileHandler);

            IRentalSubjectHandler freeRentalSubjectHandler = new BaseRentalSubjectHandler(rentalSubjectFileHandler);

            IReporter<RentalSubject> reporter = new BaseFreeRentalSubjectReporter(new XmlFileHandler<RentalSubject>(FileNameValues.FreeRentalSubjects));

            List<RentalSubject> rentalSubjects = freeRentalSubjectHandler.GetFreeRentalSubjects();

            while (clientRent)
            {
                Console.WriteLine("Free cars                      0 - Exit | 00 - Filters | 000 - Report on free cars");
                Console.WriteLine("");

                for (int i = 0; i < rentalSubjects.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + '\n' + rentalSubjects[i].ToString() + '\n');
                }

                string answer = Console.ReadLine();

                if (answer == "0")
                {
                    Console.Clear();
                    clientRent = false;
                    answer = string.Empty;
                }
                else if (answer == "00")
                {
                    Console.Clear();
                    rentalSubjects = RenterFilters.FiltersForRent(freeRentalSubjectHandler.GetFreeRentalSubjects());
                    answer = string.Empty;
                }
                else if (answer == "000")
                {
                    Console.Clear();
                    if (reporter.Report(rentalSubjects))
                    {
                        Console.WriteLine("Report has been successfully generated");
                        answer = string.Empty;
                    }
                    else
                    {
                        Console.WriteLine("Report hasn`t been successfully generated");
                        answer = string.Empty;
                    }
                }
                else
                    for (int i = 0; i < rentalSubjects.Count; i++)
                    {
                        if (answer == (i + 1).ToString() && orderOpener.Open(new Order(renter.Client, rentalSubjects[i], DateTime.Now, OrderStatus.Open)))
                        {
                            Console.Clear();
                            Console.WriteLine("Car successfully rented!");
                            rentalSubjects = freeRentalSubjectHandler.GetFreeRentalSubjects();
                            answer = string.Empty;
                        }
                    }

                if (answer != string.Empty)
                {
                    Console.Clear();
                }
            }
        }

        public static void CloseARentView(ref Renter renter)
        {
            bool closeARent = true;

            IFileHandler<Order> fileHandler = new XmlFileHandler<Order>(FileNameValues.Orders);
            IFileHandler<RentalSubject> subjectFileHandler = new XmlFileHandler<RentalSubject>(FileNameValues.RentalSubjects);

            IOrderClosure orderClosure = new BaseOrderClosure(fileHandler, subjectFileHandler);

            while (closeARent)
            {
                List<Order> orders = renter.GetActiveOrders(new BaseOrdersHandler(fileHandler));

                Console.WriteLine("Active rents           0 - Exit");
                Console.WriteLine("");

                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + '\n' + orders[i].ToString() + '\n');
                }

                string answer = Console.ReadLine();

                if (answer == "0")
                {
                    Console.Clear();
                    closeARent = false;
                    answer = string.Empty;
                }
                for (int i = 0; i < orders.Count; i++)
                {
                    
                    if (answer == (i + 1).ToString() && orderClosure.Close(orders[i]))
                    {
                        Console.Clear();
                        Console.WriteLine("Rent successfully closed!");
                        answer = string.Empty;
                    }
                }

                if (answer != string.Empty)
                {
                    Console.Clear();
                }
            }
        }

        public static void ProfileView(Renter renter)
        {
            bool clientProfile = true;

            while (clientProfile)
            {
                Console.WriteLine("1 - Orders history | 0 - Exit");
                Console.WriteLine("");
                Console.WriteLine("Name: {0}", renter.Client.Name);
                Console.WriteLine("Surname: {0}", renter.Client.Surname);
                Console.WriteLine("Driver license: {0}", renter.Client.DriverLicense);


                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        HistoryView(renter);
                        break;
                    case "0":
                        Console.Clear();
                        clientProfile = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        private static void HistoryView(Renter renter)
        {
            bool clientHistory = true;

            IFileHandler<Order> fileHandler = new XmlFileHandler<Order>(FileNameValues.Orders);
            IOrdersHandler clientOrdersHandler = new BaseOrdersHandler(fileHandler);

            List<Order> orders = renter.GetOrdersHistory(clientOrdersHandler);

            while (clientHistory)
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("");

                foreach (Order order in orders)
                {
                    Console.WriteLine(order.ToString() + '\n');
                }

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "0":
                        Console.Clear();
                        clientHistory = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

    }
}