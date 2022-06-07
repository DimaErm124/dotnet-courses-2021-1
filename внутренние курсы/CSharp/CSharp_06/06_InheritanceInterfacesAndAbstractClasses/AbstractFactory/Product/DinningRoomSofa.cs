namespace AbstractFactory
{
    public class DinningRoomSofa : IDinningRoomFurniture
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