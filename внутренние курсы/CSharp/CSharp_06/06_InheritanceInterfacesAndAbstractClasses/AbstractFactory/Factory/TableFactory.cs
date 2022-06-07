namespace AbstractFactory
{
    public class TableFactory : IFurnitureFactory
    {
        public IDinningRoomFurniture CreateDinningRoomFurniture()
        {
            return new DinningRoomTable();
        }

        public IOfficeFurniture CreateOfficeFurniture()
        {
            return new OfficeTable();
        }

        public IWickerFurniture CreateWickerFurniture()
        {
            return new WickerTable();
        }
    }
}