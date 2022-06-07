namespace CarRental
{
    public interface IRecorder<T>
    {
        public bool Add(T entity);
    }
}