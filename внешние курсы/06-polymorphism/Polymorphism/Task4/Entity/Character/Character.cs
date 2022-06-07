namespace Task4
{
    public class Character : Entity, IActiveMobilable
    {     
        public double Speed { get ; set ; }

        public double VisibilityRange { get ; set ; }

        public double Health { get ; set ; }

        public double Regeneration { get ; set ; }

        public int Step { get ; set ; }

        public bool IsDead { get ; set ; }

        public Character(int x,
                         int y,
                         int height,
                         int width,
                         double health,
                         double speed,
                         int step,
                         double visibilityRange,
                         double regeneration) : base(x, y, height, width)
        {
        }

        public virtual void Run()
        {           
        }

        public virtual void LookAround()
        {
        }

        private bool IsBarrier(Entity entity)
        {
            return true;
        }
    }
}
