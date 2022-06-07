namespace ProgressionLibrary
{
    public interface ISeries
    {
        double Current { get; }

        bool MoveNext();

        void Reset();
    }
}
