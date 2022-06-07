namespace Task4
{
    public interface IActive
    {
        double Health { get; set; }

        double Regeneration { get; set; }

        double Speed { get; set; }

        bool IsDead { get; set; }
    }
}
