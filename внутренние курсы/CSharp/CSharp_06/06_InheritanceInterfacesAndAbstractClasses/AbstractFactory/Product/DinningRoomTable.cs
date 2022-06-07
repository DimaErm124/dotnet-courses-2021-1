namespace AbstractFactory
{
    public class DinningRoomTable : IDinningRoomFurniture
    {
        public string GetDinningRoomFurnitureName()
        {
            return this.GetType().Name;
        }

        public override string ToString()
        {
            return GetDinningRoomFurnitureName();
        }
    }
}