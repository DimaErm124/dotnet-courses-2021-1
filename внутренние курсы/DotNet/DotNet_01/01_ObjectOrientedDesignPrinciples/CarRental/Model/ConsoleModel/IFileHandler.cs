using System.Collections.Generic;

namespace CarRental
{
    public interface IFileHandler<T>
    {
        public List<T> Read();

        public bool Write(T entity);

        public bool WriteAll(List<T> entities);
    }
}