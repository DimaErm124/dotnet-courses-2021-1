namespace AbstractFactory
{
    public class ChairFactory : IFurnitureFactory
    {
        public IDinningRoomFurniture CreateDinningRoomFurniture()
        {
            return new DinningRoomChair();
        }

        public IOfficeFurniture CreateOfficeFurniture()
        {
            return new OfficeChair();
        }

        public IWickerFurniture CreateWickerFurniture()
        {
            return new WickerChair();
        }
    }
}