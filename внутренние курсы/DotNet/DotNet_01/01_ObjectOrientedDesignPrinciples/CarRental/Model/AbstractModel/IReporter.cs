using System.Collections.Generic;

namespace CarRental
{
    public interface IReporter<T>
    {
        public bool Report(List<T> entities);
    }
}