using CarRental;
using System;
using System.Collections.Generic;

namespace CarRentalConsoleUI
{
    public static class RenterFilters
    {
        public static List<RentalSubject> FiltersForRent(List<RentalSubject> subjects)
        {
            bool filters = true;

            while (filters)
            {
                Console.WriteLine("1 - Capacity");
                Console.WriteLine("2 - Price");
                Console.WriteLine("3 - Release date");
                Console.WriteLine("");
                Console.WriteLine("0 - Exit");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        subjects = CapacityFilter(subjects);
                        filters = false;
                        break;
                    case "2":
                        Console.Clear();
                        subjects = PriceFilter(subjects);
                        filters = false;
                        break;
                    case "3":
                        Console.Clear();
                        subjects = ReleaseDateFilter(subjects);
                        filters = false;
                        break;
                    case "0":
                        Console.Clear();
                        filters = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please, choose one of them.");
                        break;
                }
            }

            return subjects;
        }

        private static List<RentalSubject> CapacityFilter(List<RentalSubject> subjects)
        {
            int lowerBound = 0;
            int upperBound = 0;

            bool bounds = true;

            while (bounds)
            {
                Console.WriteLine("Capacity bounds:          ");
                Console.WriteLine("");

                Console.WriteLine("Enter lower bound:            continue - 00");
                string lowerBoundString = Console.ReadLine();

                Console.WriteLine("Enter upper bound:            continue - 00");
                string upperBoundString = Console.ReadLine();

                if ((lowerBoundString == "00" || upperBoundString == "00"))
                {
                    bounds = false;
                    Console.Clear();
                }
                else if (InputHandler.IsIntegerBounds(lowerBoundString, upperBoundString, ref lowerBound, ref upperBound))
                {
                    subjects = RentalSubjectFilters.GetRentalObjectByCapacity(lowerBound, upperBound, subjects);
                    bounds = false;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please, enter integer numbers more than zero where lower bound must be less than upper bound.");
                }
            }

            return subjects;
        }

        private static List<RentalSubject> PriceFilter(List<RentalSubject> subjects)
        {
            double lowerBound = 0;
            double upperBound = 0;

            bool bounds = true;

            while (bounds)
            {
                Console.WriteLine("Price bounds:          ");
                Console.WriteLine("");

                Console.WriteLine("Enter lower bound:            continue - 00");
                string lowerBoundString = Console.ReadLine();

                Console.WriteLine("Enter upper bound:            continue - 00");
                string upperBoundString = Console.ReadLine();

                if ((lowerBoundString == "00" || upperBoundString == "00"))
                {
                    bounds = false;
                    Console.Clear();
                }
                else if (InputHandler.IsDoubleBounds(lowerBoundString, upperBoundString, ref lowerBound, ref upperBound))
                {
                    subjects = RentalSubjectFilters.GetRentalObjectByPrice(lowerBound, upperBound, subjects);
                    bounds = false;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please, enter numbers more than zero where lower bound must be less than upper bound..");
                }
            }

            return subjects;
        }

        private static List<RentalSubject> ReleaseDateFilter(List<RentalSubject> subjects)
        {
            DateTime lowerBound = new DateTime();
            DateTime upperBound = new DateTime();

            bool bounds = true;

            while (bounds)
            {
                Console.WriteLine("Release date bounds:          ");
                Console.WriteLine("");
                Console.WriteLine("Enter lower bound:            continue - 00");
                string lowerBoundString = Console.ReadLine();
                Console.WriteLine("Enter upper bound:            continue - 00");
                string upperBoundString = Console.ReadLine();

                if ((lowerBoundString == "00" || upperBoundString == "00"))
                {
                    bounds = false;
                    Console.Clear();
                }
                else if (InputHandler.IsDateBounds(lowerBoundString, upperBoundString, ref lowerBound, ref upperBound))
                {
                    subjects = RentalSubjectFilters.GetRentalObjectByReleaseDate(lowerBound, upperBound, subjects);
                    bounds = false;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please, enter date more than zero where lower bound must be less than upper bound..");
                }
            }

            return subjects;
        }

    }
}