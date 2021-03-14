namespace Task4
{
    public class Enemy : Character, IAttack
    {   
        public double Damage { get ; set ; }
        
        public Enemy(int x,
                     int y,
                     int height,
                     int width,
                     double health,
                     double speed,
                     int step,
                     double visibilityRange,
                     double regeneration,
                     double damage) : base(x, y, height, width, health, speed, step, visibilityRange, regeneration)
        {
        }

        public virtual void Attack(IActiveMobilable activeMobilable)
        {
        }

        private bool IsPlayer(IActiveMobilable activeMobilable)
        {
            return true;
        }
    }
}
