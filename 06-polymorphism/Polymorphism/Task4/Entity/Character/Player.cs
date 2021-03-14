namespace Task4
{
    public class Player : Character
    {
        public Player(int x,
                      int y,
                      int height,
                      int width,
                      double health,
                      double speed,
                      int step,
                      double visibilityRange,
                      double regeneration) : base(x, y, height, width, health, speed, step, visibilityRange, regeneration)
        {
        }

        private void FindBonus()
        {
        }

        private bool IsBonus(IActive active)
        {
            return true;
        }

        private void TakeBonus(IActive active)
        {
        }
    }
}
