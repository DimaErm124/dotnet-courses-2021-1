namespace Task4
{
    public class Bonus : Entity, IActive
    {
        public double Health { get ; set ; }

        public double Regeneration { get ; set ; }

        public double Speed { get; set ; }

        public bool IsDead { get ; set ; }

        public Bonus(int x, int y, int height, int width) : base(x, y, height, width)
        {
        }
    }
}
