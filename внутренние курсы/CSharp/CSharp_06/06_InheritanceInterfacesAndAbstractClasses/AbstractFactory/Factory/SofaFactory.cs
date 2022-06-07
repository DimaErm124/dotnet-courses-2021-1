namespace AbstractFactory
{
    public class SofaFactory : IFurnitureFactory
    {
        public IDinningRoomFurniture CreateDinningRoomFurniture()
        {
            return new DinningRoomSofa();
        }

        public IOfficeFurniture CreateOfficeFurniture()
        {
            return new OfficeSofa();
        }

        public IWickerFurniture CreateWickerFurniture()
        {
            return new WickerSofa();
        }
    }
}