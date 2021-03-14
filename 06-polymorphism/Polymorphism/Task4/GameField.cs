namespace Task4
{
    public class GameField
    {
        private Entity[,] _field;

        public GameField(int height, int width)
        {
            _field = new Entity[height, width];
        }

        private void FillFieldEmpty()
        {
        }

        public void AddEntity(int x, int y, Entity entity)
        {
        }
    }
}
