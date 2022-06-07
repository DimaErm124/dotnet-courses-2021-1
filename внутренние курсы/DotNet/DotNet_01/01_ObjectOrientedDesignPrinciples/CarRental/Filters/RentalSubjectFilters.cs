using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    public static class RentalSubjectFilters
    {
        public static List<RentalSubject> GetRentalObjectByPrice(double lowerBound, double upperBound, List<RentalSubject> subjects)
        {
            return subjects.Where(x => x.Price >= lowerBound && x.Price <= upperBound).ToList();
        }

        public static List<RentalSubject> GetRentalObjectByReleaseDate(DateTime lowerBound, DateTime upperBound, List<RentalSubject> subjects)
        {
            return subjects.Where(x => x.Car.ReleaseDate >= lowerBound && x.Car.ReleaseDate <= upperBound).ToList();
        }

        public static List<RentalSubject> GetRentalObjectByCapacity(int lowerBound, int upperBound, List<RentalSubject> subjects)
        {
            return subjects.Where(x => x.Car.Capacity >= lowerBound && x.Car.Capacity <= upperBound).ToList();
        }
    }
}