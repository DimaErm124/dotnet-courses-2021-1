namespace AbstractFactory
{
    public class DinningRoomChair : IDinningRoomFurniture
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