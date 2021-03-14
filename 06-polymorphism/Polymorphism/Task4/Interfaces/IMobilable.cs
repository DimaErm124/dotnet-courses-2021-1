namespace Task4
{
    public interface IMobilable
    {
        int Step { get; set; }

        double VisibilityRange { get; set; }

        void Run();
    }
}
